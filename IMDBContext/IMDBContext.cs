using EfEx.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using EfEx;

namespace EfEx
{
    public class IMDBContext : DbContext
    {
        public DbSet<NameBasics> NameBasics { get; set; }
        public DbSet<Actors> Actors { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Professions> Professions { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<KnownForTitles> KnownForTitles { get; set; }
        public DbSet<TitleBasics> TitleBasics { get; set; }
        public DbSet<TitleEpisode> TitleEpisode { get; set; }
        public DbSet<TvSeries> TvSeries { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<TitleRating> TitleRating { get; set; }
        public DbSet<OmdbData> OmdbData { get; set; }
        public DbSet<AppUser> AppUser { get; set; }
        public DbSet<SearchHistory> SearchHistory { get; set; }
        public DbSet<UserRating> UserRating { get; set; }
        public DbSet<BookmarkPeople> BookmarkPeople { get; set; }
        public DbSet<BookmarkTitle> BookmarkTitle { get; set; }
        public DbSet<Wi> Wi { get; set; }
        public DbSet<SimilarMovies> SimilarMovies { get; set; }

        private readonly string _connectionString;

        public IMDBContext(string connectionString)
        {
            _connectionString = connectionString;
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseNpgsql("host=localhost;db=imdb_small;uid=postgres;pwd=@DAc43712");

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<NameBasics>().ToTable("name_basics");
            modelBuilder.Entity<NameBasics>().Property(x => x.PersonId).HasColumnName("nconst");
            modelBuilder.Entity<NameBasics>().Property(x => x.PersonName).HasColumnName("primaryname");
            modelBuilder.Entity<NameBasics>().Property(x => x.BirthYear).HasColumnName("birthyear");
            modelBuilder.Entity<NameBasics>().Property(x => x.DeathYear).HasColumnName("deathyear");
            modelBuilder.Entity<NameBasics>().HasKey(c => new { c.PersonId });

            modelBuilder.Entity<Actors>().ToTable("actors");
            modelBuilder.Entity<Actors>().Property(x => x.FilmId).HasColumnName("tconst");
            modelBuilder.Entity<Actors>().Property(x => x.PersonId).HasColumnName("nconst");
            modelBuilder.Entity<Actors>().Property(x => x.Ordering).HasColumnName("ordering");
            modelBuilder.Entity<Actors>().Property(x => x.Characters).HasColumnName("characters");
            modelBuilder.Entity<Actors>().Property(x => x.Category).HasColumnName("category");
            modelBuilder.Entity<Actors>().HasKey(c => new { c.FilmId, c.PersonId });


            modelBuilder.Entity<Staff>().ToTable("staff");
            modelBuilder.Entity<Staff>().Property(x => x.FilmId).HasColumnName("tconst");
            modelBuilder.Entity<Staff>().Property(x => x.PersonId).HasColumnName("nconst");
            modelBuilder.Entity<Staff>().Property(x => x.Ordering).HasColumnName("ordering");
            modelBuilder.Entity<Staff>().Property(x => x.Job).HasColumnName("job");
            modelBuilder.Entity<Staff>().Property(x => x.PersonId).HasColumnName("nconst");
            modelBuilder.Entity<Staff>().HasKey(c => new { c.PersonId, c.FilmId });


            modelBuilder.Entity<Professions>().ToTable("professions");
            modelBuilder.Entity<Professions>().Property(x => x.PersonId).HasColumnName("nconst");
            modelBuilder.Entity<Professions>().Property(x => x.Profession).HasColumnName("profession");
            modelBuilder.Entity<Professions>().HasKey(c => new { c.PersonId });

            modelBuilder.Entity<Category>().ToTable("category");
            modelBuilder.Entity<Category>().Property(x => x.CategoryName).HasColumnName("category_name");
            modelBuilder.Entity<Category>().Property(x => x.JobTitle).HasColumnName("job_title");


            modelBuilder.Entity<KnownForTitles>().ToTable("knowfortitles");
            modelBuilder.Entity<KnownForTitles>().Property(x => x.PersonId).HasColumnName("category_name");
            modelBuilder.Entity<KnownForTitles>().Property(x => x.FilmId).HasColumnName("job_title");
            modelBuilder.Entity<KnownForTitles>().HasKey(c => new { c.FilmId, c.PersonId });

            modelBuilder.Entity<TitleBasics>().ToTable("title_basics");
            modelBuilder.Entity<TitleBasics>().Property(x => x.FilmId).HasColumnName("tconst");
            modelBuilder.Entity<TitleBasics>().Property(x => x.TitleType).HasColumnName("titletype");
            modelBuilder.Entity<TitleBasics>().Property(x => x.OriginalTitle).HasColumnName("originaltitle");
            modelBuilder.Entity<TitleBasics>().Property(x => x.YearRelease).HasColumnName("startyear");
            modelBuilder.Entity<TitleBasics>().Property(x => x.RuntimeMinutes).HasColumnName("runtimeminutes");
            modelBuilder.Entity<TitleBasics>().HasKey(c => new { c.FilmId });

            modelBuilder.Entity<TitleEpisode>().ToTable("title_episode");
            modelBuilder.Entity<TitleEpisode>().Property(x => x.FilmId).HasColumnName("tconst");
            modelBuilder.Entity<TitleEpisode>().Property(x => x.ParentTconst).HasColumnName("parenttconst");
            modelBuilder.Entity<TitleEpisode>().Property(x => x.SeasonNumber).HasColumnName("seasonnumber");
            modelBuilder.Entity<TitleEpisode>().Property(x => x.EpisodeNumber).HasColumnName("episodenumber");
            modelBuilder.Entity<TitleEpisode>().Property(x => x.EpisodeName).HasColumnName("episodename");
            modelBuilder.Entity<TitleEpisode>().HasKey(c => new { c.FilmId });

            modelBuilder.Entity<TvSeries>().ToTable("tvseries");
            modelBuilder.Entity<TvSeries>().Property(x => x.FilmId).HasColumnName("tconst");
            modelBuilder.Entity<TvSeries>().Property(x => x.EndYear).HasColumnName("endyear");
            modelBuilder.Entity<TvSeries>().HasKey(c => new { c.FilmId });

            modelBuilder.Entity<Genre>().ToTable("genre");
            modelBuilder.Entity<Genre>().Property(x => x.FilmId).HasColumnName("tconst");
            modelBuilder.Entity<Genre>().Property(x => x.GenreName).HasColumnName("genrename");
            modelBuilder.Entity<Genre>().HasKey(c => new { c.FilmId });

            modelBuilder.Entity<TitleRating>().ToTable("title_ratings");
            modelBuilder.Entity<TitleRating>().Property(x => x.FilmId).HasColumnName("tconst");
            modelBuilder.Entity<TitleRating>().Property(x => x.AverageRating).HasColumnName("averagerating");
            modelBuilder.Entity<TitleRating>().Property(x => x.NumVotes).HasColumnName("numvotes");
            modelBuilder.Entity<TitleRating>().HasKey(c => new { c.FilmId });

            modelBuilder.Entity<OmdbData>().ToTable("omdb_data");
            modelBuilder.Entity<OmdbData>().Property(x => x.FilmId).HasColumnName("tconst");
            modelBuilder.Entity<OmdbData>().Property(x => x.Poster).HasColumnName("poster");
            modelBuilder.Entity<OmdbData>().Property(x => x.Award).HasColumnName("award");
            modelBuilder.Entity<OmdbData>().Property(x => x.Plot).HasColumnName("plot");
            modelBuilder.Entity<OmdbData>().HasKey(c => new { c.FilmId });



            modelBuilder.Entity<AppUser>().ToTable("app_user");
            modelBuilder.Entity<AppUser>().Property(x => x.UserId).HasColumnName("u_id");
            modelBuilder.Entity<AppUser>().Property(x => x.UserName).HasColumnName("u_name");
            modelBuilder.Entity<AppUser>().Property(x => x.Password).HasColumnName("password");
            modelBuilder.Entity<AppUser>().Property(x => x.Age).HasColumnName("age");
            modelBuilder.Entity<AppUser>().Property(x => x.Region).HasColumnName("region");
            modelBuilder.Entity<AppUser>().HasKey(c => new { c.UserId });

            modelBuilder.Entity<SearchHistory>().ToTable("search_history");
            modelBuilder.Entity<SearchHistory>().Property(x => x.UserId).HasColumnName("u_id");
            modelBuilder.Entity<SearchHistory>().Property(x => x.FilmId).HasColumnName("tconst");
            modelBuilder.Entity<SearchHistory>().Property(x => x.Date).HasColumnName("date");
            modelBuilder.Entity<SearchHistory>().HasKey(c => new { c.FilmId, c.UserId });

            modelBuilder.Entity<UserRating>().ToTable("user_rating");
            modelBuilder.Entity<UserRating>().Property(x => x.UserId).HasColumnName("u_id");
            modelBuilder.Entity<UserRating>().Property(x => x.FilmId).HasColumnName("tconst");
            modelBuilder.Entity<UserRating>().Property(x => x.Rating).HasColumnName("rating");
            modelBuilder.Entity<UserRating>().Property(x => x.Comment).HasColumnName("comment");
            modelBuilder.Entity<UserRating>().HasKey(c => new { c.FilmId, c.UserId });

            modelBuilder.Entity<BookmarkPeople>().ToTable("bookmark_people");
            modelBuilder.Entity<BookmarkPeople>().Property(x => x.UserId).HasColumnName("u_id");
            modelBuilder.Entity<BookmarkPeople>().Property(x => x.PersonId).HasColumnName("nconst");
            modelBuilder.Entity<BookmarkPeople>().HasKey(c => new { c.PersonId, c.UserId });

            modelBuilder.Entity<BookmarkTitle>().ToTable("bookmark_title");
            modelBuilder.Entity<BookmarkTitle>().Property(x => x.UserId).HasColumnName("u_id");
            modelBuilder.Entity<BookmarkTitle>().Property(x => x.FilmId).HasColumnName("tconst");
            modelBuilder.Entity<BookmarkTitle>().HasKey(c => new { c.FilmId, c.UserId });

            modelBuilder.Entity<Wi>().ToTable("wi");
            modelBuilder.Entity<Wi>().Property(x => x.FilmId).HasColumnName("tconst");
            modelBuilder.Entity<Wi>().Property(x => x.Word).HasColumnName("word");
            modelBuilder.Entity<Wi>().Property(x => x.Field).HasColumnName("field");
            modelBuilder.Entity<Wi>().Property(x => x.Lexme).HasColumnName("lexme");
            modelBuilder.Entity<Wi>().HasKey(c => new { c.FilmId });

            modelBuilder.Entity<SimilarMovies>().HasNoKey();
            modelBuilder.Entity<SimilarMovies>().Property(x => x.Title).HasColumnName("movie");

        }
    }
}
