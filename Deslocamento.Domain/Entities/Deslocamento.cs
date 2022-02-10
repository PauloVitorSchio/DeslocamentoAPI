namespace DeslocamentoApi.Domain.Entities
{
    public class Deslocamento : BaseEntity
    {
        public int CarroId { get; private set; }

        public int ClienteId { get; private set; }

        public int CondutorId { get; private set; }

        public DateTime DataHoraInicio { get; private set; }

        public DateTime? DataHoraFinal { get; private set; }

        public decimal QuilometragemInicial { get; private set; }

        public decimal QuilometragemFinal { get; private set; }

        public string Observacao { get; private set; }

        public Carro Carro { get; private set; }
        public Cliente Cliente { get; private set; }
        public Condutor Condutor { get; private set; }

        public Deslocamento(int CarroId, int ClienteId, int CondutorId,
            decimal QuilometragemInicial, string Observacao)
        {
            this.CarroId = CarroId;
            this.ClienteId = ClienteId;
            this.CondutorId = CondutorId;
            this.QuilometragemInicial = QuilometragemInicial;
            this.DataHoraInicio = DateTime.Now;
            this.Observacao = Observacao;
        }

        public void FinalizarDeslocamento(decimal QuilometragemFinal)
        {
            this.DataHoraFinal = DateTime.Now;
            this.QuilometragemFinal = QuilometragemFinal;
        }
    }
}
