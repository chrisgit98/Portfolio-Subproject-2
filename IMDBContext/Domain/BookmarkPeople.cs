using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EfEx;
using EfEx.Domain;
using Microsoft.EntityFrameworkCore;

namespace EfEx.Domain
{
    
    public class BookmarkPeople
    {
        public int UserId { get; set; }
        public string PersonId { get; set; }
        public string Name { get; set; }


    }

}