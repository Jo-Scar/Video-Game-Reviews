﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VideoGameReviewSite.Data;

#nullable disable

namespace VideoGameReviewSite.Migrations
{
    [DbContext(typeof(VideoGameContext))]
    partial class VideoGameContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("VideoGameReviewSite.Models.ProductVideoGameModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Cost")
                        .HasColumnType("float");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PublishersId")
                        .HasColumnType("int");

                    b.Property<string>("ReleaseDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Reviews")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PublishersId");

                    b.ToTable("VideoGame");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cost = 31.809999999999999,
                            Description = "Call of Duty: Modern Warfare II is a 2022 first-person shooter game developed by Infinity Ward and published by Activision. It is a sequel to the 2019 reboot, and serves as the nineteenth installment in the overall Call of Duty series.",
                            Image = "https://upload.wikimedia.org/wikipedia/en/4/4a/Call_of_Duty_Modern_Warfare_II_Key_Art.jpg",
                            PublishersId = 1,
                            ReleaseDate = "10/28/2022",
                            Reviews = "Troll Capital and full of glitches TL;DR: UI is full of bugs and issues. DMZ is full of squad hunting Trolls, multiplayer is full of hyped up Call of Duty League wanna bees, with either Smgs or no scope Snipers. The assault rifles all suck by comparision. ",
                            Title = "Call of Duty: Modern Warfare II"
                        },
                        new
                        {
                            Id = 2,
                            Cost = 29.949999999999999,
                            Description = "It is a simulation of the daily activities of one or more virtual people,Players control customizable Sims as they pursue career and relationship goals. Players can also use their Sims' income to renovate their living space, and purchase home furnishings, or clothing for their household. Players can also choose to pursue a social and successful life.",
                            Image = "https://upload.wikimedia.org/wikipedia/en/2/22/The_Sims_Coverart.png",
                            PublishersId = 2,
                            ReleaseDate = "02/04/2000",
                            Reviews = "This game is so, so, so, good, but has it's problems. The OST is some of the best I've heard in video games as a whole, the gameplay is challenging and exciting, and this game as so much personality to it. However, the game is wayyy too hard to actually relax in it ",
                            Title = "The Sims"
                        });
                });

            modelBuilder.Entity("VideoGameReviewSite.Models.ReviewModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Publishers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Activision"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Electronic Arts"
                        });
                });

            modelBuilder.Entity("VideoGameReviewSite.Models.ProductVideoGameModel", b =>
                {
                    b.HasOne("VideoGameReviewSite.Models.ReviewModel", "Publishers")
                        .WithMany("VideoGame")
                        .HasForeignKey("PublishersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Publishers");
                });

            modelBuilder.Entity("VideoGameReviewSite.Models.ReviewModel", b =>
                {
                    b.Navigation("VideoGame");
                });
#pragma warning restore 612, 618
        }
    }
}