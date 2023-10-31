using BankDeposits.Domain.Models;
using BankDeposits.Domain.Services.Interfaces;
using BankDeposits.Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Memory;

namespace BankDeposits.Razor.Pages.Accounts;

public class AccountsCreatePageModel : PageModel
{
    private readonly ILogger<AccountsCreatePageModel> _logger;
    private readonly IAccountService _accountService;
    private readonly IDepositorService _depositorService;
    private readonly IMemoryCache _memoryCache;

    public AccountsCreatePageModel(ILogger<AccountsCreatePageModel> logger, IAccountService accountService, IDepositorService depositorService, IMemoryCache memoryCache)
    {
        _logger = logger;
        _accountService = accountService;
        _depositorService = depositorService;
        _memoryCache = memoryCache;
    }

    [BindProperty]
    public AccountCreateModel Account { get; set; } = new();

    public SelectList Depositors { get; set; } = default!;

    public async Task OnGetAsync() => await PopulateDepositorsAsync();

    public async Task<IActionResult> OnPostAsync()
    {
        if (!await VerifyNumber(Account.Number))
        {
            ModelState.AddModelError("Account.Number", "Account with this number already exists");
        }

        if (ModelState.IsValid)
        {
            var account = new Account
            {
                OwnerId = Account.OwnerId,
                Number = Account.Number,
                Balance = Account.Balance
            };

            await _accountService.AddAsync(account);

            return RedirectToPage("./Index");
        }

        await PopulateDepositorsAsync();

        return Page();
    }

    private async Task PopulateDepositorsAsync()
    {
        if (!_memoryCache.TryGetValue("DepositorsList", out SelectList? cachedDepositors))
        {
            var depositors = await _depositorService.GetAllAsync();
            cachedDepositors = new SelectList(depositors, nameof(Depositor.Id), nameof(Depositor.FullName));
            _memoryCache.Set("DepositorsList", cachedDepositors, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(5)));
        }

        Depositors = cachedDepositors!;
    }

    private async Task<bool> VerifyNumber(string number)
    {
        var account = await _accountService.GetByNumberAsync(number);
        return account is null;
    }
}