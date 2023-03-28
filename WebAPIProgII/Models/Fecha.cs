namespace WebAPIProgII.Models
{
    public class Fecha
    {
        public int Dia { get; set; }
        public int Mes { get; set; }
        public int Anio { get; set; }
        public string DiaSemana { get; set; }
        public Fecha()
        {
            Dia = DateTime.Now.Day;
            Mes = DateTime.Now.Month;
            Anio=DateTime.Now.Year;
            DiaSemana = DateTime.Now.DayOfWeek.ToString();
        }
    }
}
