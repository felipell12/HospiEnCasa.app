using System;
using System.Collections.Generic;
namespace HospiEnCasa.App.Dominio
{ 
    public class Paciente : Persona
    {
        public string Ciudad { get; set; }

        public DateTime FechaNacimiento { get; set; }
        
        public int FamiliarDesignadoId { get; set; }
        
        public FamiliarDesignado FamiliarDesignado { get; set; }

        public int EnfermeraId { get; set; }

        public Enfermera Enfermera { get; set; }

        public int MedicoId { get; set; }
       
        public Medico Medico { get; set; }

        public int HistoriaId { get; set; }
        
        public Historia Historia { get; set; }


    }
}
