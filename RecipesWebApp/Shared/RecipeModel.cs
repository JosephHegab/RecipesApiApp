using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipesWebApp.Shared
{
    public class RecipeModel
    {
        public int Id { get; set; }

        public string RecipeName { get; set; } = string.Empty;

        public string RecipeDescription { get; set;} = string.Empty;

        public RecipeCategoriesModel? RecipeCategories { get; set; }

        public int RecipeCategoriesId { get; set; }
    }
}
