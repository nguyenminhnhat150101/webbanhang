using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ASM.Models
{
    public partial class qlbanhangContext : DbContext
    {
        //public qlbanhangContext()
        //{
        //}

        public qlbanhangContext(DbContextOptions<qlbanhangContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cthd> Cthd { get; set; }
        public virtual DbSet<HoaDon> HoaDon { get; set; }
        public virtual DbSet<KhachHang> KhachHang { get; set; }
        public virtual DbSet<LoaiSp> LoaiSp { get; set; }
        public virtual DbSet<Nhanvien> Nhanvien { get; set; }
        public virtual DbSet<SanPham> SanPham { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=LAPTOP-O7CEPANL\\MSSQLSERVER1;Database=qlbanhang;Integrated Security=True");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cthd>(entity =>
            {
                entity.HasKey(e => new { e.MaHd, e.MaSp });

                entity.ToTable("CTHD");

                entity.Property(e => e.MaHd)
                    .HasColumnName("MaHD")
                    .HasMaxLength(5);

                entity.Property(e => e.MaSp)
                    .HasColumnName("MaSP")
                    .HasMaxLength(4);

                entity.HasOne(d => d.MaHdNavigation)
                    .WithMany(p => p.Cthd)
                    .HasForeignKey(d => d.MaHd)
                    .HasConstraintName("FK_CTHD_HoaDon");

                entity.HasOne(d => d.MaSpNavigation)
                    .WithMany(p => p.Cthd)
                    .HasForeignKey(d => d.MaSp)
                    .HasConstraintName("FK_CTHD_SanPham");
            });

            modelBuilder.Entity<HoaDon>(entity =>
            {
                entity.HasKey(e => e.MaHd);

                entity.Property(e => e.MaHd)
                    .HasColumnName("MaHD")
                    .HasMaxLength(5)
                    .ValueGeneratedNever();

                entity.Property(e => e.MaKh)
                    .HasColumnName("MaKH")
                    .HasMaxLength(4);

                entity.Property(e => e.MaNv).HasColumnName("MaNV");

                entity.Property(e => e.NgayLapHd)
                    .HasColumnName("NgayLapHD")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.MaKhNavigation)
                    .WithMany(p => p.HoaDon)
                    .HasForeignKey(d => d.MaKh)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_HoaDon_KhachHang");

                entity.HasOne(d => d.MaNvNavigation)
                    .WithMany(p => p.HoaDon)
                    .HasForeignKey(d => d.MaNv)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_HoaDon_Nhanvien");
            });

            modelBuilder.Entity<KhachHang>(entity =>
            {
                entity.HasKey(e => e.MaKh);

                entity.Property(e => e.MaKh)
                    .HasColumnName("MaKH")
                    .HasMaxLength(4)
                    .ValueGeneratedNever();

                entity.Property(e => e.DiaChi).HasMaxLength(30);

                entity.Property(e => e.DienThoai).HasMaxLength(7);

                entity.Property(e => e.TenKh)
                    .HasColumnName("TenKH")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<LoaiSp>(entity =>
            {
                entity.HasKey(e => e.MaLoaiSp);

                entity.ToTable("LoaiSP");

                entity.Property(e => e.MaLoaiSp)
                    .HasColumnName("MaLoaiSP")
                    .ValueGeneratedNever();

                entity.Property(e => e.TenLoaiSp)
                    .HasColumnName("TenLoaiSP")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Nhanvien>(entity =>
            {
                entity.HasKey(e => e.MaNv);

                entity.Property(e => e.MaNv).HasColumnName("MaNV");

                entity.Property(e => e.Diachi).HasMaxLength(50);

                entity.Property(e => e.Dienthoai).HasMaxLength(50);

                entity.Property(e => e.HoTenNv)
                    .HasColumnName("HoTenNV")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<SanPham>(entity =>
            {
                entity.HasKey(e => e.MaSp);

                entity.Property(e => e.MaSp)
                    .HasColumnName("MaSP")
                    .HasMaxLength(4)
                    .ValueGeneratedNever();

                entity.Property(e => e.HinhSp).HasColumnName("HinhSP");

                entity.Property(e => e.MaLoaiSp).HasColumnName("MaLoaiSP");

                entity.Property(e => e.TenSp)
                    .HasColumnName("TenSP")
                    .HasMaxLength(20);

                entity.HasOne(d => d.MaLoaiSpNavigation)
                    .WithMany(p => p.SanPham)
                    .HasForeignKey(d => d.MaLoaiSp)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_SanPham_LoaiSP");
            });
        }
    }
}
