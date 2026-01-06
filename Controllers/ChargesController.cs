using Microsoft.AspNetCore.Mvc;
using AuthAPI.Models;

namespace AuthAPI.Controllers;

[ApiController]
[Route("api/admin/charges")]
public class ChargesController : ControllerBase
{
    private static readonly List<Charge> Charges = new();
    private static readonly List<ChargeSlab> Slabs = new();
    private static readonly List<InterestRate> InterestRates = new();

    // 🔹 Charges
    [HttpGet]
    public IActionResult GetCharges() => Ok(Charges);

    [HttpPost]
    public IActionResult AddCharge([FromBody] Charge charge)
    {
        charge.Id = Charges.Count + 1;
        Charges.Add(charge);
        return Ok(charge);
    }

    // 🔹 Slabs
    [HttpGet("slabs")]
    public IActionResult GetSlabs() => Ok(Slabs);

    [HttpPost("slabs")]
    public IActionResult AddSlab([FromBody] ChargeSlab slab)
    {
        slab.Id = Slabs.Count + 1;
        Slabs.Add(slab);
        return Ok(slab);
    }

    // 🔹 Interest Rates
    [HttpGet("interest")]
    public IActionResult GetInterestRates() => Ok(InterestRates);

    [HttpPost("interest")]
    public IActionResult AddInterestRate([FromBody] InterestRate rate)
    {
        rate.Id = InterestRates.Count + 1;
        InterestRates.Add(rate);
        return Ok(rate);
    }
}
