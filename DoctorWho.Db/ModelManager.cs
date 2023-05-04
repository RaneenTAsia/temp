using System.Reflection.Emit;
using DoctorWhoDomain;
using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db
{
    public class ModelManager
    {
        private ModelBuilder _modelBuilder;

        public ModelManager(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
        }

        public void SeedData()
        {
            SeedAuthors();
            SeedEnemies();
            SeedCompanions();
            SeedDoctors();
            SeedEpisodes();
            SeedCompanionEpisode();
            SeedEnemyEpisode();
        }

        public void SetShadowProperties()
        {
            SetEnemyProperties();
            SetCompanionProperties();
            SetDoctorProperties();
            SetAuthorProperties();
            SetEpisodeProperties();
            SetEnemyEpisodeProperties();
            SetCompanionEpisodeProperties();

        }

        private void SetCompanionEpisodeProperties()
        {
            _modelBuilder.Entity<CompanionEpisode>().HasKey(ec => ec.CompanionId);
            _modelBuilder.Entity<CompanionEpisode>().HasKey(ec => ec.EpisodeId);
        }

        private void SetEnemyEpisodeProperties()
        {
            _modelBuilder.Entity<EnemyEpisode>().HasKey(ee => ee.EpisodeId);
            _modelBuilder.Entity<EnemyEpisode>().HasKey(ee => ee.EnemyId);
        }

        private void SetEpisodeProperties()
        {
            _modelBuilder.Entity<Episode>().Property(e => e.EpisodeDate).HasColumnType("date");
            _modelBuilder.Entity<Episode>().Property<int>(e => e.SeriesNumber).HasDefaultValue(0);
            _modelBuilder.Entity<Episode>().Property<int>(e => e.EpisodeNumber).HasDefaultValue(0);
            _modelBuilder.Entity<Episode>().Property<string>(e => e.EpisodeType).HasMaxLength(32);
            _modelBuilder.Entity<Episode>().Property<string>(e => e.Title).HasMaxLength(100);
            _modelBuilder.Entity<Episode>().Property<string>(e => e.Notes).HasDefaultValue("Null");
            _modelBuilder.Entity<Episode>().Property<int?>(e => e.DoctorId).HasDefaultValue(null);
        }

        private void SetAuthorProperties()
        {
            _modelBuilder.Entity<Author>().Property<string>(a => a.AuthorName).HasMaxLength(64);
        }

        private void SetDoctorProperties()
        {
            _modelBuilder.Entity<Doctor>().Property<int>(d => d.DoctorNumber).IsRequired();
            _modelBuilder.Entity<Doctor>().Property<string>(d => d.DoctorName).HasMaxLength(64);
            _modelBuilder.Entity<Doctor>().Property(d => d.BirthDate).HasColumnType("DATE");
            _modelBuilder.Entity<Doctor>().Property(d => d.FirstEpisodeDate).HasColumnType("DATE");
            _modelBuilder.Entity<Doctor>().Property(d => d.LastEpisodeDate).HasColumnType("DATE");
        }

        private void SetCompanionProperties()
        {
            _modelBuilder.Entity<Companion>().Property<string>(c => c.CompanionName).HasMaxLength(64);
            _modelBuilder.Entity<Companion>().Property<string>(c => c.WhoPlayed).HasMaxLength(64);
        }

        private void SetEnemyProperties()
        {
            _modelBuilder.Entity<Enemy>().Property<string>(e => e.EnemyName).HasMaxLength(32);
        }

        private void SeedDoctors()
        {
            var doctorList = new Doctor[]
            {
                new Doctor{DoctorId=1,DoctorNumber=1, DoctorName = "David Tennant",
                    BirthDate = DateTime.Parse("1980-01-20"),
                    FirstEpisodeDate = DateTime.Parse("2010-5-10"),
                    LastEpisodeDate = DateTime.Parse("2013-10-10")  },

                new Doctor{DoctorId=2,DoctorNumber=2, DoctorName = "Matt Smith",
                    BirthDate = DateTime.Parse("1990-01-20"),
                    FirstEpisodeDate = DateTime.Parse("2016-5-10"),
                    LastEpisodeDate = DateTime.Parse("2017-10-10")  },

                 new Doctor{DoctorId = 3, DoctorNumber=3, DoctorName = "Peter Capaldi",
                    BirthDate = DateTime.Parse("1985-01-20"),
                    FirstEpisodeDate = DateTime.Parse("2018-1-10"),
                    LastEpisodeDate = DateTime.Parse("2018-10-10")  },

                  new Doctor{DoctorId = 4, DoctorNumber=4, DoctorName = "Christopher Eccleston",
                    BirthDate = DateTime.Parse("1992-01-20"),
                    FirstEpisodeDate = DateTime.Parse("2018-11-10"),
                    LastEpisodeDate = DateTime.Parse("2019-10-10")  },

                   new Doctor{DoctorId=5,DoctorNumber=5, DoctorName = "Jodie Whittaker",
                    BirthDate = DateTime.Parse("1990-01-20"),
                    FirstEpisodeDate = DateTime.Parse("2020-5-10"),
                    },
            };
            _modelBuilder.Entity<Doctor>().HasData(doctorList);
        }

        private void SeedEnemies()
        {
            var enemyList = new List<Enemy>()
            {
                new Enemy{EnemyId = 1, EnemyName="The Master"
                ,Description = "Fellow Time Lord that constantly tries to torment and destroy the doctor."},
                new Enemy{EnemyId = 2, EnemyName="Family of Blood"
                ,Description = "Beings that chased The Doctor for near immortality."},
                new Enemy{EnemyId = 3, EnemyName="Daleks"
                ,Description = "These robots have plagued the Doctor for centuries."},
                new Enemy{EnemyId = 4, EnemyName="Cybermen"
                ,Description = "Emotionless robots from another world that constantly change their design, becoming more powerful, and upgrading every time we see them."},
                new Enemy{EnemyId = 5, EnemyName="Weeping Angels"
                ,Description = "Horrifying stone statues that have a pretty scary design, but the real fear is how these creatures move and kill their prey."},
            };

            _modelBuilder.Entity<Enemy>().HasData(enemyList);
        }

        private void SeedAuthors()
        {
            var authorList = new List<Author> {
                new Author { AuthorId = 1, AuthorName = "Rayyan Asia"},
                new Author { AuthorId = 2, AuthorName = "Raneen Asia"},
                new Author { AuthorId = 3, AuthorName = "Rami Asia"},
                new Author { AuthorId = 4, AuthorName = "Reema Asia"},
                new Author { AuthorId = 5, AuthorName = "Karam Shawish"},
            };
            _modelBuilder.Entity<Author>().HasData(authorList);
        }
        private void SeedCompanions()
        {
            var companionList = new List<Companion> {
                new Companion {CompanionId = 1, CompanionName="Dr. Grace Hollow"
                , WhoPlayed = "Daphne Ashbrook" },
                new Companion {CompanionId = 2, CompanionName="Elizabeth Shaw"
                , WhoPlayed = "Caroline John" },
                new Companion {CompanionId = 3, CompanionName="Ace"
                , WhoPlayed = "Sophie Aldred" },
                new Companion {CompanionId = 4, CompanionName="Captain Mike Yates"
                , WhoPlayed = "Richard Franklin" },
                new Companion {CompanionId = 5, CompanionName="Melanie"
                , WhoPlayed = "Bonnie Langford" },
                new Companion {CompanionId = 6, CompanionName="TuTu"
                , WhoPlayed = "Tawfieg" },
            };
            _modelBuilder.Entity<Companion>().HasData(companionList);
        }

        private void SeedEpisodes()
        {
            var episodeList = new List<Episode> {
                new Episode { EpisodeId = 1, SeriesNumber = 1, EpisodeNumber = 1, EpisodeType = "Comedy,Eerie",
                Title = "Pilot" , EpisodeDate = DateTime.Parse("2010-5-10"), AuthorId = 1, DoctorId = 1,
                    Notes="The Best Doctor IMO" },
                new Episode { EpisodeId = 2, SeriesNumber = 2, EpisodeNumber = 1, EpisodeType = "Comedy,Eerie,Investigation",
                Title = "The Second Doctor" , EpisodeDate = DateTime.Parse("2016-5-10"), AuthorId = 2, DoctorId = 2,
                    Notes="Longest Production Episode" },
                new Episode { EpisodeId = 3, SeriesNumber = 3, EpisodeNumber = 1, EpisodeType = "Comedy,Action",
                Title = "Back to the Booth" , EpisodeDate = DateTime.Parse("2018-1-10"), AuthorId = 3, DoctorId = 3},
                new Episode { EpisodeId = 4, SeriesNumber = 4, EpisodeNumber = 1, EpisodeType = "Comedy,Detective",
                Title = "Another Doctor" , EpisodeDate = DateTime.Parse("2018-11-10"), AuthorId = 4, DoctorId = 4 },
                new Episode { EpisodeId = 5, SeriesNumber = 5, EpisodeNumber = 1, EpisodeType = "Comedy,Eerie",
                Title = "Time Is Not So Simple" , EpisodeDate = DateTime.Parse("2020-5-10"), AuthorId = 5, DoctorId = 5,
                    Notes="New Cast Who Dis?" },
                new Episode { EpisodeId = 6, SeriesNumber = 1, EpisodeNumber = 2, EpisodeType = "Comedy,Eerie",
                Title = "Our Fist Encounter" , EpisodeDate = DateTime.Parse("2010-6-10"), AuthorId = 1,
                    Notes="No Doctor" },
            };

            _modelBuilder.Entity<Episode>().HasData(episodeList);
        }

        private void SeedCompanionEpisode()
        {
            var companionEpisodes = new List<CompanionEpisode>() {
                new CompanionEpisode { EpisodeId = 1, CompanionId = 1},
                new CompanionEpisode { EpisodeId = 2, CompanionId = 2},
                new CompanionEpisode { EpisodeId = 3, CompanionId = 3},
                new CompanionEpisode { EpisodeId = 4, CompanionId = 4},
                new CompanionEpisode { EpisodeId = 5, CompanionId = 5},
                new CompanionEpisode { EpisodeId = 1, CompanionId = 2},
            };
            _modelBuilder.Entity<CompanionEpisode>().HasData(companionEpisodes);
        }

        private void SeedEnemyEpisode()
        {
            var enemyEpisodes = new List<EnemyEpisode>() {
                new EnemyEpisode {EpisodeId = 1 ,EnemyId = 1},
                new EnemyEpisode {EpisodeId = 2, EnemyId = 2},
                new EnemyEpisode {EpisodeId = 3, EnemyId = 3},
                new EnemyEpisode {EpisodeId = 4, EnemyId = 4},
                new EnemyEpisode {EpisodeId = 5, EnemyId = 5},
                new EnemyEpisode {EpisodeId = 1, EnemyId = 2},
            };
            _modelBuilder.Entity<EnemyEpisode>().HasData(enemyEpisodes);
        }

        public void SetupManytoManyRelationships()
        {
            _modelBuilder.Entity<Episode>()
                        .HasMany(e => e.Companions)
                        .WithMany(e => e.Episodes)
                        .UsingEntity<CompanionEpisode>
                        (
                            ec => ec.HasOne(e => e.Companion)
                            .WithMany()
                            .HasForeignKey(e => e.CompanionId),
                            ec => ec.HasOne(e => e.Episode)
                                 .WithMany()
                                 .HasForeignKey(e => e.EpisodeId),
                            ec =>
                            {
                                ec.ToTable("CompanionEpisode");
                                var episodeId = ec.HasIndex(e => e.EpisodeId);
                                var companionId = ec.HasIndex(e => e.CompanionId);
                                ec.HasKey(a => new { a.EpisodeId, a.CompanionId });
                            }
            );

            _modelBuilder.Entity<Episode>()
                        .HasMany(e => e.Enemies)
                        .WithMany(e => e.Episodes)
                        .UsingEntity<EnemyEpisode>
                        (
                            ee => ee.HasOne(e => e.Enemy)
                            .WithMany()
                            .HasForeignKey(e => e.EnemyId),
                            ee => ee.HasOne(e => e.Episode)
                                 .WithMany()
                                 .HasForeignKey(e => e.EpisodeId),
                            ee =>
                            {
                                ee.ToTable("EnemyEpisode");
                                ee.HasKey(a => new { a.EpisodeId, a.EnemyId });
                            }
                        );
        }

        public void MapViews()
        {
            _modelBuilder.Entity<ViewEpisodes>().HasNoKey().ToView("viewEpisodes");
        }
    }
}
