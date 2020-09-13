using RegistroSeccion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegistroSeccion.Controllers
{
    public class AlumnoController : Controller
    {
        private Alumno alu = new Alumno();
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.alerta = "info";
            ViewBag.res = "Registrar Nuevo Alumno";
            return View(alu.listar());
        }
        [HttpPost]

        public ActionResult Index(string dni, string nom, string ape)
        {
            if (alu.Insertar(dni, nom, ape)){
                ViewBag.alerta = "success";
                ViewBag.res = "Alumno Registrado";

            }
            else
            {
                ViewBag.alerta = "danger";
                ViewBag.res = "Alumno no Registrado";
            }
            return View(alu.listar());
        }
    }
}