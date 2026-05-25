using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using RomanNumeralAPI.Models;

namespace RomanNumeralAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RomanConverterController : ControllerBase
{
    private readonly Solution _solution = new();

    [HttpGet("to-int")]
    public IActionResult ToInt([FromQuery] string romanNumeral)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(romanNumeral))
            {
                return BadRequest("Nenhum numeral romano informado. Digite um valor.");
            }

            int result = _solution.RomanToInt(romanNumeral);
            string formatted = result.ToString("N0", new CultureInfo("pt-BR"));
            return Ok(formatted);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception)
        {
            return BadRequest("Erro inesperado. Verifique o numeral romano.");
        }
    }

    [HttpGet("to-roman")]
    public IActionResult ToRoman([FromQuery] string number)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(number))
            {
                return BadRequest("Nenhum número informado. Digite um valor.");
            }

            if (number.Contains('.') || number.Contains(','))
            {
                return BadRequest(
                    "Números com casas decimais não são permitidos. Informe um número inteiro entre 1 e 3.999."
                );
            }

            if (!int.TryParse(number, out int num))
            {
                return BadRequest("Número inválido. Informe um número inteiro.");
            }

            string result = _solution.IntToRoman(num);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
