using EfEx.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using EfEx;
using Microsoft.EntityFrameworkCore;


namespace EfEx
{

    public interface IDataService



        //SearchHistory CRUD
    {
        public TitleBasics GetMovie(string filmId);

        IList<SearchHistory> GetSearchHistory();
        public IList<SearchHistory> GetSearchHistoryByUserId(int userId);
        public bool DeleteSearchHistory(int userId, string filmId);
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
            if (dbp == null) return false;
            try
            {
                ctx.BookmarkPeoples.Remove(ctx.BookmarkPeoples.Find(userId, personId));
            }
            catch (Exception)
            { }
            return ctx.SaveChanges() > 0;
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
            try
            {
                ctx.BookmarkTitles.Remove(ctx.BookmarkTitles.Find(userId, filmId));
            }
            catch (Exception)
            { }
            return ctx.SaveChanges() > 0;
        }



        //Search History

        public IList<SearchHistory> GetSearchHistory()
        {
            var ctx = new IMDBContext();
            var result = ctx.SearchHistories.AsEnumerable();
            return result.ToList();

        }

        public IList<SearchHistory> GetSearchHistoryByUserId(int userId)
        {
            var ctx = new IMDBContext();

            return ctx.SearchHistories.Where(x => x.UserId == userId).ToList();
        }

        public void CreateSearchHistory(SearchHistory searchHistory)
        {
            var ctx = new IMDBContext();
            ctx.Add(searchHistory);
            ctx.SaveChanges();
        }

        public bool DeleteSearchHistory(int userId, string filmId)
        {
            var ctx = new IMDBContext();
            var dbp = ctx.SearchHistories.Find(userId, filmId);
            if (dbp == null) return false;
            try
            {
                ctx.SearchHistories.Remove(ctx.SearchHistories.Find(userId, filmId));
            }
            catch (Exception)
            { }
            return ctx.SaveChanges() > 0;
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
            var result = ctx.BestMatchSearches.FromSqlInterpolated($"SELECT * FROM bestmatch({s})").ToList();
            return result;
        }

        public int BestMatchSearchCount(string s)
        {
            var ctx = new IMDBContext();
            return ctx.BestMatchSearches.FromSqlInterpolated($"SELECT * FROM bestmatch({s})").ToList().Count();
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
            user.Username = username;
            user.Password = password;
            user.Salt = salt;
            
            ctx.Add(user);
            ctx.SaveChanges();
            return user;
        }

    }

      



}