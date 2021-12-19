using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HospiEnCasa.App.Dominio;
using HospiEnCasa.App.Persistencia;

namespace HospiEnCasa.App.Frontend.pages
{
    public class CreateMedicosModel : PageModel
    {
        private readonly IRepositorioMedico _repoMedico = new RepositorioMedico(new Persistencia.AppContext());
        public Medico Medico { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost(Medico medico)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }  
            Medico = _repoMedico.AddMedico(medico);
            TempData["mensaje"] = "medico creada exitosamente";
            return RedirectToPage("/Index");
        }
    }
}
