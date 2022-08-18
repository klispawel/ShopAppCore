using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Product
{
    public int Id { get;private set; }
    public string Name { get; private set; }
    public string Code { get; private set; }
    public ProductDetails Details { get; private set; }
    public int ProductTypeId { get; private set; }
    private double _price;
    public double Price { get { return Math.Round(_price, 2); } private set { _price = value; } }
    public double DiscountPercentValue { get; private set; }
    public double PriceWithDiscount { get { return DiscountPrice(); } }

    public Product(string name, string code, ProductDetails details, int productTypeId, double price, double discountPercentValue)
    { 

        Name = name;
        Code = code;
        Details = details;
        ProductTypeId = productTypeId;
        Price = price;
        DiscountPercentValue = discountPercentValue;
    }

    public void Update(Product input)
    {

        ProductType type = ProductTypeService.GetProductType(input.ProductTypeId);
        if (type == null)
            throw new NoProductTypeException($"ProductType {input.ProductTypeId} not exists");

        this.Name=input.Name;
        this.Code=input.Code;
        this.Details=input.Details;
        this.ProductTypeId =input.ProductTypeId;
        this.Price =input.Price;
        this.DiscountPercentValue =input.DiscountPercentValue;
        this.Save();
    }

    private void SetPrice(double price)
    {
        this.Price = price;
    }
    private void SetDiscount(double discount)
    {
        this.DiscountPercentValue = discount;
    }

    private double DiscountPrice()
    {
        if (DiscountPercentValue == 0)
            return Price;
        double priceDiscount =(double)Price - (((double)DiscountPercentValue * (double)Price )/100);

        return Math.Round(priceDiscount,2);
    }

    public void Save()
    {
        SingletonDBContext.dbContext.UpdateObject(this);
    }

    public void Delete()
    {
        SingletonDBContext.dbContext.RemovetObject(this);
    }
}

