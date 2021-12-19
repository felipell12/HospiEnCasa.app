using System;
using System.Collections.Generic;
using HospiEnCasa.App.Dominio;
using HospiEnCasa.App.Persistencia;

namespace HospiEnCasa.App.Consola
{
    public class TestSugerenciaCuidado
    {
        private static IRepositorioSugerenciaCuidado _repoSugerenciaCuidado = new RepositorioSugerenciaCuidado(new Persistencia.AppContext());

        public static void AddSugerenciaCuidado()
        { 
            DateTime fechahora = new DateTime(2021, 6, 1, 6, 34, 53);
            var SugerenciaCuidado = new SugerenciaCuidado
            {
                FechaHora = fechahora,
                Descripcion = "mi sugerencia",
                HistoriaId=1
            };
            _repoSugerenciaCuidado.AddSugerenciaCuidado(SugerenciaCuidado);
        }
        public static void BuscarSugerenciaCuidado(int IdSugerenciaCuidado)
        {
            var sugerenciacuidado = _repoSugerenciaCuidado.GetSugerenciaCuidado(IdSugerenciaCuidado);
            Console.WriteLine("----------------------------------------------------------------------------------");
            Console.WriteLine(sugerenciacuidado.FechaHora + " " + sugerenciacuidado.Descripcion+" "+sugerenciacuidado.HistoriaId);
        }
        public static void UpdateSugerenciaCuidado()
        {
            DateTime fechahora = new DateTime(2016, 6, 1, 6, 34, 53);
            var sugerenciacuidado = new SugerenciaCuidado
            {
                Id = 2,
                FechaHora = fechahora,
                Descripcion = "sugegierp",
                HistoriaId=1
            };
            var sugerenciacuidadoModificada = _repoSugerenciaCuidado.UpdateSugerenciaCuidado(sugerenciacuidado);
            Console.WriteLine("----------------------------------------------------------------------------------");
            Console.WriteLine("sugerenciacuidado " + sugerenciacuidadoModificada.Descripcion + " modificada con éxito ");
        }
        public static void ListarSugerenciaCuidados()
        {
            IEnumerable<SugerenciaCuidado> listaSugerenciaCuidados = _repoSugerenciaCuidado.GetAllSugerenciaCuidados();
            Console.WriteLine("----------------------------------------------------------------------------------"); Console.WriteLine("Lista de sugerenciacuidados");
            foreach (SugerenciaCuidado sugerenciacuidado in listaSugerenciaCuidados)
            {
                Console.WriteLine("Id " + sugerenciacuidado.Id + " Descripcion " + sugerenciacuidado.Descripcion + " FechaHora " + sugerenciacuidado.FechaHora+" Historia id "+sugerenciacuidado.HistoriaId);
            }
        }
        public static void EliminarSugerenciaCuidado(int IdSugerenciaCuidado)
        {
            _repoSugerenciaCuidado.DeleteSugerenciaCuidado(IdSugerenciaCuidado);
            Console.WriteLine("----------------------------------------------------------------------------------"); Console.WriteLine("sugerenciacuidado eliminada con éxito");
        }
    }
}