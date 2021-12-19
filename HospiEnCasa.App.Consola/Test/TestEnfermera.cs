using System;
using System.Collections.Generic;
using HospiEnCasa.App.Dominio;
using HospiEnCasa.App.Persistencia;

namespace HospiEnCasa.App.Consola
{
    public class TestEnfermera
    {
        private static IRepositorioEnfermera _repoEnfermera = new RepositorioEnfermera(new Persistencia.AppContext());

        public static void AddEnfermera()
        {
            var Enfermera = new Enfermera
            {
                Nombre = "eduardo",
                Genero = Enum_Genero.Masculino,
                TarjetaProfesional = "primera",
                HorasLaborales = 12
            };
            _repoEnfermera.AddEnfermera(Enfermera);
        }
        public static Enfermera BuscarEnfermera(int IdEnfermera)
        {
            var enfermera = _repoEnfermera.GetEnfermera(IdEnfermera);
            Console.WriteLine("----------------------------------------------------------------------------------");
            Console.WriteLine(enfermera.Nombre + " " + enfermera.Genero + " " + enfermera.TarjetaProfesional + " " + enfermera.HorasLaborales);
            return enfermera;
        }
        public static void UpdateEnfermera()
        {
            var enfermera = new Enfermera
            {
                Id = 7,
                Nombre = "erika",
                Genero = Enum_Genero.Femenino,
                TarjetaProfesional = "segunda",
                HorasLaborales = 7
            };
            var enfermeraModificada = _repoEnfermera.UpdateEnfermera(enfermera);
            Console.WriteLine("----------------------------------------------------------------------------------");
            Console.WriteLine("enfermera " + enfermeraModificada.Nombre + " modificada con éxito ");
        }
        public static void ListarEnfermeras()
        {
            IEnumerable<Enfermera> listaEnfermeras = _repoEnfermera.GetAllEnfermeras();
            Console.WriteLine("----------------------------------------------------------------------------------"); Console.WriteLine("Lista de enfermeras");
            foreach (Enfermera enfermera in listaEnfermeras)
            {
                Console.WriteLine("Id " + enfermera.Id + " nombre " + enfermera.Nombre + " genero " + enfermera.Genero + " TarjetaProfesional " + enfermera.TarjetaProfesional + " HorasLaborales " + enfermera.HorasLaborales);
            }
        }
        public static void EliminarEnfermera(int IdEnfermera)
        {
            _repoEnfermera.DeleteEnfermera(IdEnfermera);
            Console.WriteLine("----------------------------------------------------------------------------------"); Console.WriteLine("enfermera eliminada con éxito");
        }
    }
}