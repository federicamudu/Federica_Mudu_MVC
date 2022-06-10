using AcademyF.TestWeek7.Core.BusinessLayer;
using AcademyF.TestWeek7.Core.Entities;
using AcademyF.TestWeek7.MVC.Helper;
using AcademyF.TestWeek7.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AcademyF.TestWeek7.MVC.Controllers
{
    [Authorize]
    public class MenuController : Controller
    {

        private readonly IBusinessLayer BL;
        public MenuController(IBusinessLayer bl)
        {
            BL = bl;
        }
        public IActionResult Index()
        {
            //devo recuperare la lista dei corsi dal repo e passarla alla lista
            var menu = BL.GetMenus();
            List<MenuViewModel> menuVM = new List<MenuViewModel>();
            foreach (var item in menu)
            {
                menuVM.Add(item.ToMenuViewModel());
            }
            return View(menuVM);
        }
        public IActionResult Details(int id)
        {
            var menu = BL.GetMenus().FirstOrDefault(c => c.Id == id);
            var menuVM = menu.ToMenuViewModel();
            return View(menuVM);
        }

        [Authorize(Policy = "Adm")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [Authorize(Policy = "Adm")]
        [HttpPost]
        public IActionResult Create(MenuViewModel menuVM)
        {
            if (ModelState.IsValid)
            {
                Menu menu = menuVM.ToMenu();
                var esito = BL.AddNewMenu(menu);
                if (esito == true)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    //visualizzo il messaggio di errore in una pagina dedicata
                    ViewBag.MessaggioErrore = "Menu non aggiunto!";
                    return View("ErroriBusiness");
                }
            }
            return View(menuVM);
        }
        [Authorize(Policy = "Adm")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var menuRecuperato = BL.GetMenus().FirstOrDefault(c => c.Id == id);
            var corso = menuRecuperato.ToMenuViewModel();
            return View(corso);
        }
        [Authorize(Policy = "Adm")]
        [HttpPost]
        public IActionResult Edit(MenuViewModel menuVM)
        {
            if (ModelState.IsValid)
            {
                Menu menu = menuVM.ToMenu();
                var esito = BL.EditMenu(menu);
                if (esito == true)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    //visualizzo il messaggio di errore in una pagina dedicata
                    ViewBag.MessaggioErrore = "Menu non aggiornato";
                    return View("ErroriBusiness");
                }
            }
            return View(menuVM);
        }
    }
}
