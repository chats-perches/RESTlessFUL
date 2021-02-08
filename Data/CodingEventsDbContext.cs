using RestFul.Models;
using Microsoft.EntityFrameworkCore;

namespace RestFul.Data {

    /*DEAD-END:
        there's not a lot going on here.
        All the action for this REST studio is the code that stands between T_H_I_S AND THE FRONT-END
     */
  public class CodingEventsDbContext : DbContext {
    public DbSet<CodingEvent> CodingEvents { get; set; }

    public CodingEventsDbContext(DbContextOptions options)
      : base(options) { }
  }
}
