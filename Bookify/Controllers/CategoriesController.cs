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
            var categories = _context.Categories.ToList();
            return View(categories);  
        } 
        public IActionResult Create()
        {
            var model = new CategoryFormViewModel();
            return View("Form", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CategoryFormViewModel model)
        {
            if (!ModelState.IsValid)
            { 
                return View("Form",model);
            }
            var category = new Category { Name = model.Name  };
            _context.Categories.Add(category);
            _context.SaveChanges();

            return  RedirectToAction(nameof(Index));
        }
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
            return View("Form", viewModel);
        }

        // This method is used to handle the form submission for editing a category update category
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CategoryFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Form", model);
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

            return RedirectToAction(nameof(Index));
        }
    }
}
