using Microsoft.EntityFrameworkCore;
using Ogrenci_Bilgi_Sistemi_Core5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ogrenci_Bilgi_Sistemi_Core5
{
    public class MyContext:DbContext
    {
        

        public MyContext(DbContextOptions<MyContext> options)
            : base(options)
        {


        }

        public virtual DbSet<Ogrenci> MyEntities { get; set; }

    }
}
