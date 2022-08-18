using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DBContext : DbContext
{
    public DBContext() : base()
    {
    }
    public DBContext(DbContextOptions<DBContext> options) : base(options)
    {
    }


    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // string mySqlConnectionStr = "Server=localhost;Database=cois;Uid=root;Pwd=mayday1";
        // options.UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr));

        string sqlConnectionString = @$"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\pawel.klis\source\repos\ShopAppCore\ShopAppCore\bin\Debug\net6.0\DB\ShopDB.mdf;Integrated Security=True";
        options.UseSqlServer(sqlConnectionString);

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().Property(p => p.Details)
                                                    .HasConversion(
                                                       v => JsonConvert.SerializeObject(v),
                                                       v => JsonConvert.DeserializeObject<ProductDetails>(v)
                                                    );
    }

    public void UpdateObject<T>(T o) where T : class
    {
        try
        {
            this.Set<T>().Update(o);
            this.SaveChanges();            
        }
        catch (Exception ex)
        {

        }
    }

    public void UpdateObjectAsync<T>(T o) where T : class
    {
        try
        {
            this.Set<T>().Update(o);
            this.SaveChangesAsync();
        }
        catch
        {
            throw;
        }
    }
    public void RemovetObject<T>(T o, bool async = false) where T : class
    {

        try
        {
            this.Set<T>().Remove((T)o);
            this.SaveChanges();
        }
        catch (Exception ex)
        {

        }

    }

    public DbSet<Product> Products { get; set; }
    public DbSet<ProductType> ProductTypes { get; set; }

}
