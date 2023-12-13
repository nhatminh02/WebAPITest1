using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public int AuthorId { get; set; }
        public string Description { get; set; } = null!;

        public virtual Author Author { get; set; } = null!;
    }
}
