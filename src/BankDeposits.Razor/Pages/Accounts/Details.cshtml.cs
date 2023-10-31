using BankDeposits.Domain.Services.Interfaces;
using BankDeposits.Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BankDeposits.Razor.Pages.Accounts;

public class AccountDetailsPageModel : PageModel
{
    private readonly ILogger<AccountDetailsPageModel> _logger;
    private readonly IAccountService _accountService;

    public AccountDetailsPageModel(ILogger<AccountDetailsPageModel> logger, IAccountService accountService)
    {
        _logger = logger;
        _accountService = accountService;
    }

    public AccountViewModel Account { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(Guid id)
    {
        var account = await _accountService.GetAsync(id);
        Account = new AccountViewModel
        {
            Id = account.Id,
            OwnerId = account.OwnerId,
            Balance = account.Balance,
            Number = account.Number,
            TotalProfit = account.TotalProfit
        };

        return Page();
    }

    public async Task<IActionResult> OnPostDeleteAsync(Guid id)
    {
        await _accountService.DeleteAsync(id);
        return RedirectToPage("./Index");
    }
}