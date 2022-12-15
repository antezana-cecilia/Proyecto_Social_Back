namespace BE_CRUDDonacion.Models
{
    public class Donacion
    {
            public int id { get; set; }
            public string nombre { get; set; }
            public string apellido { get; set; }
            public string direccion { get; set; }
            public string email { get; set; }
            public int telefono { get; set; }
            public string anonimo { get; set; }
            public string estado { get; set; }
            public string nombre_orden { get; set; }
            public int cantidad { get; set; }
            public string fecha_recojo { get; set; }
            public string contacto { get; set; }
            public string tipo { get; set; }
            public DateTime fecha_creacion { get; set; }

    }
}