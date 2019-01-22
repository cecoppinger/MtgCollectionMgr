using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace MtgCollectionMgr.Models
{
    public class MtgCollectionMgrContext : DbContext
    {
        public MtgCollectionMgrContext (DbContextOptions<MtgCollectionMgrContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CardCollectionModel>().HasKey(c => new { c.CardModelID, c.CollectionModelID });
        }

        public DbSet<MtgCollectionMgr.Models.CardModel> CardModels { get; set; }
        public DbSet<MtgCollectionMgr.Models.CardCollectionModel> CardCollectionModels { get; set; }
        public DbSet<MtgCollectionMgr.Models.CollectionModel> CollectionModels { get; set; }

    }
}
