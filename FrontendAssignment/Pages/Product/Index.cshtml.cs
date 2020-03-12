using System;
using System.Threading.Tasks;
using FrontendAssignment.Data.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FrontendAssignment.Pages.Product
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ProductContext _dbContext;
        
        public FrontendAssignment.Data.Model.Product ViewProduct { get; set; }

        public IndexModel(ILogger<IndexModel> logger, ProductContext context)
        {
            _logger = logger;
            _dbContext = context;
        }
        
        public async Task<IActionResult> OnGetAsync(string urlSegment)
        {
            if (string.IsNullOrEmpty(urlSegment))
            {
                return RedirectToPage("/Index");
            }
            
            try
            {
                var dbProduct = await _dbContext.Products.FirstOrDefaultAsync(p => p.UrlSegment == urlSegment);
                if (dbProduct == null) return RedirectToPage("/Index");
                
                dbProduct.TimesViewed += 1;
                _dbContext.SaveChanges();

                ViewProduct = dbProduct;
                return Page();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting desired product.");
                throw;
            }

        }
    }
}