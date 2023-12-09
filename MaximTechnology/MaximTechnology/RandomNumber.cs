namespace MaximTechnology;
using System;
using System.Net.Http;
using System.Threading.Tasks;

public class RandomNumber
{
    public async Task<int> GetRandomNumberFromApi(int maxValue)
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
                    else
                    {
                        Console.WriteLine("Ошибка: Невозможно преобразовать ответ в число.");
                    }
                }
                else
                {
                    Console.WriteLine($"Ошибка: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при выполнении запроса: {ex.Message}");
            }
            
            return new Random().Next(0, maxValue);;
        }
    }
}