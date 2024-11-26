﻿// <auto-generated />
using System;
using Cocktail.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Cocktail.Infrastructure.Migrations
{
    [DbContext(typeof(CocktailContext))]
    partial class CocktailContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("Cocktail.Domain.Aggregates.Cocktail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset?>("DeletedOn")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset?>("LastModifiedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Cocktail");
                });

            modelBuilder.Entity("Cocktail.Domain.Aggregates.Composition", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("CocktailId")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset?>("DeletedOn")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("IngredientId")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset?>("LastModifiedOn")
                        .HasColumnType("TEXT");

                    b.Property<double>("Quantity")
                        .HasColumnType("REAL");

                    b.Property<int>("Unit")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CocktailId");

                    b.HasIndex("IngredientId");

                    b.ToTable("Composition");
                });

            modelBuilder.Entity("Cocktail.Domain.Aggregates.Ingredient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<double>("AlcoholLevel")
                        .HasColumnType("REAL");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset?>("DeletedOn")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset?>("LastModifiedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Ingredient");
                });

            modelBuilder.Entity("Cocktail.Domain.Aggregates.Step", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("CocktailId")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset?>("DeletedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset?>("LastModifiedOn")
                        .HasColumnType("TEXT");

                    b.Property<int>("Order")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CocktailId");

                    b.ToTable("Step");
                });

            modelBuilder.Entity("Cocktail.Domain.Aggregates.Composition", b =>
                {
                    b.HasOne("Cocktail.Domain.Aggregates.Cocktail", null)
                        .WithMany("Compositions")
                        .HasForeignKey("CocktailId");

                    b.HasOne("Cocktail.Domain.Aggregates.Ingredient", "Ingredient")
                        .WithMany()
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingredient");
                });

            modelBuilder.Entity("Cocktail.Domain.Aggregates.Step", b =>
                {
                    b.HasOne("Cocktail.Domain.Aggregates.Cocktail", null)
                        .WithMany("Steps")
                        .HasForeignKey("CocktailId");
                });

            modelBuilder.Entity("Cocktail.Domain.Aggregates.Cocktail", b =>
                {
                    b.Navigation("Compositions");

                    b.Navigation("Steps");
                });
#pragma warning restore 612, 618
        }
    }
}
