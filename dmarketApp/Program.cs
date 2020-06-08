using System;
using System.Threading.Tasks;
using dmarketAPI.Data;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading;
using System.Web;

namespace dmarketApp
{
	class Program
	{
		static const int DISCOUNT = 23;

		static async Task Main(string[] args)
		{
			var client = new HttpClient();

			while (true)
			{
				try
				{
					string link = @"https://api.dmarket.com/exchange/v1/market/items?orderBy=best_deals&orderDir=desc&title=&priceFrom=0&priceTo=4370&treeFilters=&gameId=a8db&offset=0&limit=100&currency=USD";
					var response = await client.GetAsync(link);
					response.EnsureSuccessStatusCode();
					string responseBody = await response.Content.ReadAsStringAsync();

					var responseDeserialized = JsonConvert.DeserializeObject<DMarketResponse>(responseBody);
				
					foreach (var item in responseDeserialized.Objects)
					{
						if (item.Discount >= DISCOUNT && item.Title != "CS:GO Weapon Case")
						{
							PlayNotification();
							PrintItemData(item);
						}
					}
				}
				catch (Exception e)
				{
					Console.WriteLine($@"Exception Caught!");
					Console.WriteLine($"Message: {e.Message} ");
				}
				Thread.Sleep(200);
			}
		}

		static void PlayNotification()
		{
			var player = new System.Media.SoundPlayer(@"music/дора.wav");
			player.Play();
		}

		static void PrintItemData(Item item)
		{
			Console.WriteLine(item.Discount);
			Console.WriteLine(item.Title);
		}
	}
}
