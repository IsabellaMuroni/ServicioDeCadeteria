using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CadeteriaWeb.Models;
using CadeteriaWeb.ViewModels;
using CadeteriaWeb.ViewModels.Usuario;
using CadeteriaWeb.Interfaces;
using CadeteriaWeb.Repositories;
using System.Data.SQLite;
using AutoMapper;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;

namespace CadeteriaWeb.Controllers
{
    [Route("[controller]")]
    public class LogueoController : Controller
    {
        private readonly ILogger<LogueoController> _logger;
        private readonly IMapper _mapper;
        private readonly IUsuarioRepository _repoUsuario;

        public LogueoController(ILogger<LogueoController> logger, IMapper mapper, IUsuarioRepository repoUsuario)
        {
            _logger = logger;
            _mapper = mapper;
            _repoUsuario = repoUsuario;
        }

        [Route("Logueo")]
        public IActionResult Logueo()
        {
            if (HttpContext.Session.GetString("nombreUsuario") == null)
            {
                return View(new LoginViewModel());
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public IActionResult IniciarSesion (LoginViewModel nuevologinVM)
        {
            Usuario newUser = _repoUsuario.GetUsuario(nuevologinVM.User, nuevologinVM.Contrasena);

            if (newUser != null)
            {
                HttpContext.Session.SetString("nombreUsuario", newUser.User);
                HttpContext.Session.SetString("rolUsuario", newUser.Rol);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["mensaje"] = "Usuario y/o contraseña incorrectos";
                return View("Logueo");
            }

        }

        [Route("Logueo/CerrarSesion")]
        public IActionResult CerrarSesion()
        {   
            HttpContext.Session.Clear();
            return RedirectToAction("Index","Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}