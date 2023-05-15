using MyFirstWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyFirstWebApi.Controllers
{
    public class ProductController : ApiController
    {
        ProductDBEntities productDBEntities = new ProductDBEntities();
        Product product = new Product();

        // This Method would return the list of products
        [HttpGet]
        public IEnumerable<Product> GetProductsList()
        {
            List<Product> products = new List<Product>();
            products = productDBEntities.Products.ToList();
            return products;
        }
        // This method would return the product based on the id
        [HttpGet]
        public Product GetProductById(int id)
        {
          //  Product product = new Product();
            product = productDBEntities.Products.Find(id);
            return product;
        }
        // This method would create the Product
        [HttpPost]
        public string CreateProduct(Product prod)
        {
            product.ProductName = prod.ProductName;
            product.ProductPrice = prod.ProductPrice;
            productDBEntities.Products.Add(product);
            productDBEntities.SaveChanges();
            return "The Product is created";
        }
        // This method would update the Product
        [HttpPut]
        public string UpdateProduct(Product prod)
        {
            product = productDBEntities.Products.Find(prod.ProductId);
            if(product != null)
            {
                product.ProductName = prod.ProductName;
                product.ProductPrice = prod.ProductPrice;
                productDBEntities.SaveChanges();
                return "The Product is Updated";
            }
            return "The Product is not updated, the Product ID doesn't exist";
            
        }
        [HttpDelete]
        public string DeleteProduct(int productid)
        {
           product = productDBEntities.Products.Find(productid);
            productDBEntities.Products.Remove(product);
            productDBEntities.SaveChanges();
            return "The Product is deleted";
        }
        public string Message()
        {
            return "HelloWorld";
        }
    }
}
