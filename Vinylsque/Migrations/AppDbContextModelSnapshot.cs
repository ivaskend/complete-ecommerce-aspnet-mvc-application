﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Vinylsque.Data;

namespace Vinylsque.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Vinylsque.Models.AlbumFormats", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AlbumFormats");
                });

            modelBuilder.Entity("Vinylsque.Models.Artist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfilePictureURL")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Artists");
                });

            modelBuilder.Entity("Vinylsque.Models.RecordLabel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfilePictureURL")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RecordLabels");
                });

            modelBuilder.Entity("Vinylsque.Models.Vinyl", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AlbumFormatsId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Details")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("RecordLabelId")
                        .HasColumnType("int");

                    b.Property<int>("VinylGenre")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AlbumFormatsId");

                    b.HasIndex("RecordLabelId");

                    b.ToTable("Vinyls");
                });

            modelBuilder.Entity("Vinylsque.Models.Vinyl_Artist", b =>
                {
                    b.Property<int>("ArtistId")
                        .HasColumnType("int");

                    b.Property<int>("VinylId")
                        .HasColumnType("int");

                    b.HasKey("ArtistId", "VinylId");

                    b.HasIndex("VinylId");

                    b.ToTable("Vinyls_Artist");
                });

            modelBuilder.Entity("Vinylsque.Models.Vinyl", b =>
                {
                    b.HasOne("Vinylsque.Models.AlbumFormats", "AlbumFormats")
                        .WithMany("Vinyls")
                        .HasForeignKey("AlbumFormatsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Vinylsque.Models.RecordLabel", "RecordLabel")
                        .WithMany("Vinyls")
                        .HasForeignKey("RecordLabelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AlbumFormats");

                    b.Navigation("RecordLabel");
                });

            modelBuilder.Entity("Vinylsque.Models.Vinyl_Artist", b =>
                {
                    b.HasOne("Vinylsque.Models.Artist", "Artist")
                        .WithMany("Artists_Vinyl")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Vinylsque.Models.Vinyl", "Vinyl")
                        .WithMany("Artists_Vinyl")
                        .HasForeignKey("VinylId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");

                    b.Navigation("Vinyl");
                });

            modelBuilder.Entity("Vinylsque.Models.AlbumFormats", b =>
                {
                    b.Navigation("Vinyls");
                });

            modelBuilder.Entity("Vinylsque.Models.Artist", b =>
                {
                    b.Navigation("Artists_Vinyl");
                });

            modelBuilder.Entity("Vinylsque.Models.RecordLabel", b =>
                {
                    b.Navigation("Vinyls");
                });

            modelBuilder.Entity("Vinylsque.Models.Vinyl", b =>
                {
                    b.Navigation("Artists_Vinyl");
                });
#pragma warning restore 612, 618
        }
    }
}
