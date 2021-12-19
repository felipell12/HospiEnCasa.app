using System;
using System.ComponentModel.DataAnnotations;
namespace HospiEnCasa.App.Dominio
{
    public class Medico : Persona
    {
        [Required(ErrorMessage = "ingrese especialidad")]
        public string Especialidad { get; set; }
    }
}