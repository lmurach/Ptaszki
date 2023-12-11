﻿// <auto-generated />
using System;
using BirdGame.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BirdGame.Migrations
{
    [DbContext(typeof(BirdDbContext))]
    [Migration("20231211022506_dailyyield2")]
    partial class dailyyield2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.13");

            modelBuilder.Entity("BirdGame.Data.BasicItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("BasicItems");
                });

            modelBuilder.Entity("BirdGame.Data.Bird", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<int>("Hunting")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<int>("Perception")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Rarity")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Strength")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Birds");
                });

            modelBuilder.Entity("BirdGame.Data.BirdConnector", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BirdId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BirdId");

                    b.HasIndex("UserId");

                    b.ToTable("BirdConnectors");
                });

            modelBuilder.Entity("BirdGame.Data.CraftableItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("CraftableItems");
                });

            modelBuilder.Entity("BirdGame.Data.ItemRelationship", b =>
                {
                    b.Property<int>("BasicItemId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CraftableItemId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("RequiredNum")
                        .HasColumnType("INTEGER");

                    b.HasKey("BasicItemId", "CraftableItemId");

                    b.HasIndex("CraftableItemId");

                    b.ToTable("ItemRelationship");
                });

            modelBuilder.Entity("BirdGame.Data.JobBird", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BirdId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("JS_BugFinder")
                        .HasColumnType("INTEGER");

                    b.Property<int>("JS_FeatherFeatcher")
                        .HasColumnType("INTEGER");

                    b.Property<int>("JS_Gatherer")
                        .HasColumnType("INTEGER");

                    b.Property<int>("JS_Hunter")
                        .HasColumnType("INTEGER");

                    b.Property<int>("JS_RockBreaker")
                        .HasColumnType("INTEGER");

                    b.Property<int>("JS_SeedCollector")
                        .HasColumnType("INTEGER");

                    b.Property<string>("JobTitle")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("SlotNum")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BirdId");

                    b.HasIndex("UserId");

                    b.ToTable("jobBirds");
                });

            modelBuilder.Entity("BirdGame.Data.RolledSSB", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BirdId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SlotNum")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BirdId");

                    b.HasIndex("UserId");

                    b.ToTable("RolledSSBs");
                });

            modelBuilder.Entity("BirdGame.Data.SideShopBird", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BirdId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SlotNum")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Star")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BirdId");

                    b.HasIndex("UserId");

                    b.ToTable("SideShopBirds");
                });

            modelBuilder.Entity("BirdGame.Data.UserCraftItem", b =>
                {
                    b.Property<string>("UserGameId")
                        .HasColumnType("text");

                    b.Property<int>("CraftableItemId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.HasKey("UserGameId", "CraftableItemId");

                    b.HasIndex("CraftableItemId");

                    b.ToTable("UserCraftItem");
                });

            modelBuilder.Entity("BirdGame.Data.UserGame", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<DateTime>("LastDailyRoll")
                        .HasColumnType("Date");

                    b.Property<int>("RarityUpgrade")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Seeds")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("UserGames");
                });

            modelBuilder.Entity("BirdGame.Data.UserIR", b =>
                {
                    b.Property<string>("UserGameId")
                        .HasColumnType("text");

                    b.Property<int>("BasicItemId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("OwnedNum")
                        .HasColumnType("INTEGER");

                    b.HasKey("UserGameId", "BasicItemId");

                    b.HasIndex("BasicItemId");

                    b.ToTable("UserIR");
                });

            modelBuilder.Entity("BirdGame.Data.Yield", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Amount")
                        .HasColumnType("INTEGER");

                    b.Property<int>("BasicItemId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BasicItemId");

                    b.HasIndex("UserId");

                    b.ToTable("Yields");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("BirdGame.Data.BirdConnector", b =>
                {
                    b.HasOne("BirdGame.Data.Bird", "Bird")
                        .WithMany()
                        .HasForeignKey("BirdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BirdGame.Data.UserGame", "User")
                        .WithMany("OwnedBirds")
                        .HasForeignKey("UserId");

                    b.Navigation("Bird");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BirdGame.Data.ItemRelationship", b =>
                {
                    b.HasOne("BirdGame.Data.BasicItem", "BasicItem")
                        .WithMany("itemRelationships")
                        .HasForeignKey("BasicItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BirdGame.Data.CraftableItem", "CraftableItem")
                        .WithMany("itemRelationships")
                        .HasForeignKey("CraftableItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BasicItem");

                    b.Navigation("CraftableItem");
                });

            modelBuilder.Entity("BirdGame.Data.JobBird", b =>
                {
                    b.HasOne("BirdGame.Data.Bird", "Bird")
                        .WithMany()
                        .HasForeignKey("BirdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BirdGame.Data.UserGame", "User")
                        .WithMany("jobBirds")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bird");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BirdGame.Data.RolledSSB", b =>
                {
                    b.HasOne("BirdGame.Data.Bird", "Bird")
                        .WithMany()
                        .HasForeignKey("BirdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BirdGame.Data.UserGame", "User")
                        .WithMany("rolledSSBs")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bird");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BirdGame.Data.SideShopBird", b =>
                {
                    b.HasOne("BirdGame.Data.Bird", "Bird")
                        .WithMany()
                        .HasForeignKey("BirdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BirdGame.Data.UserGame", "User")
                        .WithMany("sideShopBirds")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bird");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BirdGame.Data.UserCraftItem", b =>
                {
                    b.HasOne("BirdGame.Data.CraftableItem", "CraftableItem")
                        .WithMany("userCraftItems")
                        .HasForeignKey("CraftableItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BirdGame.Data.UserGame", "UserGame")
                        .WithMany("userCraftItems")
                        .HasForeignKey("UserGameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CraftableItem");

                    b.Navigation("UserGame");
                });

            modelBuilder.Entity("BirdGame.Data.UserIR", b =>
                {
                    b.HasOne("BirdGame.Data.BasicItem", "BasicItem")
                        .WithMany("userIRs")
                        .HasForeignKey("BasicItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BirdGame.Data.UserGame", "UserGame")
                        .WithMany("userIRs")
                        .HasForeignKey("UserGameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BasicItem");

                    b.Navigation("UserGame");
                });

            modelBuilder.Entity("BirdGame.Data.Yield", b =>
                {
                    b.HasOne("BirdGame.Data.BasicItem", "BasicItem")
                        .WithMany()
                        .HasForeignKey("BasicItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BirdGame.Data.UserGame", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BasicItem");

                    b.Navigation("User");
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

            modelBuilder.Entity("BirdGame.Data.BasicItem", b =>
                {
                    b.Navigation("itemRelationships");

                    b.Navigation("userIRs");
                });

            modelBuilder.Entity("BirdGame.Data.CraftableItem", b =>
                {
                    b.Navigation("itemRelationships");

                    b.Navigation("userCraftItems");
                });

            modelBuilder.Entity("BirdGame.Data.UserGame", b =>
                {
                    b.Navigation("OwnedBirds");

                    b.Navigation("jobBirds");

                    b.Navigation("rolledSSBs");

                    b.Navigation("sideShopBirds");

                    b.Navigation("userCraftItems");

                    b.Navigation("userIRs");
                });
#pragma warning restore 612, 618
        }
    }
}
