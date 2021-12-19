using System;
using System.ComponentModel.DataAnnotations;
namespace HospiEnCasa.App.Dominio
{
    public class Persona
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "ingrese nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "ingrese genero")]
        public Enum_Genero Genero { set; get; }
    }
}
