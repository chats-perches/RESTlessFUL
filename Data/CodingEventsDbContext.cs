using RestFul.Models;
using Microsoft.EntityFrameworkCore;

namespace RestFul.Data {
  public class CodingEventsDbContext : DbContext {
    public DbSet<CodingEvent> CodingEvents { get; set; }

    public CodingEventsDbContext(DbContextOptions options)
      : base(options) { }
  }
}
