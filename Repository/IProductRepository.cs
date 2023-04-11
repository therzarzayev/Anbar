using EFCore.Models;

namespace EFCore.Repository
{
	public interface IProductRepository
	{
		Product GetById(int id);
		List<Product> Products { get; }
		void CreateProduct(Product product);
		void UpdateProduct(Product product);
		void DeleteProduct(int id);
	}
}
