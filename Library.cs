using System;
using System.Collections.Generic;


namespace BasicLibrary 
{
    public class Library : BaseClass
    {
        public string Title { get; set; } = default!;
        public string NameOfAuthor { get; set; } = default!;
        public string Issn { get; set; } = default!;

        public UserCategory UserCategory { get; set; } = default!;
        public BookGenre BookGenre { get; set; }
    }
}