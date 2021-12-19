using System.Collections.Generic;

using HospiEnCasa.App.Dominio;
namespace HospiEnCasa.App.Persistencia
{
    public interface IRepositorioHistoria
    {
        IEnumerable<Historia> GetAllHistorias();

        Historia AddHistoria(Historia Historia);

        Historia UpdateHistoria(Historia Historia);

        void DeleteHistoria(int idHistoria);

        Historia GetHistoria(int idHistoria);
    }
}