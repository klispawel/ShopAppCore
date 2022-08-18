using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ProductTypeService
{

    public static void UpdateProduct(int productId, string name, string code, ProductDetails details, int productTypeId, double price, double discountPercentValue)
    {

    }

    public static ProductType GetProductType(int productTypeId)
    {
        ProductType? p = SingletonDBContext.dbContext.ProductTypes.ToList().Find(x => x.Id == productTypeId);
        if (p == null)
        {
            throw new NoProductTypeException($"ProductType {productTypeId} not exists");
        }
        else
        {
            return p;
        }
    }
    public static List<ProductType> GetProductTypes()
    {
        List<ProductType>? p = SingletonDBContext.dbContext.ProductTypes.ToList();
        if (p == null)
        {
            throw new NoProductTypeException($"ProductTypes empty");
        }
        else
        {
            return p;
        }
    }

}



public class NoProductTypeException : Exception
{
    public NoProductTypeException()
    {
    }

    public NoProductTypeException(string message)
        : base(message)
    {
    }

    public NoProductTypeException(string message, Exception inner)
        : base(message, inner)
    {
    }
}
