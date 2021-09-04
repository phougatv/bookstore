namespace Atlantis.Books.Persistence.Base
{
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
    }
}
