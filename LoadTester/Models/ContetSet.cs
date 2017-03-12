using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LoadTester.Models
{
	public class ContentSet
	{
		public int contentSetId { get; set; }
	 
	    public int categoryId { get; set; }
	 
	    public string name { get; set; }
	 
		public bool active { get; set; }
	}
}