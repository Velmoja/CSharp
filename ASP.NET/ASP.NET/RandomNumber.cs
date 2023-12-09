namespace MaximTechnology;
using System;
using System.Net.Http;
using System.Threading.Tasks;

public class RandomNumber
{
    public static async Task<int> GetRandomNumberFromApi(int maxValue)
    {
        string apiUrl = $"http://www.randomnumberapi.com/api/v1.0/random?min=0&max={maxValue}";

        using (HttpClient client = new HttpClient())
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                
                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    responseContent = responseContent.Trim();
                    responseContent = responseContent.Substring(1, responseContent.Length - 2);
                    
                    if (int.TryParse(responseContent, out int randomNumber))
                    {
                        return randomNumber % maxValue;
                    }
                   
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                return new Random().Next(0, maxValue);
            }
        }
        return 0;
    }
}