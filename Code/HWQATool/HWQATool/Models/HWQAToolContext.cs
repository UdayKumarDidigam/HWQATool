using System.Data.Entity;

namespace HWQATool.Models
{
    public class HWQAToolContext : DbContext
    {
        public HWQAToolContext() : base("name=HWQAToolContext")
        {
        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Function> Functions { get; set; }
        public DbSet<SubTask> SubTasks { get; set; }
        public DbSet<Error> Errors { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Audit> Audits { get; set; }
        public DbSet<AuditFinding> AuditFindings { get; set; }
        public DbSet<AuditTimeSlot> AuditTimeSlots { get; set; }
        public DbSet<UploadTrack> UploadTracks { get; set; }
        public DbSet<ExcelRecord> ExcelRecords { get; set; }
    
    }
}
