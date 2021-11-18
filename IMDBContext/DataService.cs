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

    }


    public class DataService : IDataService
    {
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