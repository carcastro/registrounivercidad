namespace RegistroSeccion.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Alumno")]
    public partial class Alumno
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Alumno()
        {
            Seccion = new HashSet<Seccion>();
        }

        [Key]
        public int id_alu { get; set; }

        [Required]
        [StringLength(8)]
        public string dni_alu { get; set; }

        [Required]
        [StringLength(50)]
        public string nombre_alu { get; set; }

        [Required]
        [StringLength(100)]
        public string apellidos_alu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Seccion> Seccion { get; set; }

        //-----------------MÉTODOS----------------------------
        public List<Alumno> listar()
        {
            var alumnos = new List<Alumno>();
            string cadena = "SELECT * FROM ALUMNO";
            try
            {
                using ( var contenedor = new Model1())
                {
                    alumnos = contenedor.Database.SqlQuery<Alumno>(cadena).ToList();
                }
            }
            catch (Exception)
            {
                //throw;
            }
            return alumnos;
        }

        public Boolean Insertar(string dni, string nom, string ape)
        {
            bool estado = false;
            string cadena = "'" + dni + "',";
            cadena = cadena + "'" + nom + "',";
            cadena = cadena + "'" + ape + "'";
            try
            {
                using (var cnx = new Model1())
                {
                    int r = cnx.Database.ExecuteSqlCommand("INSERT INTO ALUMNO VALUES (" + cadena + ")");
                    if (r == 1 )
                    {
                        estado = true;
                    }
                }
            }
            catch (Exception)
            {
                estado = false;
                //throw;
            }
            return estado;

        }
    }
}
