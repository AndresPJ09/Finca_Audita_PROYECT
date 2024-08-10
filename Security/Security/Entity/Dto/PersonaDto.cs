namespace Entity.Dto
{
    public class PersonaDto
    {
        public int Id { get; set; }
        public string primer_nombre { get; set; }
        public string segundo_nombre { get; set; }
        public string correo_electronico { get; set; }
        public DateTime fecha_de_nacimiento { get; set; }
        public string genero { get; set; }
        public string direccion { get; set; }
        public string tipo_de_documento { get; set; }
        public string documento { get; set; }
        public int Ciudad_id { get; set; }
        public Boolean State { get; set; }

    }
}
