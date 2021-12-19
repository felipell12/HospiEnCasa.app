using System;
using System.Collections.Generic;
using HospiEnCasa.App.Dominio;
using HospiEnCasa.App.Persistencia;

namespace HospiEnCasa.App.Consola
{
    public class TestMedico
    {
        private static IRepositorioMedico _repoMedico = new RepositorioMedico(new Persistencia.AppContext());

        public static void AddMedico()
        {
            var Medico = new Medico
            {
                Nombre = "eduardo",
                Genero = Enum_Genero.Masculino,
                Especialidad = "cardiologo",
            };
            _repoMedico.AddMedico(Medico);
        }
        public static Medico BuscarMedico(int IdMedico)
        {
            var medico = _repoMedico.GetMedico(IdMedico);
            Console.WriteLine("----------------------------------------------------------------------------------");
            Console.WriteLine(medico.Nombre + " " + medico.Genero + " " + medico.Especialidad);
            return medico;
        }
        public static void UpdateMedico()
        {
            var medico = new Medico
            {
                Id = 8,
                Nombre = "erika",
                Genero = Enum_Genero.Femenino,
                Especialidad = "uncologo",
            };
            var medicoModificada = _repoMedico.UpdateMedico(medico);
            Console.WriteLine("----------------------------------------------------------------------------------");
            Console.WriteLine("medico " + medicoModificada.Nombre + " modificada con éxito ");
        }
        public static void ListarMedicos()
        {
            IEnumerable<Medico> listaMedicos = _repoMedico.GetAllMedicos();
            Console.WriteLine("----------------------------------------------------------------------------------"); Console.WriteLine("Lista de medicos");
            foreach (Medico medico in listaMedicos)
            {
                Console.WriteLine("Id " + medico.Id + " nombre " + medico.Nombre + " genero " + medico.Genero + " Especialidad " + medico.Especialidad);
            }
        }
        public static void EliminarMedico(int IdMedico)
        {
            _repoMedico.DeleteMedico(IdMedico);
            Console.WriteLine("----------------------------------------------------------------------------------"); Console.WriteLine("medico eliminada con éxito");
        }
    }
}