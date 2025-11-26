namespace GestaoEventos.Core.Entities
{
    public class Evento
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public string Local { get; private set; }
        public DateTime DataInicio { get; private set; }
        public int Capacidade { get; private set; }
        public int CategoriaId { get; private set; }
        
        public Categoria Categoria { get; private set; }

        private Evento() { }

        public Evento(string nome, string descricao, string local, DateTime dataInicio, int capacidade, int categoriaId)
        {
            Nome = nome;
            Descricao = descricao;
            Local = local;
            DataInicio = dataInicio;
            Capacidade = capacidade;
            CategoriaId = categoriaId;
        }

        public void Update(string nome, string descricao, string local, DateTime dataInicio, int capacidade, int categoriaId)
        {
            Nome = nome;
            Descricao = descricao;
            Local = local;
            DataInicio = dataInicio;
            Capacidade = capacidade;
            CategoriaId = categoriaId;
        }
    }
}