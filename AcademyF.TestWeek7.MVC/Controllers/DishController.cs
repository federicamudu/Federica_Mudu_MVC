using AcademyF.TestWeek7.Core.BusinessLayer;
using AcademyF.TestWeek7.Core.Entities;
using AcademyF.TestWeek7.MVC.Helper;
using AcademyF.TestWeek7.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AcademyF.TestWeek7.MVC.Controllers
{
    [Authorize]
    public class DishController : Controller
    {
        
        private readonly IBusinessLayer BL;
        public DishController(IBusinessLayer bl)
        {
            BL = bl;
        }
        public IActionResult Index()
        {
            var dishes = BL.GetDishes();
            List<DishViewModel> dishesVM = new List<DishViewModel>();
            foreach (var item in dishes)
            {
                dishesVM.Add(item.ToDishViewModel());
            }
            return View(dishesVM);
        }
        public IActionResult Details(int id)
        {
            var dish = BL.GetDishes().FirstOrDefault(c => c.Id == id);
            var dishVM = dish.ToDishViewModel();
            return View(dishVM);
        }
        [Authorize(Policy = "Adm")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [Authorize(Policy = "Adm")]
        [HttpPost]
        public IActionResult Create(DishViewModel dishVM)
        {
            if (ModelState.IsValid)
            {
                Dish dish = dishVM.ToDish();
                var esito = BL.AddNewDish(dish);
                if (esito == true)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    //visualizzo il messaggio di errore in una pagina dedicata
                    ViewBag.MessaggioErrore ="Piatto non inserito";
                    return View("ErroriBusiness");
                }
            }
            return View(dishVM);
        }
        [Authorize(Policy = "Adm")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var piattoRecuperato = BL.GetDishes().FirstOrDefault(c => c.Id == id);
            var piatto = piattoRecuperato.ToDishViewModel();
            return View(piatto);
        }
        [Authorize(Policy = "Adm")]
        [HttpPost]
        public IActionResult Edit(DishViewModel dishVM)
        {
            if (ModelState.IsValid)
            {
                Dish dish = dishVM.ToDish();
                var esito = BL.EditDish(dish.Id, dish.Price);
                if (esito == true)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    //visualizzo il messaggio di errore in una pagina dedicata
                    ViewBag.MessaggioErrore = "Prezzo non aggiornato";
                    return View("ErroriBusiness");
                }
            }
            return View(dishVM);
        }
        [Authorize(Policy = "Adm")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var piattoRecuperato = BL.GetDishes().FirstOrDefault(c => c.Id == id);
            var piatto = piattoRecuperato.ToDishViewModel();
            return View(piatto);
        }
        [Authorize(Policy = "Adm")]
        [HttpPost]
        public IActionResult Delete(DishViewModel dishVM)
        {
            Dish dish = dishVM.ToDish(); //traduzione superflua
            var esito = BL.DeleteDish(dish.Id);
            if (esito == true)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                //visualizzo il messaggio di errore in una pagina dedicata
                ViewBag.MessaggioErrore = "Piatto non eliminato";
                return View("ErroriBusiness");
            }

            return View(dishVM);
        }
    }
}
