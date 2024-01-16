using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMusic.Data;
using System;
using System.Linq;

namespace MvcMusic.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MvcMusicContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MvcMusicContext>>()))
        {
            // Look for songs:
            if (context.Music.Any())
            {
                return;   // DB has been seeded
            }
            context.Music.AddRange(
                new Music
                {
                    Title = "Cruel Summer",
                    Artist = "Taylor Swift",
                    Genre = "ElectroPop",
                    ReleaseDate = DateTime.Parse("2023-6-20"),
                    Rating = "Excellent",
                },
                new Music
                {
                    Title = "Lovin on Me",
                    Artist = "Jack Harlow",
                    Genre = "Rap",
                    ReleaseDate = DateTime.Parse("2023-11-10"),
                    Rating = "Good",
                },
                new Music
                {
                    Title = "Greedy",
                    Artist = "Tate McRae",
                    Genre = "Pop",
                    ReleaseDate = DateTime.Parse("2023-9-15"),
                    Rating = "Very Good",
                },
                new Music
                {
                    Title = "Paint the Town Red",
                    Artist = "Doja Cat",
                    Genre = "Hip Hop",
                    ReleaseDate = DateTime.Parse("2023-8-4"),
                    Rating = "Good",
                }
            );
            context.SaveChanges();
        }
    }
}
