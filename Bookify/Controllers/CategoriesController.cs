using Bookify.Filter;
using Microsoft.EntityFrameworkCore;

namespace Bookify.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // TODO: Use ViewModel  
            var categories = _context.Categories.AsNoTracking().ToList();
            return View(categories);  
        }
        [AjaxOnly]
        public IActionResult Create()
        {

            var model = new CategoryFormViewModel();
            return PartialView("_Form", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CategoryFormViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest();
            var category = new Category { Name = model.Name  };
            _context.Categories.Add(category);
            _context.SaveChanges(); 
             return PartialView("_CategoryRow", category);
        }
        [AjaxOnly]
        public IActionResult Edit(int id)
        { 
            var category = _context.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            var viewModel = new CategoryFormViewModel
            {
                Id = category.Id,
                Name = category.Name
            }; 
            return PartialView("_Form", viewModel);
        }

        // This method is used to handle the form submission for editing a category update category
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CategoryFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var category = _context.Categories.Find(model.Id);
            if (category is null)
            {
                return NotFound();
            }
            category.Name = model.Name;
            category.LastUpdatedOn = DateTime.Now;  
            _context.Categories.Update(category);
            _context.SaveChanges();

            return PartialView("_CategoryRow", category);
        }

        // This method is used to delete a current category status and revers it
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ToggleStatus(int id)
        {
            var category = _context.Categories.Find(id);
            if (category is null)
            {
                return NotFound();
            }
            category.IsDeleted = !category.IsDeleted;
            category.LastUpdatedOn = DateTime.Now;  
            _context.SaveChanges();
            return Ok(category.LastUpdatedOn);
        }



    }
}
