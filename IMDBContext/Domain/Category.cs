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
    [Keyless]
    public class Category
    {
    public string CategoryName { get; set; }
    public string JobTitle { get; set; }
   

    }

}