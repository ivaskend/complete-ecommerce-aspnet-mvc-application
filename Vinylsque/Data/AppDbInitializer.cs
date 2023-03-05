using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vinylsque.Models;

namespace Vinylsque.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //AlbumFormats
                if (!context.AlbumFormats.Any())
                {
                    context.AlbumFormats.AddRange(new List<AlbumFormats>()
                    {
                        new AlbumFormats()
                        {
                            Name = "EP",
                        },
                        new AlbumFormats()
                        {
                            Name = "LP",
                        },
                        new AlbumFormats()
                        {
                            Name = "2LP",
                        },
                        new AlbumFormats()
                        {
                            Name = "Single",
                        },
                    });
                    context.SaveChanges();
                }
                //Artists
                if (!context.Artists.Any())
                {
                    context.Artists.AddRange(new List<Artist>()
                    {
                        new Artist()
                        {
                            FullName = "Rihanna",
                            Bio = "This is the Bio of the first actor",
                            ProfilePictureURL = "https://imageio.forbes.com/specials-images/imageserve/5ceec355142c500008f42068/Rihanna-Diamond-Ball-Forbes-Women/0x0.jpg?format=jpg&crop=1950,1950,x32,y257,safe&height=1950&width=1950"

                        },
                        new Artist()
                        {
                            FullName = "The Beatles",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "https://yt3.googleusercontent.com/5lOkozHE7R-TL0iHNetrVWai47pG7Oa6bJvW4CiUGCMsRUjqXSUAlJWDgpkjdc12iKm0GwzF0Cw=s900-c-k-c0x00ffffff-no-rj"
                        },
                        new Artist()
                        {
                            FullName = "Queen",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "https://cdn.britannica.com/83/149183-050-25913164/Queen.jpg"
                        },
                        new Artist()
                        {
                            FullName = "ABBA",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-4.jpeg"
                        },
                        new Artist()
                        {
                            FullName = "Artist 5",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-5.jpeg"
                        }
                    });
                    context.SaveChanges();

                }
                //RecordLabel
                if (!context.RecordLabels.Any())
                {
                    context.RecordLabels.AddRange(new List<RecordLabel>()
                    {
                        new RecordLabel()
                        {
                            FullName = "Abbey Road Studios",
                            Bio = "This is the Bio of the first record label",
                            ProfilePictureURL = "http://dotnethow.net/images/producers/producer-1.jpeg"

                        },
                        new RecordLabel()
                        {
                            FullName = "Bravado",
                            Bio = "This is the Bio of the second record label",
                            ProfilePictureURL = "http://dotnethow.net/images/producers/producer-2.jpeg"
                        },
                        new RecordLabel()
                        {
                            FullName = "Capitol Music Group",
                            Bio = "This is the Bio of the third record label ",
                            ProfilePictureURL = "http://dotnethow.net/images/producers/producer-3.jpeg"
                        },
                        new RecordLabel()
                        {
                            FullName = "Decca Records",
                            Bio = "This is the Bio of the fourth recor label",
                            ProfilePictureURL = "http://dotnethow.net/images/producers/producer-4.jpeg"
                        },
                        new RecordLabel()
                        {
                            FullName = "Def Jam Recordings",
                            Bio = "This is the Bio of the fifth record label",
                            ProfilePictureURL = "http://dotnethow.net/images/producers/producer-5.jpeg"
                        }
                    });
                    context.SaveChanges();

                }
                //Vinyls
                if (!context.Vinyls.Any())
                {
                    context.Vinyls.AddRange(new List<Vinyl>()
                    {
                        new Vinyl()
                        {
                            Name = "Let It Be Special Edition",
                            Description = "This is the Let It be vinyl description",
                            Price = 29.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-3.jpeg",
                            AlbumFormatsId = 1,
                            RecordLabelId = 3,
                            VinylGenre = VinylGenre.AlternativeRock
                        },
                        new Vinyl()
                        {
                            Name = "Tattoo You (2021 Remaster) 2LP",
                            Description = "This is the Tattoo You (2021 Remaster) 2LP description",
                            Price = 29.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-1.jpeg",
                            AlbumFormatsId = 3,
                            RecordLabelId = 1,
                            VinylGenre = VinylGenre.AlternativeRock
                        },
                        new Vinyl()
                        {
                            Name = "Music Of The Sun (Opaque Yellow Limited Edition)",
                            Description = "This is the Music Of The Sun (Opaque Yellow Limited Edition) description",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-4.jpeg",
                            AlbumFormatsId = 3,
                            RecordLabelId = 1,
                            VinylGenre = VinylGenre.Pop
                        },
                        new Vinyl()
                        {
                            Name = "Pink Floyd Tribute: Still Wish You Were Here (Silver Limited Edition)",
                            Description = "This is the Pink Floyd Tribute: Still Wish You Were Here (Silver Limited Edition) description",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-6.jpeg",
                            AlbumFormatsId = 1,
                            RecordLabelId = 2,
                            VinylGenre = VinylGenre.ClassicRock
                        },
                        new Vinyl()
                        {
                            Name = "Gold: Greatest Hits",
                            Description = "This is the Gold: Greatest Hits description",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-7.jpeg",
                            AlbumFormatsId = 1,
                            RecordLabelId = 2,
                            VinylGenre = VinylGenre.ClassicRock
                        },
                        new Vinyl()
                        {
                            Name = "Greatest Hits II",
                            Description = "This is the Greatest Hits II description",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-8.jpeg",
                            AlbumFormatsId = 1,
                            RecordLabelId = 2,
                            VinylGenre = VinylGenre.ClassicRock
                        }
                    });
                    context.SaveChanges();

                }
                //Vinyl_Artists
                if (!context.Vinyls_Artist.Any())
                {
                    context.Vinyls_Artist.AddRange(new List<Vinyl_Artist>()
                    {
                        new Vinyl_Artist()
                        {
                            ArtistId = 1,
                            VinylId = 1
                        },
                        new Vinyl_Artist()
                        {
                            ArtistId = 3,
                            VinylId = 1
                        },

                         new Vinyl_Artist()
                        {
                            ArtistId = 1,
                            VinylId = 2
                        },
                         new Vinyl_Artist()
                        {
                            ArtistId = 4,
                            VinylId = 2
                        },

                        new Vinyl_Artist()
                        {
                            ArtistId = 1,
                            VinylId = 3
                        },
                        new Vinyl_Artist()
                        {
                            ArtistId = 2,
                            VinylId = 3
                        },
                        new Vinyl_Artist()
                        {
                            ArtistId = 5,
                            VinylId = 3
                        },

                        new Vinyl_Artist()
                        {
                            ArtistId = 2,
                            VinylId = 4
                        },
                        new Vinyl_Artist()
                        {
                            ArtistId = 3,
                            VinylId = 4
                        },
                        new Vinyl_Artist()
                        {
                            ArtistId = 4,
                            VinylId = 4
                        },
                        new Vinyl_Artist()
                        {
                            ArtistId = 2,
                            VinylId = 5
                        },
                        new Vinyl_Artist()
                        {
                            ArtistId = 3,
                            VinylId = 5
                        },
                        new Vinyl_Artist()
                        {
                            ArtistId = 4,
                            VinylId = 5
                        },
                        new Vinyl_Artist()
                        {
                            ArtistId = 5,
                            VinylId = 5
                        },


                        new Vinyl_Artist()
                        {
                            ArtistId = 3,
                            VinylId = 6
                        },
                        new Vinyl_Artist()
                        {
                            ArtistId = 4,
                            VinylId = 6
                        },
                        new Vinyl_Artist()
                        {
                            ArtistId = 5,
                            VinylId = 6
                        },
                    });
                    context.SaveChanges();

                }
            }
        }
    }
}

