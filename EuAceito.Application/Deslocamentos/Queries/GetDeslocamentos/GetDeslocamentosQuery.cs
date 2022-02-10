using DeslocamentoApi.Domain.Entities;
using DeslocamentoApi.Domain.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DeslocamentoApi.Application.Deslocamentos.Queries.GetDeslocamentos
{
    public class GetDeslocamentosQuery : IRequest<List<Deslocamento>>
    {
    }

    public class GetDeslocamentosQueryHandler : IRequestHandler<GetDeslocamentosQuery, List<Deslocamento>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetDeslocamentosQueryHandler(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<List<Deslocamento>> Handle(GetDeslocamentosQuery request, CancellationToken cancellationToken)
        {
            var deslocamentoRepository = _unitOfWork.GetRepository<Deslocamento>();

            var deslocamentos = await deslocamentoRepository
                .GetAll()
                .ToListAsync(cancellationToken);

            return deslocamentos;
        }
    }
}
