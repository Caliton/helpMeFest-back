using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace helpMeFest.Data
{
    public class BloggingContextFactory : IDesignTimeDbContextFactory<DatabaseContext> 
    {
        public DatabaseContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionsBuilder.UseMySql("Server=localhost;User Id=nicoolas;Password=12345;Database=help_me_fest; pooling = false;convert zero datetime=True");

            return new DatabaseContext(optionsBuilder.Options);
        }
    }
}
