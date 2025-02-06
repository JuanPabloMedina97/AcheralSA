namespace AcheralSA.Entidades
{
    public class Empleado
    {

        public int IdEmpleado { get; set; }
        public string Nombre {  get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Edad {  get; set; }
        public string Cuil { get; set; }
        public int NumeroLegajo { get; set; }
        public Trabajo Trabajo { get; set; }
        public ServicioMedico ServicioMedico { get; set; }






    }
}
