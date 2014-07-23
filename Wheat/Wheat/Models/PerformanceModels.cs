using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wheat.Models
{
    public class PerformanceOrderModel
    {
        public string Title { get; set; }
        public string Place { get; set; }
        public string Information { get; set; }
        public string Poster { get; set; }
        public string City { get; set; }
        public string Type { get; set; }
        public DateTime Time { get; set; }
        public ICollection<TicketModel> Tickets { get; set; }
    }

    public class TicketModel
    {
        public decimal Price { get; set; }
        public int RestNumber { get; set; }
        public int OrderedNumber { get; set; }
    }
}