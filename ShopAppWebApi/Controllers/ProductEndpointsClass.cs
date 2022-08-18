namespace ShopAppWebApi.Controllers;

public static class ProductEndpointsClass
{
    public static void MapProductEndpoints (this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/Product", () =>
        {
            return new [] { ProductService.GetProducts() };
        })
        .WithName("GetAllProducts");

        routes.MapGet("/api/Product/{id}", (int id) =>
        {
            return ProductService.GetProduct(id);
        })
        .WithName("GetProductById");

        routes.MapPut("/api/Product/{id}", (int id, Product input) =>
        {
            try
            {
                Product model = ProductService.GetProduct(id);
                model.Update(input);
                return Results.Ok(model);
            }
            catch (NoProductException ex)
            {
                return Results.NotFound(ex.Message);
            }
            catch (NoProductTypeException ex)
            {
                return Results.NotFound(ex.Message);
            }
        })
        .WithName("UpdateProduct");

        routes.MapPost("/api/Product/", (Product model) =>
        {
            try
            {
                model.Save();
                return Results.Ok(model);
            }
            catch (NoProductException ex)
            {
                return Results.NotFound(ex.Message);
            }
            catch (NoProductTypeException ex)
            {
                return Results.NotFound(ex.Message);
            }
        })
        .WithName("CreateProduct");

        routes.MapDelete("/api/Product/{id}", (int id) =>
        {
            try
            {
                ProductService.GetProduct(id).Delete();
                return Results.Ok($"Product {id} removed.");
            }
            catch (NoProductException ex)
            {
                return Results.NotFound(ex.Message);
            }
        })
        .WithName("DeleteProduct");  
    }
}
