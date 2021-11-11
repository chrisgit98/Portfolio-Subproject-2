using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EfEx;
using EfEx.Domain;



namespace EfEx.Domain
{

    public class UserRating
    {
        public char UserId { get; set; }
        public char FilmId { get; set; }
        public int Rating { get; set; }
        public char Comment { get; set; }
      

    }

}