namespace ShopAppWebApi.Controllers;

public static class ProductTypeEndpointsClass
{
    public static void MapProductTypeEndpoints (this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/ProductType", () =>
        {
            return new [] {  ProductTypeService.GetProductTypes() };
        })
        .WithName("GetAllProductTypes");

        routes.MapGet("/api/ProductType/{id}", (int id) =>
        {
           return ProductTypeService.GetProductType(id);
        })
        .WithName("GetProductTypeById");

        routes.MapPut("/api/ProductType/{id}", (int id, ProductType input) =>
        {
            try
            {
                ProductType model = ProductTypeService.GetProductType(id);
                model.Update(input);
                return Results.Ok(model);
            }
            catch (NoProductTypeException ex)
            {
                return Results.NotFound(ex.Message);
            }
        })
        .WithName("UpdateProductType");

        routes.MapPost("/api/ProductType/", (ProductType model) =>
        {
            try
            {
                model.Save();
                return Results.Created($"/ProductTypes/{model.Id}", model);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }

        })
        .WithName("CreateProductType");

        routes.MapDelete("/api/ProductType/{id}", (int id) =>
        {
            try
            {
                ProductTypeService.GetProductType(id).Delete();
                return Results.Ok($"ProductType {id} removed.");
            }
            catch (NoProductTypeException ex)
            {
                return Results.NotFound(ex.Message);
            }
        })
        .WithName("DeleteProductType");  
    }
}
