using DeslocamentoApi.Domain.Entities;
using DeslocamentoApi.Domain.Interfaces.Infrastructure;
using MediatR;

namespace DeslocamentoApi.Application.Clientes.Commands.CriarCliente
{
    public class CriarClienteCommand : IRequest<Cliente>
    {
        public string Cpf { get; set; }
        public string Nome { get; set; }
    }

    public class CriarClienteCommandHandler : IRequestHandler<CriarClienteCommand, Cliente>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CriarClienteCommandHandler(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Cliente> Handle(CriarClienteCommand request, CancellationToken cancellationToken)
        {
            var cliente = new Cliente(
                request.Nome,
                request.Cpf);

            var repositoryCliente = _unitOfWork.GetRepository<Cliente>();

            repositoryCliente.Add(cliente);

            await _unitOfWork.CommitAsync();

            return cliente;
        }
    }
}
