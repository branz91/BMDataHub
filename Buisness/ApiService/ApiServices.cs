using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using DataAccess.Data;
using Models;
using System.Diagnostics;
using System.Globalization;
using System.ComponentModel.DataAnnotations;



public class ApiServices
{
    private readonly IHttpClientFactory _clientFactory;

    public ApiServices(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }

    public async Task<List<Courses>> FetchDataFromApiAsync()
    {
        var apiUrl = "https://phpstack-1107017-3957074.cloudwaysapps.com/apiv1.php?CreatedAt=&OrderName=&ProductTitle=&ProductId=&LineItemTitle=&LineItemId=&firstname=&lastname=&email=&country=&startDate=&endDate=&sku=c-&skuStartsWith=true&SalesChannel=&Store=event&newcomer=&format=json";
        var client = _clientFactory.CreateClient();

        try
        {
            var response = await client.GetAsync(apiUrl);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();

            using var document = JsonDocument.Parse(responseBody);
            var coursesList = new List<Courses>();

            var root = document.RootElement;
            if (root.ValueKind == JsonValueKind.Array)
            {
                foreach (var jsonElement in root.EnumerateArray())
                {
                    try
                    {
                        var course = new Courses
                        {
                           Id = jsonElement.GetProperty("Id").GetInt16(),
                            ProductId = ParseLong(jsonElement.GetProperty("ProductId").GetString()),
                            LineItemId = ParseNullableLong(jsonElement.GetProperty("LineItemId").GetString()),
                            LineItemPrice = ParseNullableDouble(jsonElement.GetProperty("LineItemPrice").GetString()),
                            OrderName = jsonElement.GetProperty("OrderName").GetString(),
                            CreatedAt = jsonElement.GetProperty("CreatedAt").GetString(),
                            ProductTitle = jsonElement.GetProperty("ProductTitle").GetString(),
                            LineItemTitle = jsonElement.GetProperty("LineItemTitle").GetString(),
                            firstname = jsonElement.GetProperty("firstname").GetString(),
                            lastname = jsonElement.GetProperty("lastname").GetString(),
                            email = (jsonElement.GetProperty("email").GetString() ?? "").Substring(0, Math.Min(50, (jsonElement.GetProperty("email").GetString() ?? "").Length)),

                          
                           Quantity = jsonElement.GetProperty("Quantity").GetByte(),
                          


                            DateTimeAdded = (jsonElement.GetProperty("DateTimeAdded").GetString() ?? "").Substring(0, Math.Min(100, (jsonElement.GetProperty("DateTimeAdded").GetString() ?? "").Length)),


                            Store = (jsonElement.GetProperty("Store").GetString() ?? "").Substring(0, Math.Min(50, (jsonElement.GetProperty("Store").GetString() ?? "").Length)),
                            consent = (jsonElement.GetProperty("consent").GetString() ?? "").Substring(0, Math.Min(50, (jsonElement.GetProperty("consent").GetString() ?? "").Length)),
                            Refunded = (jsonElement.GetProperty("Refunded").GetString() ?? "").Substring(0, Math.Min(50, (jsonElement.GetProperty("Refunded").GetString() ?? "").Length)),
                            SalesChannel = (jsonElement.GetProperty("SalesChannel").GetString() ?? "").Substring(0, Math.Min(50, (jsonElement.GetProperty("SalesChannel").GetString() ?? "").Length)),
                            //newcomer = (jsonElement.GetProperty("newcomer").GetString() ?? "").Substring(0, Math.Min(50, (jsonElement.GetProperty("newcomer").GetString() ?? "").Length)),
                            country = (jsonElement.GetProperty("country").GetString() ?? "").Substring(0, Math.Min(50, (jsonElement.GetProperty("country").GetString() ?? "").Length)),
                            sku = (jsonElement.GetProperty("sku").GetString() ?? "").Substring(0, Math.Min(50, (jsonElement.GetProperty("sku").GetString() ?? "").Length)),


                            //FeesAmount = jsonElement.GetProperty("Quantity").GetByte(),
                            //IdTeacher = jsonElement.GetProperty("Quantity").GetByte(),
                            //Paid = jsonElement.GetProperty("Quantity").GetBoolean,

                            //// Altre proprietà...
                            //ProductId = ParseLong(jsonElement.GetProperty("productId").GetString()),

                            //// Altre proprietà...
                        };

                        coursesList.Add(course);
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"Errore durante l'elaborazione di un elemento JSON: {ex.Message}");
                        // Puoi decidere come gestire questo errore, ad esempio ignorare l'elemento problematico o registrare ulteriori dettagli sull'errore.
                    }
                }
            }

            return coursesList;
        }
        catch (HttpRequestException ex)
        {
            Debug.WriteLine($"Errore di richiesta HTTP: {ex.Message}");
            throw new Exception("Errore durante la richiesta HTTP.");
        }
        catch (JsonException ex)
        {
            Debug.WriteLine($"Errore nella deserializzazione JSON: {ex.Message}");
            throw new Exception("Errore nella deserializzazione JSON.");
        }
    }

    private long ParseLong(string value)
    {
        if (long.TryParse(value, out long result))
        {
            return result;
        }
        return 0;
    }

    private long? ParseNullableLong(string value)
    {
        if (long.TryParse(value, out long result))
        {
            return result;
        }
        return null;
    }

    private double? ParseNullableDouble(string value)
    {
        if (double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out double result))
        {
            return result;
        }
        return null;
    }
}