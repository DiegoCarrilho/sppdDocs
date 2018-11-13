using System.Text;
using System.Web;
using SppdDocs.Core.Domain.Objects;

namespace SppdDocs.Core.Domain.Entities
{
    public abstract class NamedEntity : VersionedEntity
    {
        private string _friendlyName;

        public LocalizedText Name { get; set; }

        public string FriendlyName
        {
            get => _friendlyName ?? (_friendlyName = GetFriendlyName());
            set => _friendlyName = value;
        }

        private string GetFriendlyName()
        {
            var friendlyName = new StringBuilder();
            var nameElements = Name.En.Split(' ');
            foreach (var nameElement in nameElements)
            {
                friendlyName.Append(char.ToUpper(nameElement[0]) + nameElement.Substring(1));
            }

            return HttpUtility.UrlEncode(friendlyName.ToString());
        }
    }
}