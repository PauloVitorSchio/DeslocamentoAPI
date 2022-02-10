using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslocamentoApi.Domain.Entities
{
    public class Condutor : BaseEntity
    {
        public Condutor(string Nome, string Email)
        {
            this.Nome = Nome;
            this.Email = Email;
        }
        private Condutor()
        {
            //Aproveita EF
        }
        public string Nome { get; private set; }

        public string Email { get; private set; }

        public IReadOnlyCollection<Deslocamento> Deslocamentos =>
            _deslocamentos.AsReadOnly();
        private readonly List<Deslocamento> _deslocamentos = new();

        public string toString()
        {
            return $"Nome {Nome} Email {Email}";
        }
    }
}
