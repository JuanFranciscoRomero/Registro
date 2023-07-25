namespace RegistrodeEmpleado.Models
{
    public class Habilidades
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        // Relacion con empleados (uno a muchos)
        public ICollection<Empleado>? Empleados { get; set; }
    }
}
