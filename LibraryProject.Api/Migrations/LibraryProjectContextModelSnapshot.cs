﻿// <auto-generated />
using LibraryProject.Api.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LibraryProject.Api.Migrations
{
    [DbContext(typeof(LibraryProjectContext))]
    partial class LibraryProjectContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LibraryProject.Api.Database.Entites.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<short>("BirthYear")
                        .HasColumnType("smallint");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(50)");

                    b.Property<short?>("YearOfDeath")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.ToTable("Author");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BirthYear = (short)1948,
                            FirstName = "George",
                            LastName = "Martin",
                            MiddleName = "R.R."
                        },
                        new
                        {
                            Id = 2,
                            BirthYear = (short)1832,
                            FirstName = "Lewis",
                            LastName = "Carol",
                            MiddleName = "",
                            YearOfDeath = (short)1898
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
