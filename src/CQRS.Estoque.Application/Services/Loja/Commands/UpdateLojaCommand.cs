namespace CQRS.Estoque.Application.Services.LojaCommand;

public class UpdateLojaCommand : IRequest
{
    public int Id { get; set; }

    public string Nome { get; set; }

    public string Endereco { get; set; }

    public int Numero { get; set; }

    public string Bairro { get; set; }

    public string Telefone { get; set; }

    public string Cnpj { get; set; }

    public class UpdateLojaCommandHandler : IRequestHandler<UpdateLojaCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateLojaCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task Handle(UpdateLojaCommand request, CancellationToken cancellationToken)
        {
            var existingLoja = await _unitOfWork.LojaRepository.ObterPorIdAsync(request.Id);

            existingLoja.Atualizar(request.Nome, request.Endereco, request.Numero, request.Bairro, request.Telefone, request.Cnpj);

            _unitOfWork.LojaRepository.AtualizarAsync(existingLoja);
            await _unitOfWork.CommitAsync();
        }
    }

}