﻿// <auto-generated />
using Animal_Wiki.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Animal_Wiki.Migrations
{
    [DbContext(typeof(AnimalContext))]
    [Migration("20220516135222_AnimalMigration")]
    partial class AnimalMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Animal_Wiki.Models.AnimalClass", b =>
                {
                    b.Property<int>("AnimalClassID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClassBasicDesc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClassPhotoPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhyliumID")
                        .HasColumnType("int");

                    b.HasKey("AnimalClassID");

                    b.HasIndex("PhyliumID");

                    b.ToTable("classes");
                });

            modelBuilder.Entity("Animal_Wiki.Models.Family", b =>
                {
                    b.Property<int>("FamilyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FamilyBasicDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FamilyPhotoPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrderID")
                        .HasColumnType("int");

                    b.HasKey("FamilyID");

                    b.HasIndex("OrderID");

                    b.ToTable("families");
                });

            modelBuilder.Entity("Animal_Wiki.Models.Genius", b =>
                {
                    b.Property<int>("GeniusID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FamilyID")
                        .HasColumnType("int");

                    b.Property<string>("GeniusBasicDesc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GeniusPhotoPath")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GeniusID");

                    b.HasIndex("FamilyID");

                    b.ToTable("genius");
                });

            modelBuilder.Entity("Animal_Wiki.Models.Kingdom", b =>
                {
                    b.Property<int>("KingdomID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("KingdomBasicDesc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KingdomPhotoPath")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KingdomID");

                    b.ToTable("kingdoms");
                });

            modelBuilder.Entity("Animal_Wiki.Models.Order", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AnimalClassID")
                        .HasColumnType("int");

                    b.Property<string>("OrderBasicDesc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrderPhotoPath")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrderID");

                    b.HasIndex("AnimalClassID");

                    b.ToTable("orders");
                });

            modelBuilder.Entity("Animal_Wiki.Models.Phylium", b =>
                {
                    b.Property<int>("PhyliumID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("KingdomID")
                        .HasColumnType("int");

                    b.Property<string>("PhyliumBasicDesc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhyliumPhotoPath")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PhyliumID");

                    b.HasIndex("KingdomID");

                    b.ToTable("phylia");
                });

            modelBuilder.Entity("Animal_Wiki.Models.Species", b =>
                {
                    b.Property<int>("SpeciesID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GeniusID")
                        .HasColumnType("int");

                    b.Property<string>("SpeciesBasicDesc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpeciesPhotoPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("scientificname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SpeciesID");

                    b.HasIndex("GeniusID");

                    b.ToTable("species");
                });

            modelBuilder.Entity("Animal_Wiki.Models.AnimalClass", b =>
                {
                    b.HasOne("Animal_Wiki.Models.Phylium", "Phylium")
                        .WithMany()
                        .HasForeignKey("PhyliumID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Phylium");
                });

            modelBuilder.Entity("Animal_Wiki.Models.Family", b =>
                {
                    b.HasOne("Animal_Wiki.Models.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Animal_Wiki.Models.Genius", b =>
                {
                    b.HasOne("Animal_Wiki.Models.Family", "Family")
                        .WithMany()
                        .HasForeignKey("FamilyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Family");
                });

            modelBuilder.Entity("Animal_Wiki.Models.Order", b =>
                {
                    b.HasOne("Animal_Wiki.Models.AnimalClass", "AnimalClass")
                        .WithMany()
                        .HasForeignKey("AnimalClassID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AnimalClass");
                });

            modelBuilder.Entity("Animal_Wiki.Models.Phylium", b =>
                {
                    b.HasOne("Animal_Wiki.Models.Kingdom", "Kingdom")
                        .WithMany()
                        .HasForeignKey("KingdomID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kingdom");
                });

            modelBuilder.Entity("Animal_Wiki.Models.Species", b =>
                {
                    b.HasOne("Animal_Wiki.Models.Genius", "Genius")
                        .WithMany()
                        .HasForeignKey("GeniusID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genius");
                });
#pragma warning restore 612, 618
        }
    }
}
