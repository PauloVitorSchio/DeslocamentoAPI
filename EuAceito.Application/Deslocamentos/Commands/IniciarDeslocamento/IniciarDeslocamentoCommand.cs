using DeslocamentoApi.Domain.Entities;
using DeslocamentoApi.Domain.Interfaces.Infrastructure;
using MediatR;

namespace DeslocamentoApi.Application.Deslocamentos.Commands.IniciarDeslocamento
{
    public class IniciarDeslocamentoCommand : IRequest<Deslocamento>
    {
        public int CarroId { get; set; }
        public int CondutorId { get; set; }
        public int ClienteId { get; set; }
        public decimal QuilometragemInicial { get; set; } 
        public string Observacao { get; set; }
    }

    public class IniciarDeslocamentoCommandHandler : IRequestHandler<IniciarDeslocamentoCommand, Deslocamento>
    {
        private readonly IUnitOfWork _unitOfWork;

        public IniciarDeslocamentoCommandHandler(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Deslocamento> Handle(IniciarDeslocamentoCommand request, CancellationToken cancellationToken)
        {
            var deslocamento = new Deslocamento(
                request.CarroId,
                request.ClienteId,
                request.CondutorId,
                request.QuilometragemInicial,
                request.Observacao);

            var deslocamentoRepository = _unitOfWork.GetRepository<Deslocamento>();

            deslocamentoRepository.Add(deslocamento);

            await _unitOfWork.CommitAsync();

            return deslocamento;
        }
    }
}
