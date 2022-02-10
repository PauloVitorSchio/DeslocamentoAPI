using DeslocamentoApi.Domain.Entities;
using DeslocamentoApi.Domain.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DeslocamentoApi.Application.Carros.Queries.GetCarros
{
    public class GetCarrosQuery : IRequest<List<Carro>>
    {
    }

    public class GetCarrosQueryHandler : IRequestHandler<GetCarrosQuery, List<Carro>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCarrosQueryHandler(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<List<Carro>> Handle(GetCarrosQuery request, CancellationToken cancellationToken)
        {
            var repositoryCarro = _unitOfWork.GetRepository<Carro>();

            var carros = await repositoryCarro
                .GetAll()
                .ToListAsync(cancellationToken);

            return carros;
        }
    }
}
