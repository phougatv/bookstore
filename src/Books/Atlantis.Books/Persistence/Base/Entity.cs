namespace Atlantis.Books.Persistence.Base
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Entity class.
    /// </summary>
    /// <typeparam name="TId">The TId.</typeparam>
    public class Entity<TId>
    {
        /// <summary>
        /// Id, the primary key in the table.
        /// </summary>
        [Key]
        public TId Id { get; set; }

        /// <summary>
        /// Is deleted.
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// The created on.
        /// </summary>
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// The updated on.
        /// </summary>
        public DateTime? UpdatedOn { get; set; }
    }
}
