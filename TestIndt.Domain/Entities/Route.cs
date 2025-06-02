using TestIndt.Application.CrossCutting.Enum;

namespace TestIndt.Domain.Entities
{
    public class Route : EntidadeBase
    {
        public Route() : base()
        {
            Ativo = true;
        }

        public string Nome { get; set; }        
        public RotaEnum Origem { get; set; }
        public RotaEnum Destino { get; set; }        
        public decimal Valor { get; set; }
        public bool Ativo { get; set; }
    }
}
