namespace CQRS.Estoque.Api.Endpoints.v1;

public class ProdutoEndpoints : ICarterModule
{
    public void AddRoutes
    (IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/produtos");

        group.MapGet("", ObterProdutos)
        .Produces<Produto>(StatusCodes.Status200OK)
        .Produces<Produto>(StatusCodes.Status404NotFound)
        .WithName(nameof(ObterProdutos));

        group.MapGet("{id:int}", ObterProdutoPorId)
        .Produces<Produto>(StatusCodes.Status200OK)
        .Produces<Produto>(StatusCodes.Status404NotFound)
        .WithName(nameof(ObterProdutoPorId));

        group.MapPost("", InserirProduto)
        .Produces<Produto>(StatusCodes.Status201Created)
        .Produces<Produto>(StatusCodes.Status400BadRequest)
        .WithName(nameof(InserirProduto));

        group.MapPut("{id:int}", AtualizarProduto)
        .Produces<Produto>(StatusCodes.Status204NoContent)
        .Produces<Produto>(StatusCodes.Status400BadRequest)
        .WithName(nameof(AtualizarProduto));

        group.MapDelete("{id:int}", RemoverProduto)
        .Produces<Produto>(StatusCodes.Status204NoContent)
        .Produces<Produto>(StatusCodes.Status400BadRequest)
        .WithName(nameof(RemoverProduto));
    }

    private static async Task<IResult> ObterProdutos(IMediator _mediator)
    {
        var query = new GetProdutosQuery();
        var produtos = await _mediator.Send(query);
        return Results.Ok(produtos);
    }

    private static async Task<IResult> ObterProdutoPorId(IMediator _mediator, int id)
    {
        var query = new GetProdutoByIdQuery { Id = id };
        var produto = await _mediator.Send(query);

        return Results.Ok(produto);
    }

    public static async Task<IResult> InserirProduto(IMediator _mediator, CreateProdutoCommand command)
    {
        var produtoId = await _mediator.Send(command);
        int id = produtoId.Id;

        return Results.CreatedAtRoute(nameof(ObterProdutoPorId), new { id = id }, id);
    }

    private static async Task<IResult> AtualizarProduto(IMediator _mediator, UpdateProdutoCommand command, int id)
    {
        command.Id = id;
        await _mediator.Send(command);

        return Results.NoContent();
    }

    private static async Task<IResult> RemoverProduto(IMediator _mediator, int id)
    {
        var command = new DeleteProdutoCommand { Id = id };
        await _mediator.Send(command);

        return Results.NoContent();
    }

}
