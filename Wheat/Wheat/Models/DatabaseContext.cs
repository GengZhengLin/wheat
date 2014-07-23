using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wheat.Models
{
    public partial class WheatDbContext: DbContext
    {
        public WheatDbContext(): base("name=AppServerContext")
        {
        }
        public DbSet<Performance> Performances { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
    }

    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string UserEmail { get; set; }
        public string UserPhoneNumber { get; set; }
        public string UserAddress { get; set; }
        public string UserPortrait { get; set; }
        public decimal UserAccount { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }

    public class Question
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long QuestionID { get; set; }
        public string QuestionText { get; set; }
        public virtual User User { get; set; }
        public string AnswerText { get; set; }
        public virtual Admin Admin { get; set; }
        public virtual Performance Performance { get; set; }
        public DateTime QuestionTime { get; set; }
    }

    public class Admin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long AdminID { get; set; }
        public long AnswerNumber { get; set; }
        public long PerformanceNumber { get; set; }
        public virtual ICollection<Performance> Performances { get; set; }
    }

    public class Performance
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public long PerformanceID { get; set; }
        public string Title { get; set; }
        public DateTime Time { get; set; }
        public string City { get; set; }
        public string Place { get; set; }
        public string Type { get; set; }
        public string Information { get; set; }
        public long ClickRate { get; set; }
        public string Poster { get; set; }
        public virtual Admin Admin { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }

    public class Ticket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long TicketID { get; set; }
        public int TicketNumber { get; set; }
        public decimal TicketPrice { get; set; }
        public string TicketPlace { get; set; }
        public virtual Performance Performance { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }

    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long OrderID { get; set; }
        public DateTime OrderTime { get; set; }
        public byte OrderState { get; set; }
        public int TicketNumber { get; set; }
        public virtual Ticket Ticket { get; set; }
        public virtual User User { get; set; }
    }

    public class Favorite
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long FavoriteID { get; set; }
        public virtual User User { get; set; }
        public virtual Performance Performance { get; set; }
    }
}