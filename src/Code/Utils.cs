using System;
using System.IO;
namespace VsixGallery.Code
{
	public static class Utils
	{
		public static string FixPathSeparators(this string path)
		{
			char[] _pathSeparators = new[] { '/', '\\' };
			return string.IsNullOrWhiteSpace(path) ? path : string.Join(Path.DirectorySeparatorChar, path?.Split(_pathSeparators, StringSplitOptions.RemoveEmptyEntries));
		}
	}
}
