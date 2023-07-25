namespace RegistrodeEmpleado.Models
{
    public class Cargos
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Salario { get; set; }

        // Relacion con empleados (uno a muchos)
        public ICollection<Empleado>? Empleados { get; set; }
    }
}
