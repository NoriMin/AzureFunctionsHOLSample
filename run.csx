#r "Newtonsoft.Json"

using System;
using System.Net.Http;
using System.Web;
using Microsoft.AspNetCore.Mvc;

private static HttpClient client = new HttpClient();

public static async Task<IActionResult> Run(HttpRequest req, ILogger log)
{
    var queryString = HttpUtility.ParseQueryString(string.Empty);
    string priceUSDstr = req.Query["priceUSD"];
    float priceUSD = Convert.ToSingle(priceUSDstr);

    var uri = "https://openexchangerates.org/api/latest.json?app_id=db7b91946d384003bb447384345d04dc&base=USD";

    HttpResponseMessage response;

    response = await client.GetAsync(uri);

    string contentString = await response.Content.ReadAsStringAsync();
    dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(contentString);

    float priceJPYperD = Convert.ToSingle(jsonObj.rates.JPY);
    float priceJPY = priceUSD * priceJPYperD;

    return (ActionResult)new OkObjectResult(priceJPY);
}