using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslocamentoApi.Domain.Entities
{
    public class Carro : BaseEntity
    {
        public Carro(string Placa, string Descricao)
        {
            this.Placa = Placa;
            this.Descricao = Descricao;
        }

        private Carro()
        {
            //EF vai usar;
        }
        public string Placa { get; private set; }

        public string Descricao { get; private set; }

        public IReadOnlyCollection<Deslocamento> Deslocamentos =>
            _deslocamentos.AsReadOnly();
        private readonly List<Deslocamento> _deslocamentos = new();
        public string toString()
        {
            return $"Placa: {Placa} Descricao: {Descricao}";
        }

    }
}
