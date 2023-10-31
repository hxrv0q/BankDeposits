using BankDeposits.Domain.Services.Interfaces;
using BankDeposits.Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BankDeposits.Razor.Pages.Deposits;

public class DepositsEditPageModel : PageModel
{
    private readonly ILogger<DepositsEditPageModel> _logger;
    private readonly IDepositService _depositService;

    public DepositsEditPageModel(ILogger<DepositsEditPageModel> logger, IDepositService depositService)
    {
        _logger = logger;
        _depositService = depositService;
    }

    [BindProperty]
    public DepositEditModel Deposit { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(Guid id)
    {
        var deposit = await _depositService.GetAsync(id);
        Deposit = new DepositEditModel
        {
            Id = deposit.Id,
            Rate = deposit.Rate,
        };
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var deposit = await _depositService.GetAsync(Deposit.Id);

        deposit.Rate = Deposit.Rate;

        await _depositService.UpdateAsync(deposit);

        return RedirectToPage("./Details", new { id = Deposit.Id });
    }
}