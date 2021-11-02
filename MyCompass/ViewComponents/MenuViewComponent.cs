using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCompass.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCompass.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        private readonly MyCompassContext _context;

        public MenuViewComponent(MyCompassContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await _context.TripCategoriesModel.ToListAsync();
            return View(items);
        }
    }

}
