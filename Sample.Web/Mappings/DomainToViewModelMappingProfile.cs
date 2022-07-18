using AutoMapper;
using Sample.Model;
using Sample.Web.ViewModels;

namespace Sample.Web.Mappings
{
    public class DomainToViewModelMappingProfile: Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Product, ProductViewModel>();
            Mapper.CreateMap<Unit, UnitViewModel>();
        }
    }
}