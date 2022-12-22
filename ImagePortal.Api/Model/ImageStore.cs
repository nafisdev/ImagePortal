using Microsoft.EntityFrameworkCore;

namespace ImagePortal.Api.Model;

public class ImageStore : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        optionsBuilder.UseMySql("persist security info=False;database=imageportal;server=127.0.0.1;port=3308;user id=imageportal;password=imageportal", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.28-mysql"));
    }
        
    public DbSet<Image> Images { get; set; }
}