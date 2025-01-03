
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using QLCH_BE.Repositories;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.IdentityModel.Tokens;
    using Microsoft.OpenApi.Models;
    using Swashbuckle.AspNetCore.Filters;
    using System.Text;
    using QLCH_BE.Common.Interface;
    using QLCH_BE.Entities.Objects;
    using QLCH_BE.Container;
    using QLCH_BE.Service;
    using QLCH_BE.Modal;

    namespace QLCH_BE
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                var builder = WebApplication.CreateBuilder(args);
                builder.Services.AddAutoMapper(typeof(Program));
                // Add services to the container.

                builder.Services.AddControllers();
                builder.Services.AddScoped<IBranchRepository,BranchRepository>();
                builder.Services.AddScoped<ICardTypeRepository,CardTypeRepository>();
                builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
                builder.Services.AddScoped<IMembershipCardRepository, MembershipCardRepository>();
                builder.Services.AddScoped<IProductRepository, ProductRepository>();
                builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();
                builder.Services.AddScoped<IAccountRepository, AccountRepository>();
                builder.Services.AddScoped<IPermissionRepository, PermissionRepository>();
                builder.Services.AddScoped<IStoreManagementDbContext, StoreManagementDbContext>();


                // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddSwaggerGen(options =>
                {
                    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                    {
                        In = ParameterLocation.Header,
                        Name = "Authorization",
                        Type = SecuritySchemeType.ApiKey
                    });
                    options.OperationFilter<SecurityRequirementsOperationFilter>();
                });
                builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JWT"));
                builder.Services.AddTransient<IEmailService, EmailService>();
                builder.Services.AddTransient<IUserService, UserService>(); 
                builder.Services.AddTransient<IUserRoleServices,UserRoleService>();
                builder.Services.AddTransient<IRefreshHandler, RefreshHandler>();
                builder.Services.AddDbContext<StoreManagementDbContext>(options =>
                {
                    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
                });
                AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

                builder.Services.AddCors(options =>
                {
                    options.AddPolicy("AllowAllOrigins",
                        builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
                });
                // identity
                builder.Services.AddIdentity<ApplicationUser, IdentityRole<Guid>>()
                .AddEntityFrameworkStores<StoreManagementDbContext>()
                .AddDefaultTokenProviders();
                builder.Services.AddAuthentication(options => {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                }).AddJwtBearer(options => {
                    options.SaveToken = true;
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidAudience = builder.Configuration["JWT:ValidAudience"],
                        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"] ?? throw new ArgumentException()))
                    };
                });



                var app = builder.Build();
                // Khoi tao quyen
                using (var scope = app.Services.CreateScope())
                {
                    var accountRepo = scope.ServiceProvider.GetRequiredService<IAccountRepository>();
                    accountRepo.InitializeRolesAndSuperUserAsync().GetAwaiter().GetResult();
                }

                // identity
                //app.MapIdentityApi<IdentityUser>();
                app.UseCors("AllowAllOrigins");
                // Configure the HTTP request pipeline.
                if (app.Environment.IsDevelopment())
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }

                app.UseHttpsRedirection();

                app.UseAuthorization();
            

                app.MapControllers();

                app.Run();
            }
        }
    }
