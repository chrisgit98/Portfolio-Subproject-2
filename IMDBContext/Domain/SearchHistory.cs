using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EfEx;
using EfEx.Domain;
using Microsoft.EntityFrameworkCore;

namespace EfEx.Domain
{
    
    public class SearchHistory
    {
        public int UserId { get; set; }
        public string FilmId { get; set; }
        public DateTime Date { get; set; }


    }

}