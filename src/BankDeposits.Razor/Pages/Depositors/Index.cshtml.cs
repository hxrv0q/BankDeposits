using BankDeposits.Domain.Services.Interfaces;
using BankDeposits.Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BankDeposits.Razor.Pages.Depositors;

public class DepositorIndexPageModel : PageModel
{
   private readonly ILogger<DepositorIndexPageModel> _logger;
   private readonly IDepositorService _depositorService;
   
   public DepositorIndexPageModel(ILogger<DepositorIndexPageModel> logger, IDepositorService depositorService)
   {
      _logger = logger;
      _depositorService = depositorService;
   }
   
   public IList<DepositorViewModel> Depositors { get; set; } = new List<Models.DepositorViewModel>();

   public async Task<IActionResult> OnGetAsync()
   {
      var depositors = await _depositorService.GetAllAsync();

      Depositors = depositors.Select(x => new Models.DepositorViewModel
      {
         Id = x.Id,
         Address = x.Address,
         Passport = x.Passport,
         FullName = x.FullName
      }).ToList();
      
      return Page();
   }
}