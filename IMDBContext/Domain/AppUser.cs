using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EfEx;
using EfEx.Domain;
using Microsoft.EntityFrameworkCore;

namespace EfEx.Domain
{
    
    public class AppUser
    {
        public char UserId { get; set; }
        public string UserName { get; set; }
        public char Password { get; set; }
        public int? Age { get; set; }
        public string Region { get; set; }


    }

}