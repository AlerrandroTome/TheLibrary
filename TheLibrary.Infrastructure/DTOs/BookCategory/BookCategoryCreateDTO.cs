namespace TheLibrary.Infrastructure.DTOs.BookCategory
{
    public class BookCategoryCreateDTO
    {
        public string Title { get; set; }
        public bool Active { get; } = true;
    }
}
