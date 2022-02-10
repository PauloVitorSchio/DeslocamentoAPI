using DeslocamentoApi.Domain.Entities;
using DeslocamentoApi.Domain.Interfaces.Infrastructure;
using MediatR;

namespace DeslocamentoApi.Application.Carros.Commands.CriarCarro
{
    public class CriarCarroCommand : IRequest<Carro>
    {
        public string Placa { get; set; }

        public string Descricao { get; set; }
    }
    public class CriarCarroCommandHandler :
        IRequestHandler<CriarCarroCommand, Carro>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CriarCarroCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Carro> Handle(CriarCarroCommand request,
            CancellationToken cancellationToken)
        {
            var carro = new Carro(
                 request.Placa,
                 request.Descricao);

            var repositoryCarro =
                _unitOfWork.GetRepository<Carro>();

            repositoryCarro.Add(carro);

            await _unitOfWork.CommitAsync();

            return carro;
        }
    }
}
