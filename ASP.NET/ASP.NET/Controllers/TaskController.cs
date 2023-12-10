using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using ASP.NET;
using MaximTechnology;
using Microsoft.Extensions.Options;

namespace Task7.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly AppSettings _appSettings;
        private readonly RandomApiBoundaryProvider _boundaryProvider;

        public TaskController(IOptions<AppSettings> appSettings, RandomApiBoundaryProvider boundaryProvider)
        {
            _appSettings = appSettings.Value;
            _boundaryProvider = boundaryProvider;
        }
        
        [HttpGet]
        public IActionResult Get(string input, SortType sortType)
        {
            if (_appSettings.Settings.BlackList.Contains(input))
            {
                return BadRequest($"HTTP ошибка 400 Bad Request. Данное слово находится в черном списке: {input}");
            }
            
            StringManipulation stringManipulation = new StringManipulation(_boundaryProvider);
            CharacterCounter characterCounter = new CharacterCounter();
            
            char[] invalidCharacters = stringManipulation.EnglishOrNot(input);

            if (invalidCharacters.Length == 0)
            {
                try
                {
                    string reverse = stringManipulation.Manipulate(input);
                    string srtData = new string(Sorts.Sort(reverse.ToArray(), sortType));

                    var result = new
                    {
                        ReverseStr = reverse,
                        CharCount = characterCounter.CountCharacters(reverse),
                        VowelSubstringStr = stringManipulation.FindLongestSubs(reverse),
                        SortData = srtData,
                        RandomNmb = stringManipulation.RemoveRandomChar(reverse)
                    };

                    return Ok(result);
                }
                catch (Exception)
                {
                    return BadRequest("HTTP ошибка 400 Bad Request. Произошла ошибка при запросе к удаленному API.");
                }
            }
            else
            {
                return BadRequest("HTTP ошибка 400 Bad Request, были введены неверные символы -- " + string.Join(" ", invalidCharacters));
            }
        }
    }
}