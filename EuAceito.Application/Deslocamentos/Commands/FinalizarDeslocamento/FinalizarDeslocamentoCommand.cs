using DeslocamentoApi.Domain.Entities;
using DeslocamentoApi.Domain.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DeslocamentoApi.Application.Deslocamentos.Commands.FinalizarDeslocamento
{
    public class FinalizarDeslocamentoCommand : IRequest
    {
        public int Id { get; set; }
        public decimal QuilometragemFinal { get; set; }
    }

    public class FinalizarDeslocamentoCommandHandler : IRequestHandler<FinalizarDeslocamentoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public FinalizarDeslocamentoCommandHandler(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(FinalizarDeslocamentoCommand request, CancellationToken cancellationToken)
        {
            var repositoryDeslocamento = _unitOfWork.GetRepository<Deslocamento>();

            var deslocamento = await repositoryDeslocamento.FindBy(d => d.Id == request.Id)
                .FirstAsync(cancellationToken);

            deslocamento.FinalizarDeslocamento(request.QuilometragemFinal);

            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }
    }
}
