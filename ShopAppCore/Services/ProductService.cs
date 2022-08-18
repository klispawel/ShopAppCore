using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class ProductService
{

    public static Product GetProduct(int productId)
    {
        Product? p = SingletonDBContext.dbContext.Products.ToList().Find(x => x.Id == productId);
        if (p == null)
        {
            throw new NoProductException($"Product {productId} not exists");
        }
        else
        {
            return p;
        }
    }
    public static List<Product> GetProducts()
    {
        List<Product>? p = SingletonDBContext.dbContext.Products.ToList();
        if (p == null)
        {
            throw new NoProductException($"Products empty");
        }
        else
        {
            return p;
        }
    }
    public static List<Product> GetProductsByType(int productTypeId)
    {
        List<Product>? p = SingletonDBContext.dbContext.Products.ToList().Where(x=>x.ProductTypeId== productTypeId).ToList();
        if (p == null)
        {
            throw new NoProductException($"Products empty");
        }
        else
        {
            return p;
        }
    }
}



public class NoProductException : Exception
{
    public NoProductException()
    {
    }

    public NoProductException(string message)
        : base(message)
    {
    }

    public NoProductException(string message, Exception inner)
        : base(message, inner)
    {
    }
}

