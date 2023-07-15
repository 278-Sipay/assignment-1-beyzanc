using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Sipay.Bootcamp.Beyza_Cabuk.FluentValidationDemo.Models;

namespace Sipay.Bootcamp.Beyza_Cabuk.FluentValidationDemo.Controllers;



[ApiController]
[Route("sipy/api/[controller]")]
public class PersonController : ControllerBase
{
    private readonly IValidator<Person> _validator;
    public PersonController(IValidator<Person> validator)
    {
        _validator = validator;
    }

    [HttpPost]
    public IActionResult Post([FromBody] Person person)
    {
        var result = _validator.Validate(person);
        if (!result.IsValid)
        {
            return BadRequest(result.Errors);
        }

        return Ok(person);

    }
}