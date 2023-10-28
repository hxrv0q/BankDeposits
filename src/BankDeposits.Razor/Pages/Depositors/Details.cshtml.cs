using BankDeposits.Domain.Services.Interfaces;
using BankDeposits.Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BankDeposits.Razor.Pages.Depositors;

public class DepositorDetailsPageModel : PageModel
{
    private readonly ILogger<DepositorDetailsPageModel> _logger;
    private readonly IDepositorService _depositorService;

    public DepositorDetailsPageModel(ILogger<DepositorDetailsPageModel> logger, IDepositorService depositorService)
    {
        _logger = logger;
        _depositorService = depositorService;
    }

    public DepositorViewModel Depositor { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(Guid id)
    {
        var depositor = await _depositorService.GetAsync(id);
        Depositor = new DepositorViewModel
        {
            Id = depositor.Id,
            Address = depositor.Address,
            Passport = depositor.Passport,
            FullName = depositor.FullName
        };

        return Page();
    }

    public async Task<IActionResult> OnPostDeleteAsync(Guid id)
    {
        await _depositorService.DeleteAsync(id);
        return RedirectToPage("./Index");
    }
}