﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EfEx.Domain;
using EfEx;

namespace WebService.ViewModels
{
	public class CreateSearchHistoryViewModel
	{
		public string Url { get; set; }
		public string Tconst { get; set; }
		public string Title { get; set; }
	}
}