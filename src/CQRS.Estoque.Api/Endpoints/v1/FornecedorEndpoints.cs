namespace CQRS.Estoque.Api.Endpoints.v1;

public class FornecedorEndpoints : ICarterModule
{
    public void AddRoutes
    (IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/fornecedores");

        group.MapGet("", ObterFornecedores)
        .Produces<Fornecedor>(StatusCodes.Status200OK)
        .Produces<Fornecedor>(StatusCodes.Status404NotFound)
        .WithName(nameof(ObterFornecedores));

        group.MapGet("{id:int}", ObterFornecedorPorId)
        .Produces<Fornecedor>(StatusCodes.Status200OK)
        .Produces<Fornecedor>(StatusCodes.Status404NotFound)
        .WithName(nameof(ObterFornecedorPorId));

        group.MapPost("", InserirFornecedor)
        .Produces<Fornecedor>(StatusCodes.Status201Created)
        .Produces<Fornecedor>(StatusCodes.Status400BadRequest)
        .WithName(nameof(InserirFornecedor));

        group.MapPut("{id:int}", AtualizarFornecedor)
        .Produces<Fornecedor>(StatusCodes.Status204NoContent)
        .Produces<Fornecedor>(StatusCodes.Status400BadRequest)
        .WithName(nameof(AtualizarFornecedor));

        group.MapDelete("{id:int}", RemoverFornecedor)
        .Produces<Fornecedor>(StatusCodes.Status204NoContent)
        .Produces<Fornecedor>(StatusCodes.Status400BadRequest)
        .WithName(nameof(RemoverFornecedor));
    }

    private static async Task<IResult> ObterFornecedores(IMediator _mediator)
    {
        var query = new GetFornecedoresQuery();
        var fornecedores = await _mediator.Send(query);
        return Results.Ok(fornecedores);
    }

    private static async Task<IResult> ObterFornecedorPorId(IMediator _mediator, int id)
    {
        var query = new GetFornecedorByIdQuery { Id = id };
        var fornecedor = await _mediator.Send(query);

        return Results.Ok(fornecedor);
    }

    public static async Task<IResult> InserirFornecedor(IMediator _mediator, CreateFornecedorCommand command)
    {
        var fornecedor = await _mediator.Send(command);
        int id = fornecedor.Id;

        return Results.CreatedAtRoute(nameof(ObterFornecedorPorId), new { id = id }, id);
    }

    private static async Task<IResult> AtualizarFornecedor(IMediator _mediator, UpdateFornecedorCommand command, int id)
    {
        command.Id = id;
        await _mediator.Send(command);

        return Results.NoContent();
    }

    private static async Task<IResult> RemoverFornecedor(IMediator _mediator, int id)
    {
        var command = new DeleteFornecedorCommand { Id = id };
        await _mediator.Send(command);

        return Results.NoContent();
    }

}
