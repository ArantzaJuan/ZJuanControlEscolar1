using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class MateriaController : Controller
    {
        // GET: Materia
        public ActionResult GetAll()
        {
            ML.Materia materia = new ML.Materia();

            ML.Result result = new ML.Result();
            result = BL.Materia.Getall();
            if (result.Correct)
            {
                materia.Materias = result.Objects.ToList();
            }
            else
            {
                ViewBag.Mensaje = "No se pueden mostrar los alumnos";
            }
            return View(materia);
        }

        public ActionResult Form(int? idMateria)
        {
            ML.Materia materia = new ML.Materia();

            if (materia == null)
            {
                return View(materia);
            }
            else
            {
                ML.Result result = new ML.Result();
                result = BL.Materia.GetById(idMateria.Value);
                if (result.Correct)
                {
                    materia = (ML.Materia)result.Object;
                }
                else
                {
                    ViewBag.Mensaje = "No se pueden mostrar los alumnos";
                }
                return View(materia);

            }
        }

        [HttpPost]
        public ActionResult Form(ML.Materia materia)
        {


            if (materia.idMateria == 0)
            {
                ML.Result result = new ML.Result();
                result = BL.Materia.Add(materia);
                if (result.Correct)
                {
                    materia = (ML.Materia)result.Object;
                    ViewBag.Mensaje = "Usuario guardado exitosamente";

                }
                else
                {
                    ViewBag.Mensaje = "Ocurrio un error al agregar al usuario";
                }
            }
            else
            {
                //update

                ML.Result result = new ML.Result();
                result = BL.Materia.UpDate(materia);
                if (result.Correct)
                {
                    materia = (ML.Materia)result.Object;
                    ViewBag.Mensaje = "Usuario Actualizado Correctamente";
                }
                else
                {
                    ViewBag.Mensaje = "Ocurrio un error El usuario no se pudo actualizar";
                }

            }

            return PartialView("Modal");

        }
        [HttpGet]
        public ActionResult Delete(int idMatreria)
        {
            ML.Result result = new ML.Result();
            result = BL.Materia.Delete(idMatreria);
            if (result.Correct)
            {
                ViewBag.Mensaje = "Se elimino el registro";
            }
            return PartialView("Modal");
        }
    }
}
