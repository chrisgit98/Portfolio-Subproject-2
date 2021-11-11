using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EfEx;
using EfEx.Domain;



namespace EfEx.Domain
{ 
    
    public class Actors
    {
    public char FilmId { get; set; }
    public char PersonId { get; set; }
    public int Ordering { get; set; }
    public string Characters { get; set; }
    public string Category { get; set; }

    }

}