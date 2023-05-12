using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CadeteriaWeb.Models;
using CadeteriaWeb.ViewModels;
using CadeteriaWeb.ViewModels.Cliente;
using System.Data.SQLite;
using AutoMapper;
using CadeteriaWeb.Repositories;
using CadeteriaWeb.Interfaces;
using CadeteriaWeb.ViewModels.Usuario;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;

namespace CadeteriaWeb.Controllers
{
    //[Route("[controller]")]
    public class ClienteController : Controller
    {
        private readonly ILogger<ClienteController> _logger;
        private readonly IMapper _mapper;
        private readonly IClienteRepository _repoCliente;

        public ClienteController(ILogger<ClienteController> logger, IMapper mapper, IClienteRepository repoCliente)
        {
            _logger = logger;
            _mapper = mapper;
            _repoCliente = repoCliente;
        }

        [HttpGet][Route("Cliente")]
        public IActionResult Cliente()
        {
            try
            {
                //Controlo usuario logueado
                if (HttpContext.Session.GetString("rolUsuario") == null)
                {
                    return RedirectToAction("Logueo", "Logueo");
                }

                var clientes = _repoCliente.GetClientes();
                var mostrarClientes = _mapper.Map<List<MostrarClientesViewModel>>(clientes);

                return View(mostrarClientes);
            }
            catch (System.Exception ex)
            {
                ViewBag.Error = ex.Message;
                _logger.LogError(ex, "No se puede cargar Clientes");
                return View("/Views/Home/Error.cshtml");
            }
        }
        public IActionResult AltaCliente ()
        {
            //Controlo que el usuario logueado sea Admin
            string rolUser = HttpContext.Session.GetString("rolUsuario");
            if(rolUser == null || rolUser == "cadete")
            {
                return RedirectToAction("Logueo", "Logueo");
            }
            
            return View();
        }

        [HttpPost]
        public IActionResult AltaCliente (AltaClienteViewModel nuevoClienteVM)
        {
            try
            {
                //Controlo logueo y usuario autorizado
                string rolUser = HttpContext.Session.GetString("rolUsuario");
                if(rolUser == null || rolUser == "cadete")
                {
                    return RedirectToAction("Logueo", "Logueo");
                }
                
                var nuevoCliente = _mapper.Map<Cliente>(nuevoClienteVM);
                _repoCliente.Insert(nuevoCliente);
                
                return RedirectToAction("Cliente");
            }
            catch (SystemException ex)
            {
                _logger.LogWarning(ex, "No se pudo guardar el cliente");
                return View("/Views/Home/Error.cshtml");
            }
        }

        public IActionResult EditarCliente (int id)
        {
            Cliente? cliente = _repoCliente.GetCliente(id);
            var clienteVM = _mapper.Map<EditarClienteViewModel>(cliente);
            
            return View(clienteVM);
        }

        [HttpPost]
        public IActionResult EditarCliente (EditarClienteViewModel clienteVM)
        {

            var cliente = _mapper.Map<Cliente>(clienteVM);
            _repoCliente.Update(cliente);

            return RedirectToAction("Cliente");
           
        }

        public ActionResult EliminarCliente (int id)
        {
            Cliente? cliente = _repoCliente.GetCliente(id);
            var clienteVM = _mapper.Map<EliminarClienteViewModel>(cliente);
            
            return View(clienteVM);
        }

        [HttpPost]
        public ActionResult DeleteCliente (int id)
        {
            _repoCliente.Delete(id);
                    
            return RedirectToAction("Cliente");
            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}