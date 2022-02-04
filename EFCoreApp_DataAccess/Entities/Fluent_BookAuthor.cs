using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreApp_DataAccess.Entities
{
    public class Fluent_BookAuthor
    {
        public int BookId { get; set; }
        public Fluent_Book Book { get; set; } = default!;
        public int AuthorId { get; set; }
        public Fluent_Author Author { get; set; } = default!;
    }
}