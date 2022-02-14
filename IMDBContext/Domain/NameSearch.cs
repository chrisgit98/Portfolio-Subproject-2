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

    public class NameSearch
    {
        public string PersonId { get; set; }
        public string Name { get; set; }
        public float? Rate { get; set; }
    }

}

