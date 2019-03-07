using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace Laboratorio3.Controllers
{
    public class MedicametosController : Controller
    {
        
        // GET: Medicametos
        public MedicametosController ()
        {
            try
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/MEDICAMENTOS";
                List<ArbolBinario.Medicamento> medicamentos = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ArbolBinario.Medicamento>>(System.IO.File.ReadAllText(path));
            }
            catch { }
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}