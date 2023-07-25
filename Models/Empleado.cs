namespace RegistrodeEmpleado.Models
{
    public class Empleado
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechadeNacimiento { get; set; }
        public DateTime FechadeRegistro { get; set; }

        // Relacion con Beneficios (uno a muchos)
        public int BeneficiosId { get; set; } // Clave foránea para relacionar con Beneficios
        public Beneficios? Beneficios { get; set; } // Propiedad de navegación para acceder al Beneficio relacionado

        // Relacion con Cargos (uno a muchos)
        public int CargosId { get; set; } // Clave foránea para relacionar con Cargos
        public Cargos? Cargo { get; set; } // Propiedad de navegación para acceder al Cargo relacionado

        // Relacion con Habilidades (uno a muchos)
        public int HabilidadesId { get; set; } // Clave foránea para relacionar con Habilidades
        public Habilidades? Habilidades { get; set; } // Propiedad de navegación para acceder a la Habilidad relacionada

        // Relacion con Proyectos (uno a muchos)
        public int ProyectosId { get; set; } // Clave foránea para relacionar con Proyectos
        public Proyectos? Proyectos { get; set; } // Propiedad de navegación para acceder al Proyecto relacionado
    }
}
