using System;
using System.Collections.Generic;

namespace rage_sava
{
    public class Book
    {
        public int Id { get; set; }//
        public string Name { get; set; }//
        public DateTime PublishDate { get; set; }//
        public Publisher Publisher { get; set; }//
        public List<Genre> Genres { get; set; }//
        public List<Author> Authors { get; set; }//
    }
}