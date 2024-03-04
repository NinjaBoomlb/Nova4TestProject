using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Nova4TestProject.Data;
using Nova4TestProject.Models;

namespace Nova4TestProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BitcoinInfoController : ControllerBase
    {
        private readonly DataContext context;
        private readonly List<string> sources = new List<string> { "bitstamp", "bitfinex" };

        public BitcoinInfoController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet("AllAvailableSources")]
        public IActionResult GetAvailableSources()
        {
            return Ok(sources.ToList());
        }
    

        [HttpGet("GetPriceFromSource")]
        public IActionResult GetPriceBySource([FromQuery]string source) {

            if (!sources.Contains(source))
            {
                return BadRequest("Source Not Available");
            }


            if(source == sources[0])
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = client.GetStringAsync("https://www.bitstamp.net/api/v2/ticker/btcusd/").Result;
                    var data = JsonConvert.DeserializeObject<BitcoinInfoBitStamp>(response);

                    if (data != null)
                    {
                        string formattedPrice = data.Last.ToString("0.00");
                        var history = new BitcoinHistory
                        {
                            Source = source,
                            Price = data.Last,
                            Timestamp = DateTime.Now
                        };
                        context.BitcoinInfo.Add(history);
                        context.SaveChanges();
                        return Ok(formattedPrice);
                    }
                }
            }
            else
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = client.GetStringAsync("https://api.bitfinex.com/v1/pubticker/btcusd").Result;
                    var data = JsonConvert.DeserializeObject<BitcoinInfoBitfinex>(response);

                    if (data != null)
                    {
                        string formattedPrice = data.LastPrice.ToString("0.00");
                        var history = new BitcoinHistory
                        {
                            Source = source,
                            Price = data.LastPrice,
                            Timestamp = DateTime.Now
                        };
                        context.BitcoinInfo.Add(history);
                        context.SaveChanges();

                        return Ok(formattedPrice);
                    }
                }
            }


            return BadRequest("Error Occured");
        }

        [HttpGet("GetHistoryBySource")]
        public ActionResult GetHistory([FromQuery]string source)
        {
            if (!sources.Contains(source))
            {
                return BadRequest("Source Not Available");
            }

            var history = context.BitcoinInfo
                .Where(bp => bp.Source == source)
                .Select(bp => new { price = bp.Price, timestamp = bp.Timestamp.ToString("yyyy-MM-dd HH:mm:ss") })
                .ToList();

            return Ok(new { source, history });
        }


        [HttpGet("GetHistory")]
        public ActionResult GetHistory()
        {
            var history = context.BitcoinInfo
                .Select(bp => new { price = bp.Price, source= bp.Source, timestamp = bp.Timestamp.ToString("yyyy-MM-dd HH:mm:ss") })
                .ToList();

            return Ok(history);
        }
    }
}
