using System;
using System.Collections.Generic;

namespace rage_sava
{
    public class Author
    {
        public int Id { get; set; }//
        public string FirstName { get; set; }//
        public string SecondName { get; set; }//
        public string LastName { get; set; }//
        public DateTime Birthday { get; set; }//
        public List<Book> Books { get; set; }//
    }
}