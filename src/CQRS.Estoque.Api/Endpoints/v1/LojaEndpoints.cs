namespace CQRS.Estoque.Api.Endpoints.v1;

public class LojaEndpoints : ICarterModule
{
    public void AddRoutes
    (IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/lojas");

        group.MapGet("", ObterLojas)
        .Produces<Loja>(StatusCodes.Status200OK)
        .Produces<Loja>(StatusCodes.Status404NotFound)
        .WithName(nameof(ObterLojas));

        group.MapGet("{id:int}", ObterLojaPorId)
        .Produces<Loja>(StatusCodes.Status200OK)
        .Produces<Loja>(StatusCodes.Status404NotFound)
        .WithName(nameof(ObterLojaPorId));

        group.MapPost("", InserirLoja)
        .Produces<Loja>(StatusCodes.Status201Created)
        .Produces<Loja>(StatusCodes.Status400BadRequest)
        .WithName(nameof(InserirLoja));

        group.MapPut("{id:int}", AtualizarLoja)
        .Produces<Loja>(StatusCodes.Status204NoContent)
        .Produces<Loja>(StatusCodes.Status400BadRequest)
        .WithName(nameof(AtualizarLoja));

        group.MapDelete("{id:int}", RemoverLoja)
        .Produces<Loja>(StatusCodes.Status204NoContent)
        .Produces<Loja>(StatusCodes.Status400BadRequest)
        .WithName(nameof(RemoverLoja));
    }

    private static async Task<IResult> ObterLojas(IMediator _mediator)
    {
        var query = new GetLojasQuery();
        var lojas = await _mediator.Send(query);
        return Results.Ok(lojas);
    }

    private static async Task<IResult> ObterLojaPorId(IMediator _mediator, int id)
    {
        var query = new GetLojaByIdQuery { Id = id };
        var loja = await _mediator.Send(query);

        return Results.Ok(loja);
    }

    public static async Task<IResult> InserirLoja(IMediator _mediator, CreateLojaCommand command)
    {
        var lojaId = await _mediator.Send(command);
        int id = lojaId.Id;

        return Results.CreatedAtRoute(nameof(ObterLojaPorId), new { id = id }, id );
    }

    private static async Task<IResult> AtualizarLoja(IMediator _mediator, UpdateLojaCommand command, int id)
    {
        command.Id = id;
        await _mediator.Send(command);

        return Results.NoContent();
    }

    private static async Task<IResult> RemoverLoja(IMediator _mediator, int id)
    {
        var command = new DeleteLojaCommand { Id = id };
        await _mediator.Send(command);

        return Results.NoContent();
    }

}
