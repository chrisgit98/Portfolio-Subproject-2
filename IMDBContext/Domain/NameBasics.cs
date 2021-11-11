using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EfEx;
using EfEx.Domain;
using Microsoft.EntityFrameworkCore; 


namespace EfEx.Domain
{ 
    
    public class NameBasics
    {
       public string PersonId { get; set; }
       public string PersonName { get; set; }
       public string BirthYear { get; set; }
       public string DeathYear { get; set; }
 

    }

}

