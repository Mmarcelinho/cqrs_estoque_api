namespace CQRS.Estoque.Api.Endpoints.v1;

public class CategoriaEndpoints : ICarterModule
{
    public void AddRoutes
    (IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/categorias");

        group.MapGet("", ObterCategorias)
        .Produces<Categoria>(StatusCodes.Status200OK)
        .Produces<Categoria>(StatusCodes.Status404NotFound)
        .WithName(nameof(ObterCategorias));

        group.MapGet("{id:int}", ObterCategoriaPorId)
        .Produces<Categoria>(StatusCodes.Status200OK)
        .Produces<Categoria>(StatusCodes.Status404NotFound)
        .WithName(nameof(ObterCategoriaPorId));

        group.MapPost("", InserirCategoria)
        .Produces<Categoria>(StatusCodes.Status201Created)
        .Produces<Categoria>(StatusCodes.Status400BadRequest)
        .WithName(nameof(InserirCategoria));

        group.MapPut("{id:int}", AtualizarCategoria)
        .Produces<Categoria>(StatusCodes.Status204NoContent)
        .Produces<Categoria>(StatusCodes.Status400BadRequest)
        .WithName(nameof(AtualizarCategoria));

        group.MapDelete("{id:int}", RemoverCategoria)
        .Produces<Categoria>(StatusCodes.Status204NoContent)
        .Produces<Categoria>(StatusCodes.Status400BadRequest)
        .WithName(nameof(RemoverCategoria));
    }

    private static async Task<IResult> ObterCategorias(IMediator _mediator)
    {
        var query = new GetCategoriasQuery();
        var categorias = await _mediator.Send(query);
        return Results.Ok(categorias);
    }

    private static async Task<IResult> ObterCategoriaPorId(IMediator _mediator, int id)
    {
        var query = new GetCategoriaByIdQuery { Id = id };
        var categoria = await _mediator.Send(query);

        return Results.Ok(categoria);
    }

    public static async Task<IResult> InserirCategoria(IMediator _mediator, CreateCategoriaCommand command)
    {
        var categoria = await _mediator.Send(command);
        int id = categoria.Id;

        return Results.CreatedAtRoute(nameof(ObterCategoriaPorId), new { id = id }, id);
    }

    private static async Task<IResult> AtualizarCategoria(IMediator _mediator, UpdateCategoriaCommand command, int id)
    {
        command.Id = id;
         await _mediator.Send(command);

        return Results.NoContent();
    }

    private static async Task<IResult> RemoverCategoria(IMediator _mediator, int id)
    {
        var command = new DeleteCategoriaCommand { Id = id };
        await _mediator.Send(command);

        return Results.NoContent();
    }
}
