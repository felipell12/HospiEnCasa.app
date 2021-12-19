using System;
using System.Collections.Generic;
using HospiEnCasa.App.Dominio;
using HospiEnCasa.App.Persistencia;

namespace HospiEnCasa.App.Consola
{
    public class TestFamiliarDesignado
    {
        private static IRepositorioFamiliarDesignado _repoFamiliarDesignado = new RepositorioFamiliarDesignado(new Persistencia.AppContext());

        public static void AddFamiliarDesignado()
        {
            var FamiliarDesignado = new FamiliarDesignado
            {
                Nombre = "maria",
                Genero = Enum_Genero.Femenino,
                Parentesco = "hermana",
                Correo = "mari@gmail.com"
            };
            _repoFamiliarDesignado.AddFamiliar(FamiliarDesignado);
        }
        public static void BuscarFamiliarDesignado(int IdFamiliarDesignado)
        {
            var familiardesignado = _repoFamiliarDesignado.GetFamiliar(IdFamiliarDesignado);
            Console.WriteLine("----------------------------------------------------------------------------------");
            Console.WriteLine(familiardesignado.Nombre + " " + familiardesignado.Genero);
        }
        public static void UpdateFamiliarDesignado()
        {
            var familiardesignado = new FamiliarDesignado
            {
                Id = 11,
                Nombre = "marcela",
                Genero = Enum_Genero.Femenino,
                Parentesco = "hermana",
                Correo = "marcela@gmail.com",
            };
            var familiardesignadoModificada = _repoFamiliarDesignado.UpdateFamiliar(familiardesignado);
            Console.WriteLine("----------------------------------------------------------------------------------");
            Console.WriteLine("familiardesignado " + familiardesignadoModificada.Nombre + " modificada con éxito ");
        }
        public static void ListarFamiliarDesignados()
        {
            IEnumerable<FamiliarDesignado> listaFamiliarDesignados = _repoFamiliarDesignado.GetAllFamiliares();
            Console.WriteLine("----------------------------------------------------------------------------------"); Console.WriteLine("Lista de familiardesignados");
            foreach (FamiliarDesignado familiardesignado in listaFamiliarDesignados)
            {
                Console.WriteLine("Id " + familiardesignado.Id + " nombre " + familiardesignado.Nombre + " genero " + familiardesignado.Genero + " Correo " + familiardesignado.Correo+ " Correo " + familiardesignado.Parentesco);
            }
        }
        public static void EliminarFamiliarDesignado(int IdFamiliarDesignado)
        {
            _repoFamiliarDesignado.DeleteFamiliar(IdFamiliarDesignado);
            Console.WriteLine("----------------------------------------------------------------------------------"); Console.WriteLine("familiardesignado eliminada con éxito");
        }
    }
}