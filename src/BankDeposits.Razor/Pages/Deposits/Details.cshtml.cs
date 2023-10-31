using BankDeposits.Domain.Services.Interfaces;
using BankDeposits.Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BankDeposits.Razor.Pages.Deposits;

public class DepositDetailsPageModel : PageModel
{
    private readonly ILogger<DepositDetailsPageModel> _logger;
    private readonly IDepositService _depositService;

    public DepositDetailsPageModel(ILogger<DepositDetailsPageModel> logger, IDepositService depositService)
    {
        _logger = logger;
        _depositService = depositService;
    }

    public DepositViewModel Deposit { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(Guid id)
    {
        var deposit = await _depositService.GetAsync(id);
        Deposit = new DepositViewModel
        {
            Id = deposit.Id,
            Amount = deposit.Amount,
            StartDate = deposit.StartDate,
            Rate = deposit.Rate,
            EndDate = deposit.EndDate,
            Profit = deposit.Profit,
            AccountId = deposit.AccountId
        };
        return Page();
    }

    public async Task<IActionResult> OnPostDeleteAsync(Guid id)
    {
        await _depositService.DeleteAsync(id);
        return RedirectToPage("./Index");
    }
}