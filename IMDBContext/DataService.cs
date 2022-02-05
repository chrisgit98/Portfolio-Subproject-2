using EfEx.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using EfEx;
using Microsoft.EntityFrameworkCore;
using Npgsql;


namespace EfEx
{

    public interface IDataService



        //SearchHistory CRUD
    {
        public TitleBasics GetMovie(string filmId);

        //IList<SearchHistory> GetSearchHistory();
        public IList<SearchHistory> GetSearchHistoryByUserId(int userId);
        public int SearchHistoryCount(int userId);
        public bool DeleteSearchHistory(int userId);
        public void CreateSearchHistory(SearchHistory searchHistory);

        //BookmarksPeople CRUD
        IList<BookmarkPeople> GetBookmarksPeople();
        public BookmarkPeople GetBookmarkPeopleByUserId(int userId,string personID);
        //public bool CreateBookmarkPeople(BookmarkPeople bookmarkPeople);
        public BookmarkPeople CreateBookmarkPeople(BookmarkPeople bookmarkPeople);
        public IList<BookmarkPeople> GetBookmarkPeopleByUserId(int userId);
        public bool DeleteBookmarkPeople(int userId, string personId);


        //BookmarkTitle CRUD
        public IList<BookmarkTitle> GetBookmarksTitle();
        public BookmarkTitle GetBookmarkTitleByUserId(int userId, string filmId);
        public BookmarkTitle CreateBookmarkTitle(BookmarkTitle bookmarkTitle);
        public IList<BookmarkTitle> GetBookmarkTitleByUserId(int userId);
        public bool DeleteBookmarkTitle(int userId, string filmId);

        //User Crud

        public User GetUser(string username);
        public User GetUser(int id);
        public User CreateUser(string name, string username, string password = null, string salt = null);


        //Seach Function
        public IList<NameSearch> NameSearch(string s);
        public int NameSearchCount(string s);
        public NameOtherview GetNameOtherview(string personId);

        public IList<StringSearch> StringSearch(string s);
        public int StringSearchCount(string s);
        public IList<FindingCoPlayers> FindingCoPlayers(string s);

        public IList<SimilarMovies> SimilarMovies(string s);

        public IList<PopularActors> PopularActors(string s);

        public IList<StructuredStringSearch> StructuredStringSearches(string s, string s1, string s2, string s3);

        public TitleOtherview GetTitleOtherview(string s);

        public IList<BestMatchSearch> BestMatchSearch(string s);

        public int BestMatchSearchCount(string s);

        public void RateAMovie(int u_id, string t_id, float u_rating);

        public IList<RatingHistory> GetRatingHistoryByUserId(int userId);
    }


    public class DataService : IDataService
    {

        public TitleBasics GetMovie(string filmId)
        {
            var ctx = new IMDBContext();
            return ctx.TitleBasics.FirstOrDefault(x => x.FilmId == filmId);
        }



        //BookmarkPeople


        public IList<BookmarkPeople> GetBookmarksPeople()
        {
            var ctx = new IMDBContext();
            var result = ctx.BookmarkPeoples.AsEnumerable();
            return result.ToList();

        }

        public IList<BookmarkPeople> GetBookmarkPeopleByUserId(int userId)
        {
           
                var ctx = new IMDBContext();
                //if (ctx.Users.FirstOrDefault(x => x.UserId == userId) == null)
                //    throw new ArgumentException("User not found");

                return ctx.BookmarkPeoples.Where(x => x.UserId == userId).ToList();

        }


        public BookmarkPeople GetBookmarkPeopleByUserId(int userId,string personId)
        {
            var ctx = new IMDBContext();

           BookmarkPeople result = ctx.BookmarkPeoples.FirstOrDefault(x => x.UserId == userId && x.PersonId==personId);
           
            return result;
        }


        public BookmarkPeople CreateBookmarkPeople(BookmarkPeople bookmarkPeople)
        {
            
            var ctx = new IMDBContext();

            ctx.Add(bookmarkPeople);
            ctx.SaveChanges();
            return bookmarkPeople;
        }

        public bool DeleteBookmarkPeople(int userId, string personId)
        {
            var ctx = new IMDBContext();
            var dbp = ctx.BookmarkPeoples.Find(userId, personId);
            if (dbp == null)
            {
                return false;
            }           
            ctx.BookmarkPeoples.Remove(dbp);
            ctx.SaveChanges();
            return true;      
        }


        //Bookmark Title

        public IList<BookmarkTitle> GetBookmarksTitle()
        {
            var ctx = new IMDBContext();
            var result = ctx.BookmarkTitles.AsEnumerable();
            return result.ToList();

        }

        public IList<BookmarkTitle> GetBookmarkTitleByUserId(int userId)
        {
            var ctx = new IMDBContext();

            return ctx.BookmarkTitles.Where(x => x.UserId == userId).ToList();

        }


        public BookmarkTitle GetBookmarkTitleByUserId(int userId, string filmId)
        {
            var ctx = new IMDBContext();

            BookmarkTitle result = ctx.BookmarkTitles.FirstOrDefault(x => x.UserId == userId && x.FilmId == filmId);

            return result;
        }

        public BookmarkTitle CreateBookmarkTitle(BookmarkTitle bookmarkTitle)
        {
            var ctx = new IMDBContext();

            ctx.Add(bookmarkTitle);
            ctx.SaveChanges();
            return bookmarkTitle;
        }

        public bool DeleteBookmarkTitle(int userId, string filmId)
        {
            var ctx = new IMDBContext();

            var dbp = ctx.BookmarkTitles.Find(userId, filmId);
            if (dbp == null)
            {
                return false;
            }
            ctx.BookmarkTitles.Remove(dbp);
            ctx.SaveChanges();
            return true;
        }



        //Search History

        //public IList<SearchHistory> GetSearchHistory()
        //{
        //    var ctx = new IMDBContext();
        //    var result = ctx.SearchHistories.AsEnumerable();
        //    return result.ToList();

        //}

        public IList<SearchHistory> GetSearchHistoryByUserId(int userId)
        {
            var ctx = new IMDBContext();

            var result = ctx.SearchHistories.Where(x => x.UserId == userId).ToList();
            return result;
        }

        public int SearchHistoryCount(int userId)
        {
            var ctx = new IMDBContext();
            return ctx.SearchHistories.Where(x => x.UserId == userId).ToList().Count();
        }

        public void CreateSearchHistory(SearchHistory searchHistory)
        {
            var ctx = new IMDBContext();
            ctx.Add(searchHistory);
            ctx.SaveChanges();
        }

        public bool DeleteSearchHistory(int userId)
        {
            var ctx = new IMDBContext();
            var elementsToBeDeleted = ctx.SearchHistories.Where(x => x.UserId == userId).ToList();
            foreach (var element in elementsToBeDeleted)
            {
                ctx.SearchHistories.Remove(element);
            }

            //var dsh = ctx.SearchHistories.Find(userId);
            //if (dsh == null)
            //{
            //    return false;
            //}
            //ctx.SearchHistories.Remove(dsh);
            ctx.SaveChanges();
            return true;
        }



        //Functions

        public IList<StringSearch> StringSearch(string s )
        {
            Console.WriteLine(s);

            var ctx = new IMDBContext();
            var result = ctx.StringSearch.FromSqlInterpolated($"SELECT * FROM string_search({s})").ToList();

            return result;
            
        }

        public int StringSearchCount(string s)
        {
            var ctx = new IMDBContext();
            return ctx.StringSearch.FromSqlInterpolated($"SELECT * FROM string_search({s})").ToList().Count();
        }

        public IList<StructuredStringSearch> StructuredStringSearches(string s, string s1, string s2, string s3)
        {
            var ctx = new IMDBContext();
            var result = ctx.StructuredStringSearch.FromSqlInterpolated($"SELECT * FROM structured_string_search({s},{s1} ,{s2}, {s3}) ").ToList();
            return result;
        }
        public IList<PopularActors> PopularActors(string s)
        {
            var ctx = new IMDBContext();
            var result = ctx.PopularActors.FromSqlInterpolated($"SELECT * FROM ppl_actor({s})").ToList();
            return result;
        }

        public IList<SimilarMovies> SimilarMovies(string s)
        {
            var ctx = new IMDBContext();
            var result = ctx.SimilarMovies.FromSqlInterpolated($"SELECT * FROM similar_movies({s})").ToList();
            return result;
        }

        public IList<FindingCoPlayers> FindingCoPlayers(string s)
        {
            var ctx = new IMDBContext();
            var result = ctx.FindingCoPlayers.FromSqlInterpolated($"SELECT * FROM finding_coplayer({s})").ToList();
            return result;
        }

        public  TitleOtherview GetTitleOtherview(string s)
        {
            var ctx = new IMDBContext();
            var result  = ctx.TitleOtherviews.FromSqlInterpolated($"SELECT * FROM title_otherview({s})");
            return result.FirstOrDefault();
        }

        public IList<NameSearch> NameSearch(string s)
        {
            Console.WriteLine(s);
            
            var ctx = new IMDBContext();
            //if (ctx.Users.FirstOrDefault(x => x.UserId == userId) == null)
            //    throw new ArgumentException("User not found");
            var result = ctx.NameSearches.FromSqlInterpolated($"SELECT * FROM name_search({s})").ToList();
            return result;
        }
        public int NameSearchCount(string s)
        {
            var ctx = new IMDBContext();
            return ctx.NameSearches.FromSqlInterpolated($"SELECT * FROM name_search({s})").ToList().Count();
        }


        public NameOtherview GetNameOtherview(string personId)
        {
            var ctx = new IMDBContext();
            var result = ctx.NameOtherviews.FromSqlInterpolated($"SELECT * FROM name_otherview({personId})");
            return result.FirstOrDefault();
        }


        public IList<BestMatchSearch> BestMatchSearch(string s)
        {
            Console.WriteLine(s);

            var ctx = new IMDBContext();
            var result = ctx.BestMatchSearches.FromSqlInterpolated($"SELECT * FROM bestmatchstring({s})").ToList();
            return result;
        }

        public int BestMatchSearchCount(string s)
        {
            var ctx = new IMDBContext();
            return ctx.BestMatchSearches.FromSqlInterpolated($"SELECT * FROM bestmatchstring({s})").ToList().Count();

        }

        public IList<RatingHistory> GetRatingHistoryByUserId(int userId)
        {
            var ctx = new IMDBContext();

            return ctx.RatingHistories.Where(x => x.UserId == userId).ToList();

        }

        public void RateAMovie(int usr_id, string t_id, float u_rating)
        {
            var ctx = new IMDBContext();
            var conn = (NpgsqlConnection)ctx.Database.GetDbConnection();
            conn.Open();
            var cmd = new NpgsqlCommand();
            cmd.CommandText = $"call rate_title2({usr_id},'{t_id}',{u_rating})";
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();
            //ctx.MovieRatings.FromSqlInterpolated(($"call rate_title2({usr_id},'{t_id}',{u_rating})"));
        }

        //Users

        public User GetUser(string username)

        {
            var ctx = new IMDBContext();

            User result = ctx.Users.FirstOrDefault(x => x.Username == username);
            return result;
        }

        public User GetUser(int id)
        {
            var ctx = new IMDBContext();
            User result = ctx.Users.FirstOrDefault(x => x.UserId == id);
            return result;
        }

        public User CreateUser(string name, string username, string password = null, string salt = null)
        {
            var ctx = new IMDBContext();
            User user = new User();
            user.UserId = ctx.Users.Max(x => x.UserId) + 1;
            user.Name = name;
            user.Username = username;
            user.Password = password;
            user.Salt = salt;
            
            ctx.Add(user);
            ctx.SaveChanges();
            return user;
        }

    }

      



}