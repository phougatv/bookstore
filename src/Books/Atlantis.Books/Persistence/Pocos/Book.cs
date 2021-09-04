namespace Atlantis.Books.Persistence.Pocos
{
    using Atlantis.Books.Persistence.Base;
    using System;

    public class Book : Entity<Guid>
    {
        /// <summary>
        /// The title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The isbn - International Standard Book Number.
        /// </summary>
        public string Isbn { get; set; }

        /// <summary>
        /// The release year of the book.
        /// </summary>
        public int Year { get; set; }
    }
}
