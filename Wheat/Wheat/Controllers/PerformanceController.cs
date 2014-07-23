using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;
using System.Web.Mvc;
using Wheat.Models;

namespace Wheat.Controllers
{
    public class PerformanceController : Controller
    {
        //
        // GET: /Performance/
        public ActionResult Exhibit(Performance performance)
        {
            performance = new WheatDbContext().Performances.First();
            PerformanceOrderModel model = new PerformanceOrderModel();
            List<TicketModel> tickets = new List<TicketModel>();
            model.Information = performance.Information;
            model.Place = performance.Place;
            model.Poster = performance.Poster;
            model.Time = performance.Time;
            model.City = performance.City;
            model.Type = performance.Type;
            model.Title = performance.Title;
            foreach (var ticket in performance.Tickets)
            {
                TicketModel t = new TicketModel();
                t.Price = ticket.TicketPrice;
                t.RestNumber = ticket.TicketNumber;
                tickets.Add(t);
            }
            tickets.Sort((x, y) => x.Price.CompareTo(y.Price));
            model.Tickets = tickets;
            return View(model);
        }
    }
}
