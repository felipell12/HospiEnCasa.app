using System.Collections.Generic;
using System.Linq;
using HospiEnCasa.App.Dominio;
namespace HospiEnCasa.App.Persistencia
{
    public class RepositorioFamiliarDesignado : IRepositorioFamiliarDesignado
    {
        private readonly AppContext _appContext;
        public RepositorioFamiliarDesignado(AppContext appContext)
        {
            _appContext = appContext;
        }
        IEnumerable<FamiliarDesignado> IRepositorioFamiliarDesignado.GetAllFamiliares()
        {
            return _appContext.familiaresdesignados;
        }
        FamiliarDesignado IRepositorioFamiliarDesignado.AddFamiliar(FamiliarDesignado FamiliarDesignado)
        {
            var FamiliarDesignadoAdicionada = _appContext.familiaresdesignados.Add(FamiliarDesignado);
            _appContext.SaveChanges();
            return FamiliarDesignadoAdicionada.Entity;
        }

        FamiliarDesignado IRepositorioFamiliarDesignado.UpdateFamiliar(FamiliarDesignado FamiliarDesignado)
        {
            var FamiliarDesignadoEncontrado = _appContext.familiaresdesignados.FirstOrDefault(E => E.Id == FamiliarDesignado.Id);
            if (FamiliarDesignadoEncontrado != null)
            {
                FamiliarDesignadoEncontrado.Nombre = FamiliarDesignado.Nombre;
                FamiliarDesignadoEncontrado.Genero = FamiliarDesignado.Genero;
                FamiliarDesignadoEncontrado.Parentesco = FamiliarDesignado.Parentesco;
                FamiliarDesignadoEncontrado.Correo = FamiliarDesignado.Correo;
                _appContext.SaveChanges();
            }
            return FamiliarDesignadoEncontrado;
        }

        void IRepositorioFamiliarDesignado.DeleteFamiliar(int idFamiliarDesignado)
        {
            var FamiliarDesignadoEncontrado = _appContext.familiaresdesignados.FirstOrDefault(E => E.Id == idFamiliarDesignado);
            if (FamiliarDesignadoEncontrado == null)
                return;
            _appContext.familiaresdesignados.Remove(FamiliarDesignadoEncontrado);
            _appContext.SaveChanges();
        }

        FamiliarDesignado IRepositorioFamiliarDesignado.GetFamiliar(int idFamiliarDesignado)
        {
            return _appContext.familiaresdesignados.FirstOrDefault(E => E.Id == idFamiliarDesignado);
        }
    }
}
