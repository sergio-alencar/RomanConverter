using Microsoft.AspNetCore.Mvc;
using RomanNumeralAPI.Models;

namespace RomanNumeralAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RomanConverterController : ControllerBase
{
    private readonly Solution _solution = new();

    [HttpGet("to-int")]
    public IActionResult ToInt(string romanNumeral)
    {
        try
        {
            int result = _solution.RomanToInt(romanNumeral);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("to-roman")]
    public IActionResult ToRoman(int number)
    {
        try
        {
            string result = _solution.IntToRoman(number);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
