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
      public  IList<NameBasics> GetNames();

        //TitleBasics CRUD
        public TitleBasics GetTitleBasics(string titleId);
        public bool CreateTitleBasics(TitleBasics titleBasics);
        public TitleBasics CreateTitleBasics(string id, string originaltitle);
        public bool UpdateTitleBasics(TitleBasics titleBasics);
        public bool DeleteTitleBasics(string titleId);
    }


    public class DataService : IDataService
    {

        public IList<NameBasics> GetNames()
        {
            var ctx = new IMDBContext();
            return ctx.NameBasics.ToList(); 
        }

        public TitleBasics GetTitleBasics(string titleId)
        {
            var ctx = new IMDBContext();
            TitleBasics result = ctx.TitleBasics.FirstOrDefault(x => x.FilmId == titleId);
            return result;
        }

        public bool CreateTitleBasics(TitleBasics titleBasics)
        {
            var ctx = new IMDBContext();
            titleBasics.FilmId = ctx.TitleBasics.Max(x => x.FilmId) + 1;
            ctx.Add(titleBasics);
            return ctx.SaveChanges() > 0;
        }

        public TitleBasics CreateTitleBasics(string filmid, string originaltitle)
        {
            var ctx = new IMDBContext();

            TitleBasics titlebasic = new TitleBasics();
            titlebasic.FilmId = filmid;
            titlebasic.OriginalTitle = originaltitle;
            

            ctx.Add(titlebasic);
            ctx.SaveChanges();

            return titlebasic;
        }

        public bool UpdateTitleBasics(TitleBasics titleBasics)
        {
            var ctx = new IMDBContext();
            TitleBasics temp = ctx.TitleBasics.Find(titleBasics.FilmId);

            temp.TitleType = titleBasics.TitleType;
            temp.OriginalTitle = titleBasics.OriginalTitle;
            temp.OriginalTitle = titleBasics.OriginalTitle;
            temp.YearRelease = titleBasics.YearRelease;
            temp.RuntimeMinutes = titleBasics.RuntimeMinutes;
            return ctx.SaveChanges() > 0;
        }

        public bool DeleteTitleBasics(string titleId)
        {
            var ctx = new IMDBContext();
            TitleBasics titlebasic = new TitleBasics() { FilmId = titleId };
            ctx.TitleBasics.Attach(titlebasic);
            ctx.TitleBasics.Remove(ctx.TitleBasics.Find(titleId));
            return ctx.SaveChanges() > 0;
        }
    }




}