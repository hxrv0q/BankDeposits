using BankDeposits.Domain.Services.Interfaces;
using BankDeposits.Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BankDeposits.Razor.Pages.Accounts;

public class AccountsIndexPageModel : PageModel
{
    private readonly ILogger<AccountsIndexPageModel> _logger;
    private readonly IAccountService _accountService;

    public AccountsIndexPageModel(ILogger<AccountsIndexPageModel> logger, IAccountService accountService)
    {
        _logger = logger;
        _accountService = accountService;
    }

    public IList<AccountViewModel> Accounts { get; set; } = new List<AccountViewModel>();

    public async Task<IActionResult> OnGetAsync()
    {
        var accounts = await _accountService.GetAllAsync();

        Accounts = accounts.Select(x => new AccountViewModel
        {
            Id = x.Id,
            OwnerId = x.OwnerId,
            Balance = x.Balance,
            Number = x.Number,
            TotalProfit = x.TotalProfit
        }).ToList();

        return Page();
    }
}