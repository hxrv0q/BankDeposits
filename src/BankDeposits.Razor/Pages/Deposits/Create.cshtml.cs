using BankDeposits.Domain.Models;
using BankDeposits.Domain.Services.Interfaces;
using BankDeposits.Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Memory;

namespace BankDeposits.Razor.Pages.Deposits;

public class DepositsCreatePageModel : PageModel
{
    private readonly ILogger<DepositsCreatePageModel> _logger;
    private readonly IDepositService _depositService;
    private readonly IAccountService _accountService;
    private readonly IMemoryCache _memoryCache;

    public DepositsCreatePageModel(ILogger<DepositsCreatePageModel> logger, IDepositService depositService, IAccountService accountService, IMemoryCache memoryCache)
    {
        _logger = logger;
        _depositService = depositService;
        _accountService = accountService;
        _memoryCache = memoryCache;
    }

    [BindProperty]
    public DepositCreateModel Deposit { get; set; } = new();

    public SelectList Accounts { get; set; } = default!;

    public async Task OnGetAsync() => await PopulateAccountsAsync();

    public async Task<IActionResult> OnPostAsync()
    {
        if (ModelState.IsValid)
        {
            var deposit = new Deposit
            {
                AccountId = Deposit.AccountId,
                Amount = Deposit.Amount,
                StartDate = Deposit.StartDate,
                EndDate = Deposit.EndDate,
                Rate = Deposit.Rate
            };

            await _depositService.AddAsync(deposit);

            return RedirectToPage("./Index");
        }

        await PopulateAccountsAsync();
        return Page();
    }

    private async Task PopulateAccountsAsync()
    {
        if (!_memoryCache.TryGetValue("AccountsList", out SelectList? cachedAccounts))
        {
            var accounts = await _accountService.GetAllAsync();
            cachedAccounts = new SelectList(accounts, nameof(Account.Id), nameof(Account.Number));
            _memoryCache.Set("AccountsList", cachedAccounts, TimeSpan.FromMinutes(5));
        }

        Accounts = cachedAccounts!;
    }
}