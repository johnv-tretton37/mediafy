using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using FrontendAssignment.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace FrontendAssignment.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ProductContext _dbContext;

        public IEnumerable<FrontendAssignment.Data.Model.Product> Products;

        public IndexModel(ILogger<IndexModel> logger, ProductContext context)
        {
            _logger = logger;
            _dbContext = context;
        }

        public async Task OnGetAsync()
        {
            var products = await _dbContext.Products.ToListAsync();
            Products = products.OrderByDescending(x=> x.TimesViewed);
        }
    }

    
}
