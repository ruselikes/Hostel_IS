using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WinFormsApp1;

public partial class HostelDbContext : DbContext
{
    public HostelDbContext()
    {
    }

    public HostelDbContext(DbContextOptions<HostelDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Manager> Managers { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<Zaselenie> Zaselenies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
/*#warningTo protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.*/
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-DK6528G;Database=HostelDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.ClientId).HasName("PK__CLIENT__E67E1A04863F7055");

            entity.ToTable("CLIENT");

            entity.Property(e => e.ClientId).HasColumnName("ClientID");
            entity.Property(e => e.ClientMiddleName)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.ClientName)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.ClientSurname)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Passport)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Manager>(entity =>
        {
            entity.HasKey(e => e.ManagerId).HasName("PK__MANAGER__3BA2AA81B25F7CAF");

            entity.ToTable("MANAGER");

            entity.Property(e => e.ManagerId).HasColumnName("ManagerID");
            entity.Property(e => e.MmiddleName)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("MMiddleName");
            entity.Property(e => e.Mname)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("MName");
            entity.Property(e => e.Mphone)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("MPhone");
            entity.Property(e => e.Msurname)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("MSurname");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.RoomId).HasName("PK__ROOM__328639197DFBF754");

            entity.ToTable("ROOM");

            entity.Property(e => e.RoomId).HasColumnName("RoomID");
            entity.Property(e => e.BedQty).HasColumnName("BedQTY");
            entity.Property(e => e.FreeBedQty).HasColumnName("FreeBedQTY");
            entity.Property(e => e.Price).HasColumnType("money");
        });

        modelBuilder.Entity<Zaselenie>(entity =>
        {
            entity.HasKey(e => e.ZaselenieId).HasName("PK__ZASELENI__3800D253729AD88B");

            entity.ToTable("ZASELENIE");

            entity.Property(e => e.ZaselenieId).HasColumnName("ZaselenieID");
            entity.Property(e => e.ClientId).HasColumnName("ClientID");
            entity.Property(e => e.DataVisel).HasColumnType("date");
            entity.Property(e => e.DataZasel).HasColumnType("date");
            entity.Property(e => e.RoomId).HasColumnName("RoomID");

            entity.HasOne(d => d.Client).WithMany(p => p.Zaselenies)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ZASELENIE__Clien__286302EC");

            entity.HasOne(d => d.Room).WithMany(p => p.Zaselenies)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ZASELENIE__RoomI__29572725");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
