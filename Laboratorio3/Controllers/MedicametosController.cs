using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace Laboratorio3.Controllers
{
    public class MedicametosController : Controller
    {
        public  ArbolBinario.ArbolBinario ArbolMedicamentos = new ArbolBinario.ArbolBinario();
        public  ArbolBinario.Medicamento[] mostrar;
        public static List<ArbolBinario.Medicamento> medicamentos;
        public static int a=0;
        // GET: Medicametos
        public MedicametosController ()
        {
            
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/MEDICAMENTOS.txt";
                medicamentos = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ArbolBinario.Medicamento>>(System.IO.File.ReadAllText(path));
                foreach (ArbolBinario.Medicamento aPart in medicamentos)
                {
                    ArbolMedicamentos.AgregarElemento(aPart);
                }  
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MostrarPost()
        {
            if (a==0)
            a = medicamentos.Count;

            mostrar = ArbolMedicamentos.Mostrar(1, a);
            ViewBag.Matriz = mostrar;
            return View();
        }
        public ActionResult MostrarIn()
        {
            if (a == 0)
                a = medicamentos.Count;

            mostrar = ArbolMedicamentos.Mostrar(3,a);
            ViewBag.Matriz = mostrar;
            return View();
        }
        public ActionResult MostrarPre()
        {
            if (a == 0)
                a = medicamentos.Count;

            mostrar = ArbolMedicamentos.Mostrar(2,a);
            ViewBag.Matriz = mostrar;
            return View();
        }
        public static ArbolBinario.Medicamento BuscarC;
        public ActionResult BuscarNombre()
        {
            var visi = medicamentos;
            foreach (var item in visi)
            {
                if ((Request.Form["Nombre"]) == item.Nombre)
                {
                    BuscarC = new ArbolBinario.Medicamento { Id = item.Id, Nombre = item.Nombre, Cantidad = item.Cantidad, Precio = item.Precio };
                    ViewBag.Mostrar = BuscarC;
                }
            }
            return View();
        }
        public ActionResult BuscarNombre2()
        {
            return View();
        }
        public ArbolBinario.Medicamento  v1;
        public ActionResult NuevoMedicamento()
        {
            return View();
        }
        public ActionResult Ingresa(string Nombre, int Id, double Precio)
        {
            Random num = new Random();
            int Cantidad = num.Next(0, 15);
            v1 = new ArbolBinario.Medicamento { Nombre = Nombre, Id = Id, Precio = Precio, Cantidad=Cantidad };
            ArbolMedicamentos.AgregarElemento(v1);
            a++;
            return View(v1);
        }

        public ActionResult Pedir()
        {
            ViewBag.Pedir = BuscarC;
            return View();
        }
        public ActionResult RealizarPedido(string Nombre, string Direccion, int Nit, int Cantidad)
        {
            if (Cantidad == 0)
            {
                ArbolMedicamentos.EliminarElemento(BuscarC.Id);
            }
            else
            {
                BuscarC.Cantidad = Cantidad;
                ArbolMedicamentos.ActualizaDatos(BuscarC);
            }
            
            return View();
        }

    }
    
}