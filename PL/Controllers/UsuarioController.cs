using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Usuario usuario = new ML.Usuario();
            ML.Result result = BL.Usuario.GetAll();

            if (result.Correct)
            {
                usuario.Usuarios = result.Objects;
                return View(usuario);
            }
            else
            {
                return View(usuario);
            }
            return View();
        }

        
        public ActionResult Form(int? IdUsuario)
        {
            ML.Usuario usuario = new ML.Usuario();

            if (IdUsuario == null)
            {
                return View(usuario);
            }
            else
            {
                ML.Result result = BL.Usuario.GetById(IdUsuario.Value);

                if (result.Correct)
                {
                    usuario = (ML.Usuario)result.Object;

                    return View(usuario);
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult Form(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            if (usuario.IdUsuario == 0)
            {
                result = BL.Usuario.Add(usuario);

                if (result.Correct)
                {
                    ViewBag.Message = "Usuario Agregado";
                    return View("Modal");
                }
            }
            else
            {
                result = BL.Usuario.Update(usuario);

                if (result.Correct)
                {
                    ViewBag.Message = "Usuario Modificado";
                    return View("Modal");
                }
            }
            return View();
        }

        public ActionResult Delete(int IdUsuario)
        {
            ML.Result result = BL.Usuario.Delete(IdUsuario);

            if (result.Correct)
            {
                return View("Modal");
            }
            return View();
        }
    }
}