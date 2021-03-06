﻿using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Mixtr.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {
        public ApplicationDbContext() : base("ApplicationDbContext")
        {
            Database.SetInitializer<ApplicationDbContext>(new ApplicationDbContextInitializer());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}