using System.Collections.Generic;
using System.Linq;
using HospiEnCasa.App.Dominio;
namespace HospiEnCasa.App.Persistencia
{
    public class RepositorioSignoVital : IRepositorioSignoVital
    {
        private readonly AppContext _appContext;
        public RepositorioSignoVital(AppContext appContext)
        {
            _appContext = appContext;
        }
        IEnumerable<SignoVital> IRepositorioSignoVital.GetAllSignoVitales()
        {
            return _appContext.signosvitales;
        }
        SignoVital IRepositorioSignoVital.AddSignoVital(SignoVital SignoVital)
        {
            var SignoVitalAdicionada = _appContext.signosvitales.Add(SignoVital);
            _appContext.SaveChanges();
            return SignoVitalAdicionada.Entity;
        }

        SignoVital IRepositorioSignoVital.UpdateSignoVital(SignoVital SignoVital)
        {
            var SignoVitalEncontrado = _appContext.signosvitales.FirstOrDefault(E => E.Id == SignoVital.Id);
            if (SignoVitalEncontrado != null)
            {
                SignoVitalEncontrado.FechaHora = SignoVital.FechaHora;
                SignoVitalEncontrado.Valor = SignoVital.Valor;
                SignoVitalEncontrado.Signo = SignoVital.Signo;
                SignoVitalEncontrado.HistoriaId = SignoVital.HistoriaId;
                _appContext.SaveChanges();
            }
            return SignoVitalEncontrado;
        }

        void IRepositorioSignoVital.DeleteSignoVital(int idSignoVital)
        {
            var SignoVitalEncontrado = _appContext.signosvitales.FirstOrDefault(E => E.Id == idSignoVital);
            if (SignoVitalEncontrado == null)
                return;
            _appContext.signosvitales.Remove(SignoVitalEncontrado);
            _appContext.SaveChanges();
        }

        SignoVital IRepositorioSignoVital.GetSignoVital(int idSignoVital)
        {
            return _appContext.signosvitales.FirstOrDefault(E => E.Id == idSignoVital);
        }
    }
}
