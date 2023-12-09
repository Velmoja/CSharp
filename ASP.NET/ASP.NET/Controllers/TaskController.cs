using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using ASP.NET;
using MaximTechnology;

namespace Task7.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(string input, SortType sortType)
        {
            StringManipulation stringManipulation = new StringManipulation();
            CharacterCounter characterCounter = new CharacterCounter();
            
            char[] invalidCharacters = stringManipulation.EnglishOrNot(input);
            
            if (invalidCharacters.Length == 0)
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
            else
            {
                return BadRequest("HTTP ошибка 400 Bad Request, были введены неверные символы - " + string.Join(" ", invalidCharacters));
            }
        }
    }
}