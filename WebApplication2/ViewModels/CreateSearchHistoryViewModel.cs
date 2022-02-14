using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EfEx.Domain;
using EfEx;
using System.ComponentModel.DataAnnotations;

namespace WebService.ViewModels
{
	public class CreateSearchHistoryViewModel
	{
		public string Url { get; set; }
		public string FilmId { get; set; }
		[DataType(DataType.Date)]
		public DateTime? Date { get; set; }
	}
}