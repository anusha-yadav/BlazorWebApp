using BookCatalog.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace BookCatalog.Data.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime? PublicationDate { get; set; }

        [EnumDataType(typeof(Category),ErrorMessage ="Please select a category")]
        public Category Category { get; set; }
    }
}
