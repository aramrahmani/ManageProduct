using AutoMapper;
using Sample.Model;
using Sample.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sample.Web.Mappings
{
    public class ViewModelToDomainMappingProfile: Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            CostomizeMapProductModelConfigure();
        }

        private void CostomizeMapProductModelConfigure()
        {
            Mapper.CreateMap<Product, ProductsDataTableViewModel>()

              .ForMember(p => p.ProductId, map => map.MapFrom(vm => vm.ProductId))
              .ForMember(p => p.ProductName, map => map.MapFrom(vm => vm.ProductName))
              .ForMember(p => p.Count, map => map.MapFrom(vm => vm.Count))
              .ForMember(p => p.UnitId, map => map.MapFrom(vm => vm.UnitId))
              .ForMember(p => p.UnitTitle, map => map.MapFrom(vm => vm.Unit.UnitName));
        }
    }
}