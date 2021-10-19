﻿// <auto-generated />
using Life_foods_api_csharp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Life_foods_api_csharp.Migrations
{
    [DbContext(typeof(FoodApiContext))]
    partial class FoodApiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Life_foods_api_csharp.Models.Food", b =>
                {
                    b.Property<int>("FoodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Carbs")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("Energy")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Fats")
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<decimal>("Proteins")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("Weight")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("FoodId");

                    b.HasAlternateKey("Name");

                    b.ToTable("Foods");
                });

            modelBuilder.Entity("Life_foods_api_csharp.Models.Ingredient", b =>
                {
                    b.Property<int>("IngredientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("IngredientName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("IngredientId");

                    b.HasAlternateKey("IngredientName");

                    b.ToTable("IngredientNames");
                });
#pragma warning restore 612, 618
        }
    }
}
