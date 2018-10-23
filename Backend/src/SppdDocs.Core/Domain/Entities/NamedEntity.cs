using SppdDocs.Core.Domain.Objects;

namespace SppdDocs.Core.Domain.Entities
{
    public abstract class NamedEntity : VersionedEntity
    {
        public LocalizedText Name { get; set; }

        public byte[] Image { get; set; }
    }
}