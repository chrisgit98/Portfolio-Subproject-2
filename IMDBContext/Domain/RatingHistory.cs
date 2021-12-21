using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EfEx;
using EfEx.Domain;
using Microsoft.EntityFrameworkCore;

namespace EfEx.Domain
{

    public class RatingHistory
    {
        public int? UserId { get; set; }
        public string FilmId { get; set; }
        public float? Rating { get; set; }
        public int? Date { get; set; }
    }

}