﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SchoolTripsReservationSystem.Infrastructure.Data;

#nullable disable

namespace SchoolTripsReservationSystem.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "dea12856-c198-4129-b3f3-b893d8395082",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "b8e78f12-7602-407c-ac47-0cf4b77bcd0a",
                            Email = "admin@mail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "admin@mail.com",
                            NormalizedUserName = "admin@mail.com",
                            PasswordHash = "AQAAAAEAACcQAAAAEOck3vwqHKz0tpC57kYgNwNSxnE0jiH7sxcLqGnjWvbmd+d2L+c+h6LprCHXm8Zfig==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "f0f904e1-eeeb-47ba-9c17-7ad0d4a9c93a",
                            TwoFactorEnabled = false,
                            UserName = "admin@mail.com"
                        },
                        new
                        {
                            Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "204bc6fa-b97e-4cbc-be06-9acfd2fab7ac",
                            Email = "teacher@mail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "teacher@mail.com",
                            NormalizedUserName = "teacher@mail.com",
                            PasswordHash = "AQAAAAEAACcQAAAAEIDLjTFfriPPNqZm3l8XN4lq+seePQlSMNXwgKBMAFvu+5IN6pLCXA9lDOf8QpYxaQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "47440ed0-8a68-496f-a5b2-3a44648401df",
                            TwoFactorEnabled = false,
                            UserName = "teacher@mail.com"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("SchoolTripsReservationSystem.Infrastructure.Data.Models.Excursion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Excursion identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasComment("Excursion Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Excursion name");

                    b.Property<decimal>("PricePerAdult")
                        .HasColumnType("decimal(18,2)")
                        .HasComment("Excursion price per adult-escort");

                    b.Property<decimal>("PricePerStudent")
                        .HasColumnType("decimal(18,2)")
                        .HasComment("Excursion price per student");

                    b.Property<int>("RegionId")
                        .HasColumnType("int")
                        .HasComment("Region identifier");

                    b.HasKey("Id");

                    b.HasIndex("RegionId");

                    b.ToTable("Excursions");

                    b.HasComment("School excursion");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Magurata Cave, Baba Vida Fortress, Ledenika Cave, Historical Museum, Kozloduy",
                            Name = "Northwest Bulgaria",
                            PricePerAdult = 600.00m,
                            PricePerStudent = 500.00m,
                            RegionId = 1
                        },
                        new
                        {
                            Id = 2,
                            Description = "The Seven Rila Lakes, Rila Monastery, Tsarska Bistrica, Historical Museum",
                            Name = "The Seven Rila Lakes",
                            PricePerAdult = 400.00m,
                            PricePerStudent = 300.00m,
                            RegionId = 4
                        },
                        new
                        {
                            Id = 3,
                            Description = "Nessebar, Begliktash, ethnographic museum, Bulgarka-nestinari village, Bastet's cave",
                            Name = "Strandzha",
                            PricePerAdult = 450.00m,
                            PricePerStudent = 350.00m,
                            RegionId = 3
                        });
                });

            modelBuilder.Entity("SchoolTripsReservationSystem.Infrastructure.Data.Models.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Region identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Regions");

                    b.HasComment("Geographic region");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            Name = "Northeast"
                        },
                        new
                        {
                            Id = 1,
                            Name = "Northwest"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Southwest"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Southeast"
                        });
                });

            modelBuilder.Entity("SchoolTripsReservationSystem.Infrastructure.Data.Models.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Reservation identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("EscortAdultCount")
                        .HasColumnType("int")
                        .HasComment("Count of the adults");

                    b.Property<int>("ExcursionId")
                        .HasColumnType("int")
                        .HasComment("Excursion identifier");

                    b.Property<string>("GroupLeaderId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasComment("User ID of the group leader - teacher");

                    b.Property<int>("SchoolId")
                        .HasColumnType("int")
                        .HasComment("School identifier");

                    b.Property<DateTime>("StartingDate")
                        .HasColumnType("datetime2")
                        .HasComment("Date of departure");

                    b.Property<int>("StudentCount")
                        .HasColumnType("int")
                        .HasComment("Count of the students");

                    b.Property<int>("TeacherCount")
                        .HasColumnType("int")
                        .HasComment("Count of the teachers, without group leader");

                    b.Property<int>("TransportId")
                        .HasColumnType("int")
                        .HasComment("Transport identifier");

                    b.HasKey("Id");

                    b.HasIndex("ExcursionId");

                    b.HasIndex("GroupLeaderId");

                    b.HasIndex("SchoolId");

                    b.HasIndex("TransportId");

                    b.ToTable("Reservations");

                    b.HasComment("Reservation for school trip");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EscortAdultCount = 0,
                            ExcursionId = 1,
                            GroupLeaderId = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                            SchoolId = 2,
                            StartingDate = new DateTime(2024, 6, 15, 10, 0, 0, 0, DateTimeKind.Unspecified),
                            StudentCount = 10,
                            TeacherCount = 1,
                            TransportId = 1
                        },
                        new
                        {
                            Id = 2,
                            EscortAdultCount = 2,
                            ExcursionId = 3,
                            GroupLeaderId = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                            SchoolId = 1,
                            StartingDate = new DateTime(2024, 5, 20, 10, 0, 0, 0, DateTimeKind.Unspecified),
                            StudentCount = 44,
                            TeacherCount = 3,
                            TransportId = 3
                        });
                });

            modelBuilder.Entity("SchoolTripsReservationSystem.Infrastructure.Data.Models.School", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("School identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("School address");

                    b.Property<string>("Eik")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)")
                        .HasComment("School identification number");

                    b.Property<string>("Mol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("School director name/MOL");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("School official name");

                    b.HasKey("Id");

                    b.HasIndex("Eik")
                        .IsUnique();

                    b.ToTable("Schools");

                    b.HasComment("School data");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Varna, 32 Kliment Ohridski str.",
                            Eik = "000123654",
                            Mol = "Ivan Ianov",
                            Name = "St. Kliment Ohridski"
                        },
                        new
                        {
                            Id = 2,
                            Address = "Sofia, 78 Vardar str.",
                            Eik = "000987456",
                            Mol = "Petar Petrov",
                            Name = "St. st. Kiril and Metodi"
                        });
                });

            modelBuilder.Entity("SchoolTripsReservationSystem.Infrastructure.Data.Models.Transport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Transport identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Transport name");

                    b.Property<int>("TransportCapacity")
                        .HasColumnType("int")
                        .HasComment("Мaximum number of seats in the vehicle");

                    b.HasKey("Id");

                    b.ToTable("Transports");

                    b.HasComment("Transport for excursion");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Microbus",
                            TransportCapacity = 18
                        },
                        new
                        {
                            Id = 2,
                            Name = "Autobus32",
                            TransportCapacity = 32
                        },
                        new
                        {
                            Id = 3,
                            Name = "Autobus55",
                            TransportCapacity = 55
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SchoolTripsReservationSystem.Infrastructure.Data.Models.Excursion", b =>
                {
                    b.HasOne("SchoolTripsReservationSystem.Infrastructure.Data.Models.Region", "Region")
                        .WithMany("Excursions")
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Region");
                });

            modelBuilder.Entity("SchoolTripsReservationSystem.Infrastructure.Data.Models.Reservation", b =>
                {
                    b.HasOne("SchoolTripsReservationSystem.Infrastructure.Data.Models.Excursion", "Excursion")
                        .WithMany("Reservations")
                        .HasForeignKey("ExcursionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "GroupLeader")
                        .WithMany()
                        .HasForeignKey("GroupLeaderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolTripsReservationSystem.Infrastructure.Data.Models.School", "School")
                        .WithMany("Reservations")
                        .HasForeignKey("SchoolId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SchoolTripsReservationSystem.Infrastructure.Data.Models.Transport", "Transport")
                        .WithMany("Reservations")
                        .HasForeignKey("TransportId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Excursion");

                    b.Navigation("GroupLeader");

                    b.Navigation("School");

                    b.Navigation("Transport");
                });

            modelBuilder.Entity("SchoolTripsReservationSystem.Infrastructure.Data.Models.Excursion", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("SchoolTripsReservationSystem.Infrastructure.Data.Models.Region", b =>
                {
                    b.Navigation("Excursions");
                });

            modelBuilder.Entity("SchoolTripsReservationSystem.Infrastructure.Data.Models.School", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("SchoolTripsReservationSystem.Infrastructure.Data.Models.Transport", b =>
                {
                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
