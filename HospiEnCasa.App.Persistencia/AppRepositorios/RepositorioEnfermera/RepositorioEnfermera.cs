using System.Collections.Generic;
using System.Linq;  
using HospiEnCasa.App.Dominio;
namespace HospiEnCasa.App.Persistencia
{
    public class RepositorioEnfermera : IRepositorioEnfermera
    {
        private readonly AppContext _appContext;
        public RepositorioEnfermera(AppContext appContext)
        {
            _appContext = appContext;
        }
        IEnumerable<Enfermera> IRepositorioEnfermera.GetAllEnfermeras()
        {
            return _appContext.enfermeras;
        }
        Enfermera IRepositorioEnfermera.AddEnfermera(Enfermera Enfermera)
        {
            var EnfermeraAdicionada = _appContext.enfermeras.Add(Enfermera);
            _appContext.SaveChanges();
            return EnfermeraAdicionada.Entity;
        }

        Enfermera IRepositorioEnfermera.UpdateEnfermera(Enfermera Enfermera)
        {
            var EnfermeraEncontrada = _appContext.enfermeras.FirstOrDefault(E => E.Id == Enfermera.Id);
            if (EnfermeraEncontrada != null)
            {
                EnfermeraEncontrada.Nombre = Enfermera.Nombre;
                EnfermeraEncontrada.Genero = Enfermera.Genero;
                EnfermeraEncontrada.TarjetaProfesional=Enfermera.TarjetaProfesional;
                EnfermeraEncontrada.HorasLaborales=Enfermera.HorasLaborales;

                _appContext.SaveChanges();
            }
            return EnfermeraEncontrada;
        }

        void IRepositorioEnfermera.DeleteEnfermera(int idEnfermera)
        {
            var EnfermeraEncontrada = _appContext.enfermeras.FirstOrDefault(E => E.Id == idEnfermera);
            if (EnfermeraEncontrada == null)
                return;
            _appContext.enfermeras.Remove(EnfermeraEncontrada);
            _appContext.SaveChanges();
        }

        Enfermera IRepositorioEnfermera.GetEnfermera(int idEnfermera)
        {
            return _appContext.enfermeras.FirstOrDefault(E => E.Id == idEnfermera);
        }
    }
}
