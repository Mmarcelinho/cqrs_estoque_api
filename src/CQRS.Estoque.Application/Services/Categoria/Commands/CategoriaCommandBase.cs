namespace CQRS.Estoque.Application.Services.CategoriaCommand;

    public class CategoriaCommandBase : IRequest<Categoria>
    {
        public string Titulo { get; set; }
    }
