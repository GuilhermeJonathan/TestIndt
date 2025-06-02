using TestIndt.Application.CrossCutting.Enum;

namespace TestIndt.Application.CrossCutting.DTO.Routes
{
    public class RouteDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public string Origem { get; set; }
        public string Destino { get; set; }
        public decimal Valor { get; set; }
        public bool Ativo { get; set; }
    }
}
