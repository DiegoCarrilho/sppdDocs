namespace SppdDocs.Core.Domain.Entities
{
    /// <summary>
    ///     Represents the attribute of a card like range, health, attack, card upgrades.
    /// </summary>
    /// <seealso cref="SppdDocs.Core.Domain.Entities.NamedEntity" />
    public class CardAttribute : NamedEntity
    {
        /// <summary>
        ///     Defines the sort order. <see cref="CardAttribute" /> with a lower <see cref="SortIndex" /> will be first.
        /// </summary>
        public int SortIndex { get; set; }
    }
}