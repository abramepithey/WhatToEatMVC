using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WhereToEat.MVC.Models.Styles;

namespace WhereToEat.MVC.Contracts
{
    public interface IStyleServices
    {
        Task<IList<StyleViewModel>> ListStyles();
        Task<bool> CreateStyle(StyleViewModel newStyle);
        Task<StyleViewModel> GetStyleById(Guid? styleId);
        Task<bool> UpdateStyle(StyleViewModel updatedStyle);
        Task<bool> DeleteStyle(Guid styleId);
    }
}