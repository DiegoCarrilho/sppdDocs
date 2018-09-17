using System.Security.Principal;

namespace SppdDocs.Core.Interfaces
{
	public interface IIdentityParser<T>
	{
		T Parse(IPrincipal principal);
	}
}