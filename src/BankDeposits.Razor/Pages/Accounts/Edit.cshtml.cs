using BankDeposits.Domain.Services.Interfaces;
using BankDeposits.Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BankDeposits.Razor.Pages.Accounts;

public class AccountsEditPageModel : PageModel
{
    private readonly ILogger<AccountsEditPageModel> _logger;
    private readonly IAccountService _accountService;

    public AccountsEditPageModel(ILogger<AccountsEditPageModel> logger, IAccountService accountService)
    {
        _logger = logger;
        _accountService = accountService;
    }

    [BindProperty]
    public AccountEditModel Account { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(Guid id)
    {
        var account = await _accountService.GetAsync(id);
        Account = new AccountEditModel
        {
            Id = account.Id,
            Balance = account.Balance,
        };

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var account = await _accountService.GetAsync(Account.Id);

        account.Balance = Account.Balance;

        await _accountService.UpdateAsync(account);

        return RedirectToPage("./Details", new { id = Account.Id });
    }
}