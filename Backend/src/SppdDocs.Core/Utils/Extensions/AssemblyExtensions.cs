using System.Reflection;
using SppdDocs.Core.Utils.Helpers;

namespace SppdDocs.Core.Utils.Extensions
{
	public static class AssemblyExtensions
	{
		public static string GetFilePath(this Assembly assembly)
		{
			var codeBase = assembly?.CodeBase;
			return FileHelper.GetCleanFilePath(codeBase);
		}
	}
}