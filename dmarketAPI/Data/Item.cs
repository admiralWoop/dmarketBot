using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dmarketAPI.Data
{
	public class DMarketResponse
	{
		public Item[] Objects { get; set; }
	}

	public class Item
	{
		public int Discount { get; set; }
		public string Title { get; set; }
	}
}
