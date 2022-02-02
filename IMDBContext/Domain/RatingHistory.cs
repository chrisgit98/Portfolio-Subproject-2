using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EfEx;
using EfEx.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace EfEx.Domain
{

    public class RatingHistory
    {
        public int UserId { get; set; }
        public string FilmId { get; set; }
        public double Rating { get; set; }
        public DateTime Date  { get; set; }
    }

}