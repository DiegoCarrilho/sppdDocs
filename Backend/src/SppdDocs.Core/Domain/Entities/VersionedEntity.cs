using System;

namespace SppdDocs.Core.Domain.Entities
{
    public abstract class VersionedEntity : BaseEntity
    {
        /// <summary>
        ///     Gets or sets the current version identifier.
        /// </summary>
        public Guid CurrentId { get; set; }

        /// <summary>
        ///     Specifies what changes have been made for this version
        /// </summary>
        public string VersionComment { get; set; }

        /// <summary>
        ///     Gets a value indicating whether this is the current version.
        /// </summary>
        public bool IsCurrent => Id == CurrentId;
    }
}