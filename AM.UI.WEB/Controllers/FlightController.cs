//using AM.ApplicationCore.Domain;
//using AM.ApplicationCore.Interfaces;
//using AM.ApplicationCore.Services;
//using AM.Infrastructure;
//using Humanizer;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.VisualBasic;
//using System;
//using System.Diagnostics.Metrics;
//using System.Drawing;
//using System.Net;
//using static System.Net.Mime.MediaTypeNames;
//using static System.Runtime.InteropServices.JavaScript.JSType;

//namespace AM.UI.WEB.Controllers
//{
//    public class FlightController : Controller
//    {
//        private readonly IServiceFlight _flightService;
        
        
//            private readonly IServicePlane _planeService;

//        public FlightController(IServiceFlight flightService, IServicePlane planeService)
//        {
//            _flightService = flightService;
//            _planeService = planeService;
//        }
//        public ActionResult Sort()
//        {
//            return View("Index",_flightService.SortFlights());
//        }
//        // GET: FlightController
//        public ActionResult Index(DateTime? dateDepart)
//        {
//            if (dateDepart == null)
//                return View(_flightService.GetAll().ToList());
//            else
//                return
//                View(_flightService.GetMany(f => f.FlightDate.Date.Equals(dateDepart)).ToList());
//        }
//        // GET: FlightController/Details/5
//        public ActionResult Details(int id)
//        {
//            return View();
//        }

//        // GET: FlightController/Create
//        public ActionResult Create()
//        {
//            ViewBag.Planes = new SelectList(_planeService.GetAll().ToList(),
//            "PlaneId", "PlaneId");
//            return View();
//        }

//            // POST: FlightController/Create

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create(Flight flight, IFormFile PilotImage)
//        {
//            try
//            {
//                if (PilotImage != null)
//                {
//                    var path = Path.Combine(Directory.GetCurrentDirectory(),
//                    "wwwroot", "uploads", PilotImage.FileName);
//                    Stream stream = new FileStream(path, FileMode.Create);
//                    PilotImage.CopyTo(stream);
//                    flight.pilot = PilotImage.FileName;
//                }
//                _flightService.Add(flight);
//                _flightService.Commit();
//                return RedirectToAction(nameof(Index));
//            }
//            catch
//            {
//                return View();
//            }
//        }

//        // GET: FlightController/Edit/5
//        public ActionResult Edit(int id)
//        {
//            ViewBag.Planes = new SelectList(_planeService.GetAll().ToList(),
//            "PlaneId", "PlaneId");
//            return View(_flightService.GetById(id));

//        }

//        // POST: FlightController/Edit/5
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit(int id, Flight flight, IFormFile PilotImage)
//        {
//            try
//            {
//                if (PilotImage != null)
//                {
//                    var path = Path.Combine(Directory.GetCurrentDirectory(),
//                    "wwwroot", "uploads", PilotImage.FileName);
//                    Stream stream = new FileStream(path, FileMode.Create);
//                    PilotImage.CopyTo(stream);
//                    flight.pilot = PilotImage.FileName;
//                }

//                flight.FlightId = id;

//                _flightService.Update(flight);
//                _flightService.Commit();

//                return RedirectToAction(nameof(Index));
//            }
//            catch
//            {
//                return View();
//            }
//        }


//        // GET: FlightController/Delete/5
//        public ActionResult Delete(int id)
//        {
//            return View(_flightService.GetById(id));
//        }

//        // POST: FlightController/Delete/5
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Delete(int id, Flight flight)
//        {
//            try
//            {
//                flight.FlightId = id;
//                _flightService.Delete(flight);
//                _flightService.Commit();
//                return RedirectToAction(nameof(Index));
//            }
//            catch
//            {
//                return View();
//            }
//        }




//    }
//}
