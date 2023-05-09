using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CadeteriaWeb.Models;
using CadeteriaWeb.ViewModels;
using System.Data.SQLite;
using AutoMapper;
using CadeteriaWeb.Repositories;
using CadeteriaWeb.Interfaces;
using CadeteriaWeb.ViewModels.Usuario;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;


namespace CadeteriaWeb.Controllers
{
    //[Route("Cadete")]
    public class CadeteController : Controller
    {
        public List<Cadete> listaCadetes = new List<Cadete>();
        private readonly ILogger<CadeteController> _logger;
        private readonly IMapper _mapper;
        private readonly ICadeteRepository _repoCadete;

        public CadeteController(ILogger<CadeteController> logger, IMapper mapper, ICadeteRepository repoCadete)
        {
            _logger = logger;
            _mapper = mapper;
            _repoCadete = repoCadete;
        }
        
        [HttpGet][Route("Cadete")]//Pág. inicio Cadetes: muestra la lista de cadetes
        public IActionResult Cadete ()
        {
            try
            {
                //Control para usuario logueado
                if(HttpContext.Session.GetString("rolUsuario") == null)
                {
                    return RedirectToAction("Index", "Home");
                }
                
                var cadetes = _repoCadete.GetCadetes();
                var mostrarCadetes = _mapper.Map<List<MostrarCadetesViewModel>>(cadetes);

                return View(mostrarCadetes);
            }
            catch(SystemException ex)
            {
                ViewBag.Error = ex.Message;
                _logger.LogError(ex, "No se puede cargar listado");
                return View("/Views/Home/Error.cshtml");
            }
        }

    
        public IActionResult AltaCadete ()
        {
            //Controlo que el usuario logueado sea Admin
            string rolUser = HttpContext.Session.GetString("rolUsuario");
            if(rolUser == null || rolUser == "cadete")
            {
                return RedirectToAction("Index", "Home");
            }
            return View ();
        }        
        
        [HttpPost]
        public IActionResult AltaCadete (AltaCadeteViewModel nuevoCadeteVM)
        {
            
                var nuevoCadete = _mapper.Map<Cadete>(nuevoCadeteVM);
                _repoCadete.Insert(nuevoCadete);
                return RedirectToAction("Cadete");
            
        }

        public IActionResult EditarCadete (int id)
        {
            Cadete? cadete = _repoCadete.GetCadete(id);
            var cadeteVM = _mapper.Map<EditarCadeteViewModel>(cadete);
            
            return View(cadeteVM);
        }

        [HttpPost]
        public IActionResult EditarCadete (EditarCadeteViewModel cadeteVM)
        {
            
                    var cadete = _mapper.Map<Cadete>(cadeteVM);
                    _repoCadete.Update(cadete);
                    
                    return RedirectToAction("Cadete");
           
        }
               
        /*
        public IActionResult Eliminar_Cadete (int id)
        {
            var cadete = _repoCadete.GetCadete(id);
            EliminarCadeteViewModel eliminarCade = _mapper.Map<EliminarCadeteViewModel>(cadete);

            _repoCadete.Delete(id);

            return RedirectToAction("Cadete");
        }*/

      
        public ActionResult EliminarCadete (int id)
        {
            Cadete? cadete = _repoCadete.GetCadete(id);
            var cadeteVM = _mapper.Map<EliminarCadeteViewModel>(cadete);
            
            return View(cadeteVM);
        }

        [HttpPost]
        public ActionResult DeleteCadete (int id)
        {
            _repoCadete.Delete(id);
                    
            return RedirectToAction("Cadete");
            
        }
        /*
        public IActionResult EliminarCadete (int id)
        {
            _repoCadete.Delete(id);
            
            return RedirectToAction("Cadete");
        } 
         */       
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}