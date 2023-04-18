using Microsoft.EntityFrameworkCore;
using VideoGameReviewSite.Models;

namespace VideoGameReviewSite.Data
{
    public class VideoGameContext : DbContext
    {
        public DbSet<ProductVideoGameModel> VideoGame { get; set; }
        public DbSet<ReviewModel> Publishers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            String connectionString = "Server=(localdb)\\mssqllocaldb;Database=VideoGameSite5;Trusted_Connection=True;";
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReviewModel>().HasData(
                new ReviewModel()
                {
                    Id = 1,
                    Name = "Activision",
                },
                new ReviewModel()
                {
                    Id = 2,
                    Name = "Electronic Arts",
                });
            modelBuilder.Entity<ProductVideoGameModel>().HasData(
                new ProductVideoGameModel()
                { 

                    Id = 1,
                    Title = "Call of Duty: Modern Warfare II",
                    Image = "https://upload.wikimedia.org/wikipedia/en/4/4a/Call_of_Duty_Modern_Warfare_II_Key_Art.jpg",
                    PublishersId = 1,
                    Description = "Call of Duty: Modern Warfare II is a 2022 first-person shooter game developed by Infinity Ward and published by Activision. It is a sequel to the 2019 reboot, and serves as the nineteenth installment in the overall Call of Duty series.",
                    Reviews = "Troll Capital and full of glitches TL;DR: UI is full of bugs and issues. DMZ is full of squad hunting Trolls, multiplayer is full of hyped up Call of Duty League wanna bees, with either Smgs or no scope Snipers. The assault rifles all suck by comparision. ",
                    ReleaseDate = "10/28/2022",
                    Cost = 31.81,
                },
                new ProductVideoGameModel()
                {
                    Id = 2,
                    Title = "The Sims",
                    Image = "https://upload.wikimedia.org/wikipedia/en/2/22/The_Sims_Coverart.png",
                    PublishersId = 2,
                    Description = "It is a simulation of the daily activities of one or more virtual people,Players control customizable Sims as they pursue career and relationship goals. Players can also use their Sims' income to renovate their living space, and purchase home furnishings, or clothing for their household. Players can also choose to pursue a social and successful life.",
                    Reviews = "This game is so, so, so, good, but has it's problems. The OST is some of the best I've heard in video games as a whole, the gameplay is challenging and exciting, and this game as so much personality to it. However, the game is wayyy too hard to actually relax in it ",
                    ReleaseDate = "02/04/2000",
                    Cost = 29.95,
                });
        }
    }
}
