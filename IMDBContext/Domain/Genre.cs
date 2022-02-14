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
    
    public class Genre
    {
        public char FilmId { get; set; }
        public string GenreName { get; set; }
    }

}