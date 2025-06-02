namespace TestIndt.Application.CrossCutting.DTO.Routes
{
    public class RouteResumeDTO
    {
        public int Id { get; set; }
        public string Origem { get; set; }
        public string Destino { get; set; }
        public string OrigemDestino => $"{Origem} - {Destino}";
    }
}
