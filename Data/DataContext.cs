using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Authors> Autors { get; set; }
        public DbSet<Books> Books { get; set; }
        public DbSet<Genres>Genres { get; set; }

    }
}
