using DeslocamentoApi.Domain.Entities;
using DeslocamentoApi.Domain.Interfaces.Infrastructure;
using MediatR;

namespace DeslocamentoApi.Application.Condutores.Commands.CriarCondutor
{
    public class CriarCondutorCommand : IRequest<Condutor>
    {
        public string Nome { get; set; }
        public string Email { get; set; }
    }

    public class CriarCondutorCommandHandler : IRequestHandler<CriarCondutorCommand, Condutor>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CriarCondutorCommandHandler(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Condutor> Handle(CriarCondutorCommand request, CancellationToken cancellationToken)
        {
            var condutor = new Condutor(
                request.Nome,
                request.Email);

            var repositoryCondutor = _unitOfWork.GetRepository<Condutor>();

            repositoryCondutor.Add(condutor);

            await _unitOfWork.CommitAsync();

            return condutor;
        }
    }
}
