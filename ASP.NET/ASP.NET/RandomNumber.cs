namespace MaximTechnology;
using System;
using System.Net.Http;
using System.Threading.Tasks;


// public class RandomNumber
// {
//     public static async Task<int> GetRandomNumberFromApi(int maxValue)
//     {
//         string apiUrl = $"http://www.randomnumberapi.com/api/v1.0/random?min=0&max={maxValue}";
//
//         using (HttpClient client = new HttpClient())
//         {
//             try
//             {
//                 HttpResponseMessage response = await client.GetAsync(apiUrl);
//                 
//                 if (response.IsSuccessStatusCode)
//                 {
//                     string responseContent = await response.Content.ReadAsStringAsync();
//                     responseContent = responseContent.Trim();
//                     responseContent = responseContent.Substring(1, responseContent.Length - 2);
//                     
//                     if (int.TryParse(responseContent, out int randomNumber))
//                     {
//                         return randomNumber % maxValue;
//                     }
//                    
//                 }
//                 else
//                 {
//                     throw new Exception();
//                 }
//             }
//             catch (Exception ex)
//             {
//                 return new Random().Next(0, maxValue);
//             }
//         }
//         return 0;
//     }
// }

public class RandomApiBoundaryProvider
{
    private readonly string _apiUrl;

    public RandomApiBoundaryProvider(string apiUrl)
    {
        _apiUrl = apiUrl;
    }

    public async Task<int> GetMaxBoundaryAsync(string input)
    {
        using (HttpClient client = new HttpClient())
        {
            string apiUrlWithParams = $"{_apiUrl}?min=0&max={input.Length}&count=1";

            try
            {
                HttpResponseMessage response = await client.GetAsync(apiUrlWithParams);

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    responseContent = responseContent.Trim();
                    responseContent = responseContent.Substring(1, responseContent.Length - 2);
                    
                    if (int.TryParse(responseContent, out int maxBoundary))
                    {
                        return maxBoundary;
                    }
                    else
                    {
                        throw new Exception("HTTP ошибка 400 Bad Request. Ошибка при разборе содержимого ответа на int.");
                    }
                }
                else
                {
                    throw new Exception($"HTTP ошибка 400 Bad Request. Ошибка при извлечении границы из API. StatusCode: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("HTTP ошибка 400 Bad Request. Ошибка при извлечении границы из API. {ex.Message}");
            }
        }
    }
}
