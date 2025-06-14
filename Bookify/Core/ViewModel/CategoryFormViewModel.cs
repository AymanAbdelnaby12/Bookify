namespace Bookify.Core.ViewModel
{
    public class CategoryFormViewModel
    {
        public int Id { get; set; } 
        [MaxLength(100,ErrorMessage ="Max Length cannot be more than 100 char")]
        public string Name { get; set; } = null!;//not null
    }
}
