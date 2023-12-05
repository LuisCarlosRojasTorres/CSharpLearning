using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Dummy_ASPNET_CAM.Data;
using Dummy_ASPNET_CAM.Models;

namespace Dummy_ASPNET_CAM.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly Dummy_ASPNET_CAM.Data.Dummy_ASPNET_CAMContext _context;

        public IndexModel(Dummy_ASPNET_CAM.Data.Dummy_ASPNET_CAMContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Movie != null)
            {
                Movie = await _context.Movie.ToListAsync();
            }
        }
    }
}
