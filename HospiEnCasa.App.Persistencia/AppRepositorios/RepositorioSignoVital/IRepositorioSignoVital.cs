using System.Collections.Generic;

using HospiEnCasa.App.Dominio;
namespace HospiEnCasa.App.Persistencia
{
    public interface IRepositorioSignoVital
    {
        IEnumerable<SignoVital> GetAllSignoVitales();

        SignoVital AddSignoVital(SignoVital SignoVital);

        SignoVital UpdateSignoVital(SignoVital SignoVital);

        void DeleteSignoVital(int idSignoVital);

        SignoVital GetSignoVital(int idSignoVital);
    }
}