using C_Sharp_CRUD.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace C_Sharp_CRUD.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }
        public DbSet<UserInfo> UserInfos { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }
    }
}
