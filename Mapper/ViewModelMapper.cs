using AutoMapper;
using EFCore.Models;
using EFCore.ViewModel;

namespace EFCore.Mapper
{
	public class ViewModelMapper: Profile
	{
        public ViewModelMapper()
        {
            CreateMap<Product, ProductViewModel>().ReverseMap();
        }
    }
}
