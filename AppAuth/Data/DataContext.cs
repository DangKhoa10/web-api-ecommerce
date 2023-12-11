using AppAuth.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAuth.Data
{
    public class DataContext : IdentityDbContext<UserDTO>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
    }
}
