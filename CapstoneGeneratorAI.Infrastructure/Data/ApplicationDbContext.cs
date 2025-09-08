using CapstoneGeneratorAI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneGeneratorAI.Infrastructure.Data
{
   public class ApplicationDbContext : DbContext
    {
  public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<NoteTaking> notetaking { get; set; }
        public DbSet<Flashcard> flashcard { get; set; }
        public DbSet<AISummarization> aiSummarization { get; set; }
    }
}
