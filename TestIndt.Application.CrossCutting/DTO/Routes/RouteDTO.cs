namespace TestIndt.Application.CrossCutting.DTO.Routes
{
    public class RouteDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public DateTime? DataCadastro { get; set; }
        public bool Ativo { get; set; }
    }
}
