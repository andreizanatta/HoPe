namespace HoPe.API.Models
{
    public class CreateFuncionarioModel
    {
        public CreateFuncionarioModel(int id, string nome, int description)
        {
            Id = id;
            Nome = nome;
            Description = description;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public int Description { get; set; }
    }
}
