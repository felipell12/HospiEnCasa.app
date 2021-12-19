using System.Collections.Generic;
using System.Linq;
using HospiEnCasa.App.Dominio;
namespace HospiEnCasa.App.Persistencia
{
    public class RepositorioPaciente : IRepositorioPaciente
    {

        private readonly AppContext _appContext;
        public RepositorioPaciente(AppContext appContext)
        {
            _appContext = appContext;
        }
        IEnumerable<Paciente> IRepositorioPaciente.GetAllPacientes()
        {
            return _appContext.pacientes;
        }
        Paciente IRepositorioPaciente.AddPaciente(Paciente Paciente)
        {
            var PacienteAdicionado = _appContext.pacientes.Add(Paciente);
            _appContext.SaveChanges();
            return PacienteAdicionado.Entity;
        }

        Paciente IRepositorioPaciente.UpdatePaciente(Paciente Paciente)
        {
            var PacienteEncontrado = _appContext.pacientes.FirstOrDefault(p => p.Id == Paciente.Id);
            if (PacienteEncontrado != null)
            {
                PacienteEncontrado.Nombre = Paciente.Nombre;
                PacienteEncontrado.Genero = Paciente.Genero;
                PacienteEncontrado.Ciudad = Paciente.Ciudad;
                PacienteEncontrado.FechaNacimiento = Paciente.FechaNacimiento;
                PacienteEncontrado.FamiliarDesignado = Paciente.FamiliarDesignado;
                PacienteEncontrado.FamiliarDesignadoId = Paciente.FamiliarDesignadoId;
                PacienteEncontrado.Enfermera = Paciente.Enfermera;
                PacienteEncontrado.Medico = Paciente.Medico;
                PacienteEncontrado.Historia = Paciente.Historia;
                PacienteEncontrado.EnfermeraId = Paciente.EnfermeraId;
                PacienteEncontrado.MedicoId = Paciente.MedicoId;
                PacienteEncontrado.HistoriaId = Paciente.HistoriaId;
                _appContext.SaveChanges();
            }
            return PacienteEncontrado;
        }

        void IRepositorioPaciente.DeletePaciente(int idPaciente)
        {
            var PacienteEncontrado = _appContext.pacientes.FirstOrDefault(p => p.Id == idPaciente);
            if (PacienteEncontrado == null)
                return;
            _appContext.pacientes.Remove(PacienteEncontrado);
            _appContext.SaveChanges();
        }

        Paciente IRepositorioPaciente.GetPaciente(int idPaciente)
        {
            return _appContext.pacientes.FirstOrDefault(p => p.Id == idPaciente);
        }
    }
}
