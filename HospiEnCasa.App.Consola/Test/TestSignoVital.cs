using System;
using System.Collections.Generic;
using HospiEnCasa.App.Dominio;
using HospiEnCasa.App.Persistencia;

namespace HospiEnCasa.App.Consola
{
    public class TestSignoVital
    {
        private static IRepositorioSignoVital _repoSignoVital = new RepositorioSignoVital(new Persistencia.AppContext());

        public static void AddSignoVital()
        {
            var SignoVital = new SignoVital
            {
                FechaHora = new DateTime(2021, 04, 12), 
                Valor=15,
                Signo= Enum_TipoSigno.FrecuenciaRespiratoria,
                HistoriaId=2
            };
            _repoSignoVital.AddSignoVital(SignoVital);
        }
        public static void BuscarSignoVital(int IdSignoVital)
        {
            var signovital = _repoSignoVital.GetSignoVital(IdSignoVital);
            Console.WriteLine("----------------------------------------------------------------------------------"); 
            Console.WriteLine("fecha y hora "+signovital.FechaHora+" valor "+ signovital.Valor+" signo "+signovital.Signo+" Historia id "+signovital.HistoriaId);
        }
        public static void UpdateSignoVital()
        {
            var signovital = new SignoVital
            {
                Id = 1,
                FechaHora = new DateTime(2020, 04, 12), 
                Valor=150,
                Signo= Enum_TipoSigno.TemperaturaCorporal,
                HistoriaId=1 
            };
            var signovitalModificada = _repoSignoVital.UpdateSignoVital(signovital);
            Console.WriteLine("----------------------------------------------------------------------------------");
            Console.WriteLine("signovital " + signovitalModificada.Id + " modificada con éxito ");
        }
        public static void ListarSignoVitals()
        {
            IEnumerable<SignoVital> listaSignoVitals = _repoSignoVital.GetAllSignoVitales();
            Console.WriteLine("----------------------------------------------------------------------------------"); Console.WriteLine("Lista de signovitals");
            foreach (SignoVital signovital in listaSignoVitals)
            {
                Console.WriteLine("Id " + signovital.Id +" fecha y hora "+signovital.FechaHora+" valor "+ signovital.Valor+" signo "+signovital.Signo+" Historia id "+signovital.HistoriaId);
            }
        }
        public static void EliminarSignoVital(int IdSignoVital)
        {
            _repoSignoVital.DeleteSignoVital(IdSignoVital);
            Console.WriteLine("----------------------------------------------------------------------------------"); Console.WriteLine("signovital eliminada con éxito");
        }
    }
}