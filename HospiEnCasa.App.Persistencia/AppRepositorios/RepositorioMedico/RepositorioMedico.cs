using System.Collections.Generic;
using System.Linq;
using HospiEnCasa.App.Dominio;
namespace HospiEnCasa.App.Persistencia
{
    public class RepositorioMedico : IRepositorioMedico
    {
        private readonly AppContext _appContext;
        public RepositorioMedico(AppContext appContext)
        {
            _appContext = appContext;
        }
        IEnumerable<Medico> IRepositorioMedico.GetAllMedicos()
        {
            return _appContext.medicos;
        }
        Medico IRepositorioMedico.AddMedico(Medico Medico)
        {
            var MedicoAdicionada = _appContext.medicos.Add(Medico);
            _appContext.SaveChanges();
            return MedicoAdicionada.Entity;
        }

        Medico IRepositorioMedico.UpdateMedico(Medico Medico)
        {
            var MedicoEncontrado = _appContext.medicos.FirstOrDefault(E => E.Id == Medico.Id);
            if (MedicoEncontrado != null)
            {
                MedicoEncontrado.Nombre = Medico.Nombre;
                MedicoEncontrado.Genero = Medico.Genero;
                MedicoEncontrado.Especialidad = Medico.Especialidad;
                _appContext.SaveChanges();
            }
            return MedicoEncontrado;
        }

        void IRepositorioMedico.DeleteMedico(int idMedico)
        {
            var MedicoEncontrado = _appContext.medicos.FirstOrDefault(E => E.Id == idMedico);
            if (MedicoEncontrado == null)
                return;
            _appContext.medicos.Remove(MedicoEncontrado);
            _appContext.SaveChanges();
        }

        Medico IRepositorioMedico.GetMedico(int idMedico)
        {
            return _appContext.medicos.FirstOrDefault(E => E.Id == idMedico);
        }
    }
}
