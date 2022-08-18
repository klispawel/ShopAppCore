using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ProductType
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }

    public ProductType( string name, string description)
    {
        Name = name;
        Description = description;
    }

    public void Update(ProductType input)
    {
        this.Name=input.Name;
        this.Description=input.Description;
        this.Save();
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

