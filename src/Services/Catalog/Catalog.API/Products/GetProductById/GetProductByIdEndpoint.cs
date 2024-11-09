

namespace Catalog.API.Products.GetProductById
{
    //public record GetProductByIdRequest();
    public record GetProductByIdResponse(Product Product);
    public class GetProductByIdEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products/{id}", async (Guid id, ISender sender) =>
            {
                var result  = await sender.Send(new GetProductByIdQuery(id));
                var product = result.Adapt<GetProductByIdResponse>();
                return Results.Ok(product);
            }).WithName("GetProductById")
        .Produces<GetProductByIdResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Product By Id")
        .WithDescription("Get Product By Id");
        }
    }
}
