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
        public IList<SearchHistory> GetSearchHistoryByUserId(int userId);
        public bool DeleteSearchHistory(int userId);

        //BookmarksPeople CRUD
        IList<BookmarkPeople> GetBookmarksPeople();
        public BookmarkPeople GetBookmarkPeopleByUserId(int userId,string personID);
        public bool CreateBookmarkPeople(BookmarkPeople bookmarkPeople);
        public BookmarkPeople CreateBookmarkPeople(int userId, string PersonId);
        public IList<BookmarkPeople> GetBookmarkPeopleByUserId(int userId);
        public bool DeleteBookmarkPeople(int userId, string personId);


        //BookmarkTitle CRUD
        public BookmarkTitle GetBookmarkTitleByUserId(int userId, string filmId);
        public bool CreateBookmarkTitle(BookmarkTitle bookmarkTitle);
        public BookmarkTitle CreateBookmarkTitle(int userId, string filmId);
        public IList<BookmarkTitle> GetBookmarkTitleByUserId(int userId);
        public bool DeleteBookmarkTitle(int userId, string filmId);

        //User Crud

        public User GetUser(string username);
        public User GetUser(int id);
        public User CreateUser(string name, string username, string password = null, string salt = null);


        //Seach Function
        public IList<StringSearch> StringSearch(string s);

        public IList<FindingCoPlayers> FindingCoPlayers(string s);

        public IList<SimilarMovies> SimilarMovies(string s);

        public IList<PopularActors> PopularActors(string s);

        public IList<StructuredStringSearch> StructuredStringSearches(string s, string s1, string s2, string s3);
    }


    public class DataService : IDataService
    {
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

        public bool CreateBookmarkPeople(BookmarkPeople bookmarkPeople)
        {
            var ctx = new IMDBContext();
            bookmarkPeople.UserId = ctx.BookmarkPeoples.Max(x => x.UserId) + 1;
            ctx.Add(bookmarkPeople);
            return ctx.SaveChanges() > 0;

        }

        public BookmarkPeople CreateBookmarkPeople(int userId, string PersonId)
        {
            var ctx = new IMDBContext();
            BookmarkPeople bookmarkPeople = new BookmarkPeople();
            bookmarkPeople.UserId = userId;
            bookmarkPeople.PersonId = PersonId;

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

        public bool CreateBookmarkTitle(BookmarkTitle bookmarkTitle)
        {
            var ctx = new IMDBContext();
            bookmarkTitle.UserId = ctx.BookmarkTitles.Max(x => x.UserId) + 1;
            ctx.Add(bookmarkTitle);
            return ctx.SaveChanges() > 0;

        }

        public BookmarkTitle CreateBookmarkTitle(int userId, string filmId)
        {
            var ctx = new IMDBContext();
            BookmarkTitle bookmarkTitle = new BookmarkTitle();
            bookmarkTitle.UserId = userId;
            bookmarkTitle.FilmId = filmId;

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

        public IList<SearchHistory> GetSearchHistoryByUserId(int userId)
        {
            var ctx = new IMDBContext();

            return ctx.SearchHistories.Where(x => x.UserId == userId).ToList();
        }


        public bool DeleteSearchHistory(int userId)
        {
            var ctx = new IMDBContext();
            try
            {
                ctx.SearchHistories.Remove(ctx.SearchHistories.Find(userId));
            }
            catch (Exception)
            { }
            return ctx.SaveChanges() > 0;
        }


           //Functions

        public IList<StringSearch> StringSearch(string s)
        {
            Console.WriteLine(s);

            var ctx = new IMDBContext();
            var result = ctx.StringSearch.FromSqlInterpolated($"SELECT * FROM string_search({s})").ToList();

            return result;
            

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