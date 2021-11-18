using EfEx.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using EfEx;
using Xunit;
using System.Collections.Generic;
using Npgsql;

namespace EfEx
{
    public class Program
    {


        public static void Main()
        {
            //var dataService = new DataService();

            //var name_basics = dataService.GetNames();

            //foreach (var names in name_basics)
            //{
            //    Console.WriteLine(names.PersonName);
            //}

            //var dataService = new DataService();
            //var film = dataService.GetTitleBasics();
            //Console.WriteLine(film.FilmId);

           // var connectionString = "host=localhost;db=imdb_small;uid=postgres;pwd=@DAc43712";
            SimilarMovies();
            // UseAdo(connectionString);
            FindingCoPlayers();
            StringSearch();
            StructuredStringSearch();
            PopularActors();

        }

        private static void PopularActors()
        {
            Console.WriteLine("Popular Actors");
            var ctx = new IMDBContext();
            var result = ctx.PopularActors.FromSqlInterpolated($"SELECT * from ppl_actor('captain phillips')");

            foreach (var pplactors in result)
            {
                Console.WriteLine($"{pplactors.Name},{pplactors.Popularity}");
            }


        }
        private static void StructuredStringSearch()
        {
            Console.WriteLine("Structured String Search");
            var ctx = new IMDBContext();
            var result = ctx.StructuredStringSearch.FromSqlInterpolated($"SELECT * FROM structured_string_search('STAR WARS','VADER' ,'REY', 'ridley')");

            foreach (var structuredstringsearch in result)
            {
                Console.WriteLine($"{structuredstringsearch.Title}");
            }
        }


        private static void SimilarMovies()
        {
            Console.WriteLine("Similar Movies");
            var ctx = new IMDBContext();
            var result = ctx.SimilarMovies.FromSqlInterpolated($"SELECT * FROM SIMILAR_MOVIES ('tt0372784')");

            foreach (var similarMovies in result)
            {
                Console.WriteLine($"{similarMovies.Title}");
            }

        }
        private static void FindingCoPlayers()
        {
            Console.WriteLine("This is the Finding CoPlayers Function");
            var ctx = new IMDBContext();
            var result = ctx.FindingCoPlayers.FromSqlInterpolated($"SELECT * FROM finding_coplayer('Nicolas Cage')");
          
            
            foreach (var findingCoPlayers in result)
            {
                Console.WriteLine($"{findingCoPlayers.Primary_Name},{findingCoPlayers.Nconst},{findingCoPlayers.Frequency}");
            }

        }

        private static void StringSearch()
        {
            Console.WriteLine("String Search");

            var ctx = new IMDBContext();
            var result = ctx.StringSearch.FromSqlInterpolated($"SELECT * FROM string_search('star WARS')");

            foreach(var stringSearch in result)
            {
                Console.WriteLine($"{stringSearch.Title}");
            }

        }



        //private static void UseAdo(string connectionString)
        //{
        //    Console.WriteLine("This is Ado Framework");

        //    var connection = new NpgsqlConnection(connectionString);
        //    connection.Open();

        //    var cmd = new NpgsqlCommand("SELECT * FROM SIMILAR_MOVIES('tt0386676')", connection);
        //    var reader = cmd.ExecuteReader();

        //    while (reader.Read())
        //    {
        //        Console.WriteLine($"{reader.GetString(0)}");
        //    }
        //}
    }


}