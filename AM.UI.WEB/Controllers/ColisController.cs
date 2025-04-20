using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AM.UI.WEB.Controllers
{
    public class ColisController : Controller
    {
        private readonly IClient _c;
        private readonly ILivreur _l;


        private readonly IColis _co;

        public ColisController(IClient c, ILivreur l, IColis co)
        {
            _c = c;
            _l = l;
            _co = co;
        }

        // GET: ColisController
        public ActionResult Index(DateTime? dl)
        {
            if (dl == null)
                return View(_co.GetAll().ToList());
            else
                return
                View(_co.GetMany(f => f.DateLivraison.Date.Equals(dl)).ToList());
        }

        // GET: ColisController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ColisController/Create
        public ActionResult Create()
        {
            ViewBag.Livreurs = new SelectList(_l.GetAll(),"CIN", "CIN");
            ViewBag.Clients = new SelectList(_c.GetAll(),"Id", "Nom");
            return View();
        }

        // POST: ColisController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Colis c, IFormFile PilotImage)
        {
            try
            {
                if (PilotImage != null)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot", "uploads", PilotImage.FileName);
                    Stream stream = new FileStream(path, FileMode.Create);
                    PilotImage.CopyTo(stream);
                    c.image = PilotImage.FileName;
                }
                _co.Add(c);
                _co.Commit();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ColisController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ColisController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ColisController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ColisController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
