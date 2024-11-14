﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using QLCH_BE;

#nullable disable

namespace QLCH_BE.Migrations
{
    [DbContext(typeof(StoreManagementDbContext))]
    partial class StoreManagementDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("QLCH_BE.Entities.Invoice.ExpenseInvoiceEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AppUserID")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("BranchId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal?>("ExpenseAmount")
                        .HasColumnType("numeric");

                    b.Property<string>("ExpenseInvoiceName")
                        .HasColumnType("text");

                    b.Property<string>("Note")
                        .HasColumnType("text");

                    b.Property<string>("Notes")
                        .HasColumnType("text");

                    b.Property<double>("TotalAmount")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("time")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("AppUserID");

                    b.HasIndex("BranchId");

                    b.ToTable("ExpenseInvoices");
                });

            modelBuilder.Entity("QLCH_BE.Entities.Invoice.InvoiceDetailEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal?>("Discount")
                        .HasColumnType("numeric");

                    b.Property<Guid?>("InvoiceId")
                        .HasColumnType("uuid");

                    b.Property<string>("Note")
                        .HasColumnType("text");

                    b.Property<Guid?>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("PurchaseOrderId")
                        .HasColumnType("uuid");

                    b.Property<int?>("Quantity")
                        .HasColumnType("integer");

                    b.Property<decimal?>("TotalAmount")
                        .HasColumnType("numeric");

                    b.Property<decimal?>("UnitPrice")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceId");

                    b.HasIndex("ProductId");

                    b.HasIndex("PurchaseOrderId");

                    b.ToTable("InvoiceDetails");
                });

            modelBuilder.Entity("QLCH_BE.Entities.Invoice.InvoiceEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AppUserID")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("BranchId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("Discount")
                        .HasColumnType("numeric");

                    b.Property<Guid?>("MembershipCardId")
                        .HasColumnType("uuid");

                    b.Property<string>("Note")
                        .HasColumnType("text");

                    b.Property<string>("Notes")
                        .HasColumnType("text");

                    b.Property<decimal>("PayableAmount")
                        .HasColumnType("numeric");

                    b.Property<double>("TotalAmount")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("time")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("AppUserID");

                    b.HasIndex("BranchId");

                    b.HasIndex("MembershipCardId");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("QLCH_BE.Entities.Invoice.PurchaseInvoiceEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AppUserID")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("BranchId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal?>("Discount")
                        .HasColumnType("numeric");

                    b.Property<string>("Note")
                        .HasColumnType("text");

                    b.Property<string>("Notes")
                        .HasColumnType("text");

                    b.Property<Guid?>("SupplierId")
                        .HasColumnType("uuid");

                    b.Property<double>("TotalAmount")
                        .HasColumnType("double precision");

                    b.Property<decimal?>("TotalAmountAfterDiscount")
                        .HasColumnType("numeric");

                    b.Property<decimal?>("TotalAmountPayable")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("time")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("AppUserID");

                    b.HasIndex("BranchId");

                    b.HasIndex("SupplierId");

                    b.ToTable("PurchaseInvoices");
                });

            modelBuilder.Entity("QLCH_BE.Entities.Objects.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("QLCH_BE.Entities.Objects.BranchEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("BranchName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Note")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Branches");
                });

            modelBuilder.Entity("QLCH_BE.Entities.Objects.CardTypeEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CardTypeName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Limit")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Note")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("CardTypes");
                });

            modelBuilder.Entity("QLCH_BE.Entities.Objects.EmployeeEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Dateofbirth")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<bool>("Gender")
                        .HasColumnType("boolean");

                    b.Property<string>("Idaccount")
                        .HasColumnType("text");

                    b.Property<Guid?>("Idbranch")
                        .HasColumnType("uuid");

                    b.Property<string>("Nameemployee")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NationalIdcard")
                        .HasColumnType("text");

                    b.Property<string>("Note")
                        .HasColumnType("text");

                    b.Property<string>("Phonenumber")
                        .HasColumnType("text");

                    b.Property<string>("Position")
                        .HasColumnType("text");

                    b.Property<string>("Startingdate")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("Idaccount");

                    b.HasIndex("Idbranch");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("QLCH_BE.Entities.Objects.ImageEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Note")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("QLCH_BE.Entities.Objects.MembershipCardEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<decimal?>("AccumulatedAmount")
                        .HasColumnType("numeric");

                    b.Property<double?>("AccumulatedPoints")
                        .HasColumnType("double precision");

                    b.Property<Guid?>("CardTypeId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<bool>("Gender")
                        .HasColumnType("boolean");

                    b.Property<string>("Note")
                        .HasColumnType("text");

                    b.Property<string>("Phonenumber")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal?>("UsedAmount")
                        .HasColumnType("numeric");

                    b.Property<double?>("UsedPoints")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("CardTypeId");

                    b.ToTable("MembershipCards");
                });

            modelBuilder.Entity("QLCH_BE.Entities.Objects.ProductEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int?>("Avaiablequatity")
                        .HasColumnType("integer");

                    b.Property<decimal?>("Costprice")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("ImageId")
                        .HasColumnType("uuid");

                    b.Property<string>("Note")
                        .HasColumnType("text");

                    b.Property<string>("Productname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal?>("Sellingprice")
                        .HasColumnType("numeric");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("QLCH_BE.Entities.Objects.SupplierEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Note")
                        .HasColumnType("text");

                    b.Property<string>("Phonenumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RepresentativeName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SupplierName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal?>("TotalAmountPaid")
                        .HasColumnType("numeric");

                    b.Property<decimal?>("TotalPurchaseAmount")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("QLCH_BE.Entities.Objects.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("QLCH_BE.Entities.Objects.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QLCH_BE.Entities.Objects.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("QLCH_BE.Entities.Objects.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("QLCH_BE.Entities.Invoice.ExpenseInvoiceEntity", b =>
                {
                    b.HasOne("QLCH_BE.Entities.Objects.AppUser", "appUser")
                        .WithMany("ExpenseInvoices")
                        .HasForeignKey("AppUserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QLCH_BE.Entities.Objects.BranchEntity", "Brand")
                        .WithMany()
                        .HasForeignKey("BranchId");

                    b.Navigation("Brand");

                    b.Navigation("appUser");
                });

            modelBuilder.Entity("QLCH_BE.Entities.Invoice.InvoiceDetailEntity", b =>
                {
                    b.HasOne("QLCH_BE.Entities.Invoice.InvoiceEntity", "Invoice")
                        .WithMany("InvoiceDetails")
                        .HasForeignKey("InvoiceId");

                    b.HasOne("QLCH_BE.Entities.Objects.ProductEntity", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");

                    b.HasOne("QLCH_BE.Entities.Invoice.PurchaseInvoiceEntity", "PurchaseInvoice")
                        .WithMany("InvoiceDetails")
                        .HasForeignKey("PurchaseOrderId");

                    b.Navigation("Invoice");

                    b.Navigation("Product");

                    b.Navigation("PurchaseInvoice");
                });

            modelBuilder.Entity("QLCH_BE.Entities.Invoice.InvoiceEntity", b =>
                {
                    b.HasOne("QLCH_BE.Entities.Objects.AppUser", "appUser")
                        .WithMany("Invoices")
                        .HasForeignKey("AppUserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QLCH_BE.Entities.Objects.BranchEntity", "Brand")
                        .WithMany()
                        .HasForeignKey("BranchId");

                    b.HasOne("QLCH_BE.Entities.Objects.MembershipCardEntity", "MembershipCard")
                        .WithMany()
                        .HasForeignKey("MembershipCardId");

                    b.Navigation("Brand");

                    b.Navigation("MembershipCard");

                    b.Navigation("appUser");
                });

            modelBuilder.Entity("QLCH_BE.Entities.Invoice.PurchaseInvoiceEntity", b =>
                {
                    b.HasOne("QLCH_BE.Entities.Objects.AppUser", "appUser")
                        .WithMany("PurchaseInvoices")
                        .HasForeignKey("AppUserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QLCH_BE.Entities.Objects.BranchEntity", "Brand")
                        .WithMany()
                        .HasForeignKey("BranchId");

                    b.HasOne("QLCH_BE.Entities.Objects.SupplierEntity", "Supplier")
                        .WithMany()
                        .HasForeignKey("SupplierId");

                    b.Navigation("Brand");

                    b.Navigation("Supplier");

                    b.Navigation("appUser");
                });

            modelBuilder.Entity("QLCH_BE.Entities.Objects.EmployeeEntity", b =>
                {
                    b.HasOne("QLCH_BE.Entities.Objects.AppUser", "AppUser")
                        .WithMany()
                        .HasForeignKey("Idaccount");

                    b.HasOne("QLCH_BE.Entities.Objects.BranchEntity", "Branch")
                        .WithMany()
                        .HasForeignKey("Idbranch");

                    b.Navigation("AppUser");

                    b.Navigation("Branch");
                });

            modelBuilder.Entity("QLCH_BE.Entities.Objects.ImageEntity", b =>
                {
                    b.HasOne("QLCH_BE.Entities.Objects.ProductEntity", "Product")
                        .WithOne("Image")
                        .HasForeignKey("QLCH_BE.Entities.Objects.ImageEntity", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("QLCH_BE.Entities.Objects.MembershipCardEntity", b =>
                {
                    b.HasOne("QLCH_BE.Entities.Objects.CardTypeEntity", "CardType")
                        .WithMany("membershipcard")
                        .HasForeignKey("CardTypeId");

                    b.Navigation("CardType");
                });

            modelBuilder.Entity("QLCH_BE.Entities.Invoice.InvoiceEntity", b =>
                {
                    b.Navigation("InvoiceDetails");
                });

            modelBuilder.Entity("QLCH_BE.Entities.Invoice.PurchaseInvoiceEntity", b =>
                {
                    b.Navigation("InvoiceDetails");
                });

            modelBuilder.Entity("QLCH_BE.Entities.Objects.AppUser", b =>
                {
                    b.Navigation("ExpenseInvoices");

                    b.Navigation("Invoices");

                    b.Navigation("PurchaseInvoices");
                });

            modelBuilder.Entity("QLCH_BE.Entities.Objects.CardTypeEntity", b =>
                {
                    b.Navigation("membershipcard");
                });

            modelBuilder.Entity("QLCH_BE.Entities.Objects.ProductEntity", b =>
                {
                    b.Navigation("Image");
                });
#pragma warning restore 612, 618
        }
    }
}
