using EfEx.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using EfEx;
using Xunit;
using System.Collections.Generic;

namespace EfEx
{
    public class Program
    {
        

        public static void Main()
        {
            var dataService = new DataService();

            var name_basics = dataService.GetNames();

            foreach (var names in name_basics)
            {
                Console.WriteLine(names.PersonName);
            }

            //var dataService = new DataService();
            //var film = dataService.GetTitleBasics();
            //Console.WriteLine(film.FilmId);

        }
    }


}