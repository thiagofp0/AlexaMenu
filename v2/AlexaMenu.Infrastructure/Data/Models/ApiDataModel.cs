namespace AlexaMenu.Infrastructure.Data.Models
{
    public class ApiDataObject
    {
        public int refeicao_id { get; set; } = 0;
        public string refeicao { get; set; } = string.Empty;
        public string Refeitorio { get; set; } = string.Empty;
        public DateTime horario_inicio { get; set; }
        public DateTime Horario_inicio_finaldeSemana { get; set; }
        public DateTime horario_fim { get; set; }
        public DateTime Horario_fim_finaldeSemana { get; set; }
        public int composicao_id { get; set; }
        public int codigorefeitorio { get; set; }
        public DateTime data { get; set; }
        public string obs_cardapio { get; set; } = string.Empty;
        public string composicao { get; set; } = string.Empty;
        public string categoria { get; set; } = string.Empty;
        public string obs_composicao { get; set; } = string.Empty;
    }
}
