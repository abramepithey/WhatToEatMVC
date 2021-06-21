using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using WhereToEat.MVC.Contracts;
using WhereToEat.MVC.Data;
using WhereToEat.MVC.Models.Styles;

namespace WhereToEat.MVC.Services
{
    public class StyleServices : IStyleServices
    {
        private readonly ApplicationDbContext _context;

        public StyleServices(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task<IList<StyleViewModel>> ListStyles()
        {
            List<StyleViewModel> styles = await _context.Styles.Select(s =>
                new StyleViewModel()
                {
                    StyleId = s.StyleId,
                    Name = s.Name
                }).ToListAsync();
            return styles;
        }

        public async Task<bool> CreateStyle(StyleViewModel newStyle)
        {
            Style style = new Style {StyleId = new Guid(), Name = newStyle.Name};
            _context.Styles.Add(style);
            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<StyleViewModel> GetStyleById(Guid? styleId)
        {
            if (styleId == null)
            {
                return null;
            }

            var style = await _context.Styles.FindAsync(styleId);
            if (style == null)
            {
                return null;
            }

            var model = new StyleViewModel {StyleId = style.StyleId, Name = style.Name};
            return model;
        }

        public async Task<bool> UpdateStyle(StyleViewModel updatedStyle)
        {
            var styleToUpdate = new Style {StyleId = updatedStyle.StyleId, Name = updatedStyle.Name};
            try
            {
                _context.Update(styleToUpdate);
                return await _context.SaveChangesAsync() == 1;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StyleExists(updatedStyle.StyleId))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<bool> DeleteStyle(Guid styleId)
        {
            var style = await _context.Styles.FindAsync(styleId);
            _context.Styles.Remove(style);
            return await _context.SaveChangesAsync() == 1;
        }

        private bool StyleExists(Guid id)
        {
            return _context.Styles.Any(e => e.StyleId == id);
        }
    }
}