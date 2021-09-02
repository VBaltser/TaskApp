using System.Web.Mvc;
using TaskApp.Repository;
using TaskApp.Entities;
using TaskApp.Models;
using System.Linq;

namespace TaskApp.Controllers
{
    public class CorrectionController : Controller
    {
        private IRepository repository;

        public CorrectionController(IRepository repo)
        {
            repository = repo;
        }

        public ViewResult Create()
        {
            CorrectionCreateModel model = new CorrectionCreateModel();
            
            model.Apps = repository.Apps;
        
            return View(model);
        }

        public ViewResult List()
        {
            return View(repository.Corrections);
        }

        public ViewResult Edit(int corrId)
        {
            CorrectionCreateModel model = new CorrectionCreateModel();
            Correction correction = repository.Corrections.FirstOrDefault(c => c.id == corrId);

            model.Apps = repository.Apps;

            model.Date = correction.Date;
            model.Description = correction.Description;
            model.Name = correction.Name;
            model.Email = correction.Email;
            model.id = correction.id;
            model.AppId = correction.AppID;

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(CorrectionCreateModel correctionModel)
        {
            int appId;
            
            if (ModelState["Apps"].Value.AttemptedValue != "")
            {
                appId = int.Parse(ModelState["Apps"].Value.AttemptedValue);
                ModelState.Remove("Apps");
            }
            else
            {
                ModelState.AddModelError("Apps", "Выберите приложение");
                correctionModel.Apps = repository.Apps;
                return View(correctionModel);
            }

            if (ModelState.IsValid)
            {
                Correction correction = new Correction();
                correction.Date = correctionModel.Date;
                correction.AppID = appId;
                correction.Description = correctionModel.Description;
                correction.Email = correctionModel.Email;
                correction.Name = correctionModel.Name;

                repository.SaveCorrection(correction);
                TempData["message"] = string.Format("Изменения правки \"{0}\" были сохранены", correction.Name);
                return RedirectToAction("List");
            }
            else 
            {
                correctionModel.Apps = repository.Apps;
                return View(correctionModel);
            }
        }

        [HttpPost]
        public ActionResult Edit(CorrectionCreateModel correctionModel)
        {
            int appId;

            if (ModelState["Apps"].Value.AttemptedValue != "")
            {
                appId = int.Parse(ModelState["Apps"].Value.AttemptedValue);
                ModelState.Remove("Apps");
            }
            else
            {
                ModelState.AddModelError("Apps", "Выберите приложение");
                correctionModel.Apps = repository.Apps;
                return View(correctionModel);
            }

            if (ModelState.IsValid)
            {
                Correction correction = new Correction();
                correction.Date = correctionModel.Date;
                correction.AppID = appId;
                correction.Description = correctionModel.Description;
                correction.Email = correctionModel.Email;
                correction.Name = correctionModel.Name;

                repository.SaveCorrection(correction);
                TempData["message"] = string.Format("Изменения правки \"{0}\" были сохранены", correction.Name);
                return RedirectToAction("List");
            }
            else
            {
                correctionModel.Apps = repository.Apps;
                return View(correctionModel);
            }
        }

        public ActionResult Delete(int corrId)
        {
            Correction deleteCorrection = repository.DeleteCorrection(corrId);
            
            if (deleteCorrection != null)
            {
                TempData["message"] = string.Format("Правка \"{0}\" была удалена", deleteCorrection.Name);
            }
            
            return RedirectToAction("List");
        }


    }
}