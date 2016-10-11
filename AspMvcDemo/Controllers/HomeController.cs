using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AspMvcDemo.Models;

namespace AspMvcDemo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var model = new FormModel();

            ViewBag.TypesList = GetTypes();
            ViewBag.SubTypesList = GetSubtypesList(model.TypeId);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var model = new FormModel()
            {
                TypeId = 2,
                SubTypeId = 4
            };

            ViewBag.TypesList = GetTypes();
            ViewBag.SubTypesList = GetSubtypesList(model.TypeId);

            return View("Index",model);
        }

        public ActionResult GetSubTypes(int? id)
        {
            var types = GetSubtypesList(id);
            return Json(types,JsonRequestBehavior.AllowGet);
        }

        private List<SelectListItem> GetTypes()
        {
            return Types;
        }

        private List<SelectListItem> GetSubtypesList(int? idType)
        {
            var stypes = Subtypes.Where(x => x.TypeId == idType);
            var resp = stypes.Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Name
            }).ToList();

            resp.Insert(0, new SelectListItem() { Value = "", Text = "Elija una opcion" });

            return resp;
        }

        private static readonly List<SelectListItem> Types = new List<SelectListItem>
        {
            new SelectListItem() {Value = "",Text = "Elija una opcion"},
            new SelectListItem() {Value = "1",Text = "Value 1"},
            new SelectListItem() {Value = "2",Text = "Value 2"},
            new SelectListItem() {Value = "3",Text = "Value 3"}
        };

        private static readonly List<SubTipo> Subtypes = new List<SubTipo>
        {
            new SubTipo() { Id= 1,TypeId = 1,Name = "ST 1"},
            new SubTipo() { Id= 2,TypeId = 1,Name = "ST 2"},
            new SubTipo() { Id= 3,TypeId = 2,Name = "ST 3"},
            new SubTipo() { Id= 4,TypeId = 2,Name = "ST 4"},
            new SubTipo() { Id= 5,TypeId = 3,Name = "ST 5"},
            new SubTipo() { Id= 6,TypeId = 3,Name = "ST 6"},
        };
    }
}