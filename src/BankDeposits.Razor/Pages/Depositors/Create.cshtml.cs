using BankDeposits.Domain.Models;
using BankDeposits.Domain.Services.Interfaces;
using BankDeposits.Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BankDeposits.Razor.Pages.Depositors;

public class DepositorCreatePageModel : PageModel
{
    private readonly ILogger<DepositorCreatePageModel> _logger;
    private readonly IDepositorService _depositorService;

    public DepositorCreatePageModel(ILogger<DepositorCreatePageModel> logger, IDepositorService depositorService)
    {
        _logger = logger;
        _depositorService = depositorService;
    }

    [BindProperty]
    public DepositorCreateModel Depositor { get; set; } = new();

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var depositor = new Depositor
        {
            Name = Depositor.Name,
            Surname = Depositor.Surname,
            Patronymic = Depositor.Patronymic,
            PassportSeries = Depositor.PassportSeries,
            PassportNumber = Depositor.PassportNumber,
            Address = Depositor.Address
        };

        if (!await VerifyPassport(depositor.PassportNumber))
        {
            ModelState.AddModelError("Depositor.PassportNumber", "Depositor with this passport already exists");
            return Page();
        }

        await _depositorService.AddAsync(depositor);

        return RedirectToPage("./Index");
    }

    private async Task<bool> VerifyPassport(string passportNumber)
    {
        var depositor = await _depositorService.FindAsync(d => d.PassportNumber == passportNumber);
        return depositor is null;
    }
}