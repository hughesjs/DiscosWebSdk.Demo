/* DISCLAIMER:
 * 
 * THIS IS AWFUL CODE, YOU SHOULD NOT WRITE CODE LIKE THIS.
 * IT IS THE BARE MINIMUM REQUIRED TO ACT AS A GATEWAY.
 * I MADE IT TO ADDRESS THIS: https://stackoverflow.com/a/65762540/4700841
 * TL;DR - DISCOS DOESN'T SUPPORT CORS. NO-CORS MODE IN BROWSERS DOESN'T LET YOU SEND AUTH HEADERS.
 * AS SUCH, WE NEED A GATEWAY TO KEEP CORS ON THE BROWSER HAPPY AND PROXY REQUESTS TO DISCOS.
 * I DIDN'T WANT TO MAKE IT. I DEFINITELY DON'T WANT TO WASTE TIME MAKING THIS GOOD.
 * DON'T TAKE THIS AS AN EXAMPLE OF HOW I GENERALLY WRITE CODE
 * IT WILL BREAK IF YOU HIT THE RATE LIMIT
 *
 * YOU HAVE BEEN WARNED!
 */


using System.Net;
using System.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json")
	   .AddEnvironmentVariables();
builder.Services.AddCors(options =>
						 {
							 options.AddPolicy(name: "cors",
											   policy => { policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin(); });
						 });


var app = builder.Build();
app.UseCors("cors");

app.MapGet("/discos-proxy/{*discosRoute}", async (string discosRoute, HttpContext context) =>
										   {
											   HttpClient client = new();
											   client.BaseAddress                         = new(app.Configuration.GetSection("DiscosOptions:DiscosApiUrl").Value);
											   client.DefaultRequestHeaders.Authorization = new("bearer", context.Request.Headers.Authorization.ToString().Split(' ')[1]);
											   HttpResponseMessage res = await client.GetAsync(discosRoute);
											   while (!res.IsSuccessStatusCode) // This is actually done in the SDK but CBA to forward retry headers for now
											   {
											    if (res.StatusCode is not HttpStatusCode.TooManyRequests or HttpStatusCode.BadGateway) break; // Don't retry on these
											    if (res.StatusCode is HttpStatusCode.TooManyRequests)
											    {
											     RetryConditionHeaderValue? retryAfter = res.Headers.RetryAfter;
											     Console.WriteLine($"Hit rate limit. Waiting for {retryAfter.Delta.Value.TotalSeconds}s...");
											     await Task.Delay(retryAfter.Delta.Value);
											    }
											    else
											    {
											     await Task.Delay(5000);
											    }
											    res = await client.GetAsync(discosRoute);
											   }
											   
											   res.EnsureSuccessStatusCode();
											   Stream             contentStream = await res.Content.ReadAsStreamAsync();
											   using StreamReader reader        = new(contentStream);
											   string             content       = await reader.ReadToEndAsync();
											   return content;
										   });

app.Run();
