using System.Collections.Generic;
using System.Linq;
using HospiEnCasa.App.Dominio;
namespace HospiEnCasa.App.Persistencia
{
    public class RepositorioSugerenciaCuidado : IRepositorioSugerenciaCuidado
    {
        private readonly AppContext _appContext;
        public RepositorioSugerenciaCuidado(AppContext appContext)
        {
            _appContext = appContext;
        }
        IEnumerable<SugerenciaCuidado> IRepositorioSugerenciaCuidado.GetAllSugerenciaCuidados()
        {
            return _appContext.sugerenciascuidados;
        }
        SugerenciaCuidado IRepositorioSugerenciaCuidado.AddSugerenciaCuidado(SugerenciaCuidado SugerenciaCuidado)
        {
            var SugerenciaCuidadoAdicionada = _appContext.sugerenciascuidados.Add(SugerenciaCuidado);
            _appContext.SaveChanges();
            return SugerenciaCuidadoAdicionada.Entity;
        }

        SugerenciaCuidado IRepositorioSugerenciaCuidado.UpdateSugerenciaCuidado(SugerenciaCuidado SugerenciaCuidado)
        {
            var SugerenciaCuidadoEncontrado = _appContext.sugerenciascuidados.FirstOrDefault(E => E.Id == SugerenciaCuidado.Id);
            if (SugerenciaCuidadoEncontrado != null)
            {
                SugerenciaCuidadoEncontrado.FechaHora = SugerenciaCuidado.FechaHora;
                SugerenciaCuidadoEncontrado.Descripcion = SugerenciaCuidado.Descripcion;
                SugerenciaCuidadoEncontrado.HistoriaId = SugerenciaCuidado.HistoriaId;
                _appContext.SaveChanges();
            }
            return SugerenciaCuidadoEncontrado;
        }

        void IRepositorioSugerenciaCuidado.DeleteSugerenciaCuidado(int idSugerenciaCuidado)
        {
            var SugerenciaCuidadoEncontrado = _appContext.sugerenciascuidados.FirstOrDefault(E => E.Id == idSugerenciaCuidado);
            if (SugerenciaCuidadoEncontrado == null)
                return;
            _appContext.sugerenciascuidados.Remove(SugerenciaCuidadoEncontrado);
            _appContext.SaveChanges();
        }

        SugerenciaCuidado IRepositorioSugerenciaCuidado.GetSugerenciaCuidado(int idSugerenciaCuidado)
        {
            return _appContext.sugerenciascuidados.FirstOrDefault(E => E.Id == idSugerenciaCuidado);
        }
    }
}
