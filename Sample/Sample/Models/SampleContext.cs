using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Sample.Models
{
    public class SampleContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public SampleContext() : base("name=SampleContext")
        {
        }

        public System.Data.Entity.DbSet<HWQATool.Models.Team> Teams { get; set; }

        public System.Data.Entity.DbSet<HWQATool.Models.Task> Tasks { get; set; }

        public System.Data.Entity.DbSet<HWQATool.Models.Platform> Platforms { get; set; }

        public System.Data.Entity.DbSet<HWQATool.Models.SubTask> SubTasks { get; set; }

        public System.Data.Entity.DbSet<HWQATool.Models.Grade> Grades { get; set; }

        public System.Data.Entity.DbSet<HWQATool.Models.Error> Errors { get; set; }

        public System.Data.Entity.DbSet<HWQATool.Models.Client> Clients { get; set; }

        public System.Data.Entity.DbSet<HWQATool.Models.ExcelRecord> ExcelRecords { get; set; }

        public System.Data.Entity.DbSet<HWQATool.Models.UploadTrack> UploadTracks { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}
