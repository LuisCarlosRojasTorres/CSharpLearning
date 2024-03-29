﻿using System;
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
    public class DetailsModel : PageModel
    {
        private readonly Dummy_ASPNET_CAM.Data.Dummy_ASPNET_CAMContext _context;

        public DetailsModel(Dummy_ASPNET_CAM.Data.Dummy_ASPNET_CAMContext context)
        {
            _context = context;
        }

      public Movie Movie { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Movie == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie.FirstOrDefaultAsync(m => m.ID == id);
            if (movie == null)
            {
                return NotFound();
            }
            else 
            {
                Movie = movie;
            }
            return Page();
        }
    }
}
