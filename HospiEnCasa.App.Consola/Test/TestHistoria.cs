using System;
using System.Collections.Generic;
using HospiEnCasa.App.Dominio;
using HospiEnCasa.App.Persistencia;

namespace HospiEnCasa.App.Consola
{
    public class TestHistoria
    {
        private static IRepositorioHistoria _repoHistoria = new RepositorioHistoria(new Persistencia.AppContext());

        public static void AddHistoria()
        {
            var Historia = new Historia
            {
            };
            _repoHistoria.AddHistoria(Historia);
        }
        public static void BuscarHistoria(int IdHistoria)
        {
            var historia = _repoHistoria.GetHistoria(IdHistoria);
            Console.WriteLine("----------------------------------------------------------------------------------"); 
        }
        public static void UpdateHistoria()
        {
            var historia = new Historia
            {
                Id = 1,
            };
            var historiaModificada = _repoHistoria.UpdateHistoria(historia);
            Console.WriteLine("----------------------------------------------------------------------------------");
            Console.WriteLine("historia modificada con éxito ");
        }
        public static void ListarHistorias()
        {
            IEnumerable<Historia> listaHistorias = _repoHistoria.GetAllHistorias();
            Console.WriteLine("----------------------------------------------------------------------------------"); Console.WriteLine("Lista de historias");
            foreach (Historia historia in listaHistorias)
            {
                Console.WriteLine("Id " + historia.Id );
            }
        }
        public static void EliminarHistoria(int IdHistoria)
        {
            _repoHistoria.DeleteHistoria(IdHistoria);
            Console.WriteLine("----------------------------------------------------------------------------------"); Console.WriteLine("historia eliminada con éxito");
        }
    }
}