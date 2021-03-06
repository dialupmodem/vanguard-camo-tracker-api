// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Vanguard.CamoTracker.Data;

#nullable disable

namespace Vanguard.CamoTracker.Data.Migrations
{
    [DbContext(typeof(CamoTrackerContext))]
    partial class CamoTrackerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0-preview.2.22153.1");

            modelBuilder.Entity("Vanguard.CamoTracker.Data.Entities.Weapon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Image")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int?>("WeaponCategoryId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("WeaponCategoryId");

                    b.ToTable("Weapons");
                });

            modelBuilder.Entity("Vanguard.CamoTracker.Data.Entities.WeaponCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("WeaponCategories");
                });

            modelBuilder.Entity("Vanguard.CamoTracker.Data.Entities.WeaponChallenge", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CamoName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Progress")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Requirement")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("WeaponId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("WeaponId");

                    b.ToTable("WeaponChallenges");
                });

            modelBuilder.Entity("Vanguard.CamoTracker.Data.Entities.Weapon", b =>
                {
                    b.HasOne("Vanguard.CamoTracker.Data.Entities.WeaponCategory", "WeaponCategory")
                        .WithMany("Weapons")
                        .HasForeignKey("WeaponCategoryId");

                    b.Navigation("WeaponCategory");
                });

            modelBuilder.Entity("Vanguard.CamoTracker.Data.Entities.WeaponChallenge", b =>
                {
                    b.HasOne("Vanguard.CamoTracker.Data.Entities.Weapon", "Weapon")
                        .WithMany("Challenges")
                        .HasForeignKey("WeaponId");

                    b.Navigation("Weapon");
                });

            modelBuilder.Entity("Vanguard.CamoTracker.Data.Entities.Weapon", b =>
                {
                    b.Navigation("Challenges");
                });

            modelBuilder.Entity("Vanguard.CamoTracker.Data.Entities.WeaponCategory", b =>
                {
                    b.Navigation("Weapons");
                });
#pragma warning restore 612, 618
        }
    }
}
