using System.Collections.Generic;

using HospiEnCasa.App.Dominio;
namespace HospiEnCasa.App.Persistencia
{
    public interface IRepositorioMedico
    {
        IEnumerable<Medico> GetAllMedicos();

        Medico AddMedico(Medico Medico);

        Medico UpdateMedico(Medico Medico);

        void DeleteMedico(int idMedico);

        Medico GetMedico(int idMedico);
    }
}