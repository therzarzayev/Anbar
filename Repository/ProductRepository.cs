using EFCore.DbOperations;
using EFCore.Models;

namespace EFCore.Repository
{
    public class ProductRepository : IProductRepository
    {
        private PContext _context;
        public ProductRepository(PContext context)
        {
            _context = context;
        }

        public List<Product> Products
        {
            get{ return _context.Products.ToList(); }
        }

        public void CreateProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            var product = GetById(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }

        public Product GetById(int id) => _context.Products.FirstOrDefault(x => x.Id == id);

        public void UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }
    }
}
