using BankDeposits.Domain.Services.Interfaces;
using BankDeposits.Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BankDeposits.Razor.Pages.Deposits;

public class DepositsIndexPageModel : PageModel
{
    private readonly ILogger<DepositsIndexPageModel> _logger;
    private readonly IDepositService _depositService;

    public DepositsIndexPageModel(ILogger<DepositsIndexPageModel> logger, IDepositService depositService)
    {
        _logger = logger;
        _depositService = depositService;
    }

    public IList<DepositViewModel> Deposits { get; set; } = new List<DepositViewModel>();

    public async Task<IActionResult> OnGetAsync()
    {
        var deposits = await _depositService.GetAllAsync();

        Deposits = deposits.Select(x => new DepositViewModel
        {
            Id = x.Id,
            AccountId = x.AccountId,
            StartDate = x.StartDate,
            EndDate = x.EndDate,
            Rate = x.Rate,
            Amount = x.Amount,
            Profit = x.Profit
        }).ToList();

        return Page();
    }
}