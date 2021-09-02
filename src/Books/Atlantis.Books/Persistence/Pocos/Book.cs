namespace Atlantis.Books.Persistence.Pocos
{
    using System;
    using System.ComponentModel.DataAnnotations;

    internal class Book
    {
        /// <summary>
        /// Id, the primary key in the Book table.
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// The title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The isbn - International Standard Book Number.
        /// </summary>
        public string Isbn { get; set; }

        /// <summary>
        /// The release year of the book
        /// </summary>
        public int Year { get; set; }
    }
}
