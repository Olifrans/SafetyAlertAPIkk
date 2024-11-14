using Microsoft.EntityFrameworkCore;
using SafetyAlertAPI.Models;

namespace SafetyAlertAPI.Data
{
    public class AlertContext : DbContext
    {

        public AlertContext(DbContextOptions<AlertContext> options) : base(options) { }

        public DbSet<Alert> Alerts { get; set; }

    }
}
