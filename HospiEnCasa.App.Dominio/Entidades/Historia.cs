using System;
using System.Collections.Generic;

namespace HospiEnCasa.App.Dominio
{
    public class Historia
    {
        public int Id { get; set; }
        public List<SignoVital> SignosVitales { get; set; }        
        public List<SugerenciaCuidado> Sugerencias { get; set; }
    }
}