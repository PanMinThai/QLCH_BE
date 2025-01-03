using AutoMapper;
using Microsoft.AspNetCore.Identity;
using QLCH_BE.Entities.AccountManagement;
using QLCH_BE.Entities.Common;
using QLCH_BE.Entities.Objects;
using QLCH_BE.Modal;
using QLCH_BE.Models;

namespace QLCH_BE.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<BranchEntity,BranchModel>().ReverseMap();
            CreateMap<CardTypeEntity,CardTypeModel>().ReverseMap();
            CreateMap<EmployeeEntity,EmployeeModel>().ReverseMap();
            CreateMap<ImageEntity,ImageModel>().ReverseMap();
            CreateMap<MembershipCardEntity,MembershipCardModel>().ReverseMap();
            CreateMap<ProductEntity,ProductModel>().ReverseMap();   
            CreateMap<SupplierEntity,SupplierModel>().ReverseMap();
            CreateMap<Menu, MenuModel>().ReverseMap();
        }
    }
}
