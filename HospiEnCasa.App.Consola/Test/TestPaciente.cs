using System;
using System.Collections.Generic;
using HospiEnCasa.App.Dominio;
using HospiEnCasa.App.Persistencia;

namespace HospiEnCasa.App.Consola
{
    public class TestPaciente
    {
        private static IRepositorioPaciente _repoPaciente = new RepositorioPaciente(new Persistencia.AppContext());

        public static void AddPaciente()
        {
            var Paciente = new Paciente
            {
                Nombre = "enrique peñas",
                Genero = Enum_Genero.Masculino,
                Ciudad = "medellin",
                FechaNacimiento = new DateTime(1994, 08, 12),
                FamiliarDesignadoId=5,
                EnfermeraId=2,
                MedicoId=3,
                HistoriaId=1
                
            };
            _repoPaciente.AddPaciente(Paciente);
        }
        public static void BuscarPaciente(int IdPaciente)
        {
            var paciente = _repoPaciente.GetPaciente(IdPaciente);
            Console.WriteLine("----------------------------------------------------------------------------------"); Console.WriteLine(paciente.Nombre + " " + paciente.Genero + " " + paciente.Ciudad + " " + paciente.FechaNacimiento);
        }
        public static void UpdatePaciente()
        {
            var paciente = new Paciente
            {
                Id = 2,
                Nombre = "erika",
                Genero = Enum_Genero.Femenino,
                Ciudad = "medellin",
                FechaNacimiento = new DateTime(1994, 04, 12)
            };
            var pacienteModificada = _repoPaciente.UpdatePaciente(paciente);
            Console.WriteLine("----------------------------------------------------------------------------------");
            Console.WriteLine("paciente " + pacienteModificada.Nombre + " modificada con éxito ");
        }
        public static void ListarPacientes()
        {
            IEnumerable<Paciente> listaPacientes = _repoPaciente.GetAllPacientes();
            Console.WriteLine("----------------------------------------------------------------------------------"); Console.WriteLine("Lista de pacientes");
            foreach (Paciente paciente in listaPacientes)
            {
                Console.WriteLine("Id " + paciente.Id + " nombre " + paciente.Nombre + " genero " + paciente.Genero + " ciudad " + paciente.Ciudad + " fecha de naciemiento " + paciente.FechaNacimiento);
            }
        }
        public static void EliminarPaciente(int IdPaciente)
        {
            _repoPaciente.DeletePaciente(IdPaciente);
            Console.WriteLine("----------------------------------------------------------------------------------"); Console.WriteLine("paciente eliminada con éxito");
        }
    }
}