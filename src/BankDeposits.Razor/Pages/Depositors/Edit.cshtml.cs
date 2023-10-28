using BankDeposits.Domain.Services.Interfaces;
using BankDeposits.Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BankDeposits.Razor.Pages.Depositors;

public class DepositorEditPageModel : PageModel
{
    private readonly ILogger<DepositorEditPageModel> _logger;
    private readonly IDepositorService _depositorService;

    public DepositorEditPageModel(ILogger<DepositorEditPageModel> logger, IDepositorService depositorService)
    {
        _logger = logger;
        _depositorService = depositorService;
    }

    [BindProperty]
    public DepositorEditModel Depositor { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(Guid id)
    {
        var depositor = await _depositorService.GetAsync(id);
        Depositor = new DepositorEditModel
        {
            Id = depositor.Id,
            Name = depositor.Name,
            Surname = depositor.Surname,
            Patronymic = depositor.Patronymic,
            Address = depositor.Address,
        };

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var depositor = await _depositorService.GetAsync(Depositor.Id);

        depositor.Name = Depositor.Name;
        depositor.Surname = Depositor.Surname;
        depositor.Patronymic = Depositor.Patronymic;
        depositor.Address = Depositor.Address;

        await _depositorService.UpdateAsync(depositor);

        return RedirectToPage("./Details", new { id = Depositor.Id });
    }
}