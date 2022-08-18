
SingletonDBContext.Init();


ProductType pt = new ProductType("Nieznany", "");


Product p = new Product("Produkt 1", "P1", new ProductDetails("opis", DateTime.Now.AddDays(10)), 1, 2.99, 0);
p.Save();

foreach(var pp in ProductService.GetProducts())
{
    Console.WriteLine(pp.Name);
}


Console.ReadKey();

