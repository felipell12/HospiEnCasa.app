using System.Collections.Generic;

using HospiEnCasa.App.Dominio;
namespace HospiEnCasa.App.Persistencia
{
    public interface IRepositorioPaciente
    {
        IEnumerable<Paciente> GetAllPacientes();

        Paciente AddPaciente(Paciente Paciente);

        Paciente UpdatePaciente(Paciente Paciente);

        void DeletePaciente(int idPaciente);

        Paciente GetPaciente(int idPaciente);
    }
}