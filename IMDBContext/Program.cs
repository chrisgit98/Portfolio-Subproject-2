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

            var connectionString = "host=localhost;db=imdb_small;uid=postgres;pwd=@DAc43712";
            UseAdo(connectionString);

        }

        private static void UseAdo(string connectionString)
        {
            var connection = new NpgsqlConnection(connectionString);
            connection.Open();

            var cmd = new NpgsqlCommand("SELECT * FROM SIMILAR_MOVIES('tt0372784')", connection);
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"{reader.GetString(0)}");
            }
        }
    }


}