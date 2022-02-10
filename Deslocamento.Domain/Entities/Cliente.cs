namespace DeslocamentoApi.Domain.Entities
{
    public class Cliente : BaseEntity
    {
        public Cliente(string Cpf, string Nome)
        {
            this.Cpf = Cpf;
            this.Nome = Nome;
        }
        private Cliente()
        {
            //Aqui, EF, pode usar
        }
        public string Cpf { get; private set; }

        public string Nome { get; private set; }

        public IReadOnlyCollection<Deslocamento> Deslocamentos =>
            _deslocamentos.AsReadOnly();
        private readonly List<Deslocamento> _deslocamentos = new();

        public string toString()
        {
            return $"Cpf {Cpf} Nome {Nome}";
        }
    }
}
