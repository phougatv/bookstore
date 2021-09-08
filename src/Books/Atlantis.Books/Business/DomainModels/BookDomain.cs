namespace Atlantis.Books.Business.DomainModels
{
    using System;

    class BookDomain
    {
        /// <summary>
        /// The Id.
        /// </summary>
        public Guid Id { get; set; }

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

        /// <summary>
        /// The is deleted.
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// The created on datetime.
        /// </summary>
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// The updated on datetime.
        /// </summary>
        public DateTime? UpdatedOn { get; set; }
    }
}
