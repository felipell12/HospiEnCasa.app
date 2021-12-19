using System.Collections.Generic;
using System.Linq;
using HospiEnCasa.App.Dominio;
namespace HospiEnCasa.App.Persistencia
{
    public class RepositorioHistoria : IRepositorioHistoria
    {
        private readonly AppContext _appContext;
        public RepositorioHistoria(AppContext appContext)
        {
            _appContext = appContext;
        }
        IEnumerable<Historia> IRepositorioHistoria.GetAllHistorias()
        {
            return _appContext.historias;
        }
        Historia IRepositorioHistoria.AddHistoria(Historia Historia)
        {
            var HistoriaAdicionada = _appContext.historias.Add(Historia);
            _appContext.SaveChanges();
            return HistoriaAdicionada.Entity;
        }

        Historia IRepositorioHistoria.UpdateHistoria(Historia Historia)
        {
            var HistoriaEncontrado = _appContext.historias.FirstOrDefault(E => E.Id == Historia.Id);
            if (HistoriaEncontrado != null)
            {
                HistoriaEncontrado.Sugerencias = Historia.Sugerencias;
                HistoriaEncontrado.SignosVitales = Historia.SignosVitales;
                _appContext.SaveChanges();
            }
            return HistoriaEncontrado;
        }

        void IRepositorioHistoria.DeleteHistoria(int idHistoria)
        {
            var HistoriaEncontrado = _appContext.historias.FirstOrDefault(E => E.Id == idHistoria);
            if (HistoriaEncontrado == null)
                return;
            _appContext.historias.Remove(HistoriaEncontrado);
            _appContext.SaveChanges();
        }

        Historia IRepositorioHistoria.GetHistoria(int idHistoria)
        {
            return _appContext.historias.FirstOrDefault(E => E.Id == idHistoria);
        }
    }
}
