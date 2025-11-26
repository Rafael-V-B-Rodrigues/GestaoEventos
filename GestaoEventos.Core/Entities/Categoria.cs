namespace GestaoEventos.Core.Entities
{
    public class Categoria
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public ICollection<Evento> Eventos { get; private set; }

        private Categoria() { }

        public Categoria(string nome)
        {
            Nome = nome;
            Eventos = new List<Evento>();
        }

        public void Update(string nome)
        {
            Nome = nome;
        }
    }
}