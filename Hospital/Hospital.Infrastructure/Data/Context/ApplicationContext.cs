using Hospital.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Hospital.Infrastructure.Data.Context;

public class ApplicationContext : DbContext ,IDesignTimeDbContextFactory<ApplicationContext>
{
    public ApplicationContext(DbContextOptions options) : base(options)
    {
    }

    public ApplicationContext()
    {
    }

    public DbSet<UserEntity> Users { get; set; }
    public DbSet<DoctorEntity> Doctors { get; set; }
    public DbSet<ReservationEntity> Reservations { get; set; }
    public DbSet<ShiftEntity> Shifts { get; set; }


    public  ApplicationContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=Hospi.Db;Uid=sa;Pwd=yourStrong(!)Password");
            return new ApplicationContext(optionsBuilder.Options);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost,1433;Database=Hospi.Db;Uid=sa;Pwd=yourStrong(!)Password");
            }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<UserEntity>()
            .HasKey(key => key.Id);

        modelBuilder.Entity<DoctorEntity>()
            .HasKey(key => key.Id);

        modelBuilder.Entity<ReservationEntity>()
            .HasKey(key => key.Id);


        modelBuilder.Entity<ShiftEntity>()
            .HasKey(key => key.Id);




        modelBuilder.Entity<UserEntity>()
            .Property(prop => prop.Id)
            .IsRequired()
            ;


        modelBuilder.Entity<UserEntity>()
            .Property(prop => prop.CreateAt)
            .HasDefaultValueSql("getDate()");
      
        modelBuilder.Entity<UserEntity>()
                    .Property(prop => prop.IsDeleted)
                    .HasDefaultValue(false);

        modelBuilder.Entity<UserEntity>()
            .Property(prop => prop.FirstName)
            .IsRequired()
            .HasMaxLength(50);

        modelBuilder.Entity<UserEntity>()
            .Property(prop => prop.LastName)
            .IsRequired()
            .HasMaxLength(50);

        modelBuilder.Entity<UserEntity>()
            .Property(prop => prop.NationaCode)
            .IsRequired();

        modelBuilder.Entity<UserEntity>()
            .Property(prop => prop.LastTrackingCode)
            .HasDefaultValue(null);
     









        modelBuilder.Entity<DoctorEntity>()
            .Property(prop => prop.Id)
            .IsRequired()
            ;

        modelBuilder.Entity<DoctorEntity>()
            .Property(prop => prop.CreateAt)
            .HasDefaultValueSql("getDate()");
      
        modelBuilder.Entity<DoctorEntity>()
                    .Property(prop => prop.IsDeleted)
                    .HasDefaultValue(false);


        modelBuilder.Entity<DoctorEntity>()
            .Property(prop => prop.FirstName)
            .IsRequired()
            .HasMaxLength(50);

        modelBuilder.Entity<DoctorEntity>()
            .Property(prop => prop.LastName)
            .IsRequired()
            .HasMaxLength(50);

        modelBuilder.Entity<DoctorEntity>()
            .Property(prop => prop.Specialty)
            .IsRequired()
            .HasMaxLength(50);



       
        modelBuilder.Entity<ReservationEntity>()
            .Property(prop => prop.Id)
            .IsRequired()
            ;

        modelBuilder.Entity<ReservationEntity>()
            .Property(prop => prop.CreateAt)
            .HasDefaultValueSql("getDate()");
      
        modelBuilder.Entity<ReservationEntity>()
                    .Property(prop => prop.IsDeleted)
                    .HasDefaultValue(false);


        modelBuilder.Entity<ReservationEntity>()
            .Property(prop => prop.DoctorId)
            .IsRequired();

        modelBuilder.Entity<ReservationEntity>()
            .Property(prop => prop.UserId)
            .IsRequired();


            modelBuilder.Entity<ReservationEntity>()
            .Property(prop => prop.ShiftId)
            .IsRequired();


            
            modelBuilder.Entity<ReservationEntity>()
            .Property(prop => prop.Done)
            .HasDefaultValue(false);



            
            modelBuilder.Entity<ReservationEntity>()
            .Property(prop => prop.TrackingCode)
            .IsRequired();


             modelBuilder.Entity<ReservationEntity>()
            .Property(prop => prop.IsDeleted)
            .HasDefaultValue(false);





            



              modelBuilder.Entity<ShiftEntity>()
            .Property(prop => prop.Id)
            .IsRequired()
            ;

        modelBuilder.Entity<ShiftEntity>()
            .Property(prop => prop.CreateAt)
            .HasDefaultValueSql("getDate()");
      
        modelBuilder.Entity<ShiftEntity>()
                    .Property(prop => prop.IsDeleted)
                    .HasDefaultValue(false);



        modelBuilder.Entity<ShiftEntity>()
            .Property(prop => prop.WorkDay)
            .IsRequired();


            modelBuilder.Entity<ShiftEntity>()
            .Property(prop => prop.Start)
            .IsRequired();


             modelBuilder.Entity<ShiftEntity>()
            .Property(prop => prop.End)
            .IsRequired();

             modelBuilder.Entity<ShiftEntity>()
            .Property(prop => prop.Sance)
            .ValueGeneratedOnAdd();





      
    }

}
