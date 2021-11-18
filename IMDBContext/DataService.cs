using EfEx.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using EfEx;

namespace EfEx
{

    public interface IDataService
    {
        public SearchHistory GetSearchHistoryByUserId(int userId);
        public bool CreateSearchHistory(SearchHistory searchHistory);
        public bool DeleteSearchHistory(int userId);

        public BookmarkPeople GetBookmarkPeopleByUserId(int userId,string personID);
        public bool CreateBookmarkPeople(BookmarkPeople bookmarkPeople);
    }


    public class DataService : IDataService
    {
        public BookmarkPeople GetBookmarkPeopleByUserId(int userId,string personId)
        {
            var ctx = new IMDBContext();
            BookmarkPeople result = ctx.BookmarkPeople.FirstOrDefault(x => x.UserId == userId && x.PersonId==personId);
           // BookmarkPeople result = ctx.BookmarkPeople.Find();
            return result;
        }
        public bool CreateBookmarkPeople(BookmarkPeople bookmarkPeople)
        {
            var ctx = new IMDBContext();
            bookmarkPeople.UserId = ctx.BookmarkPeople.Max(x => x.UserId) + 1;
            ctx.Add(bookmarkPeople);
            return ctx.SaveChanges() > 0;
        }


        public SearchHistory GetSearchHistoryByUserId(int userId)
        {
            var ctx = new IMDBContext();
            SearchHistory result = ctx.SearchHistories.FirstOrDefault(x => x.UserId == userId);
            return result;
        }

        public bool CreateSearchHistory(SearchHistory searchHistory)
        {
            var ctx = new IMDBContext();
            searchHistory.UserId = ctx.SearchHistories.Max(x => x.UserId) + 1;
            ctx.Add(searchHistory);
            return ctx.SaveChanges() > 0;
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



    }

}