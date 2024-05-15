using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace VsixGallery.Pages
{
	public class IndexModel : PageModel
	{
		private const int _pageSize = 24;

		private readonly PackageHelper _helper;
		public IEnumerable<Package> Packages { get; private set; }
		public int Pages { get; private set; }
		public int CurrentPage { get; private set; }

		public IndexModel(PackageHelper helper)
		{
			_helper = helper;
		}

		public void OnGet([FromQuery] int page = 1)
		{
			IEnumerable<Package> packages = _helper.PackageCache.Where(p => !p.Unlisted);

			int skip = (page - 1) * _pageSize;
			int take = page * _pageSize;
			Packages = packages.OrderByDescending(p => p.DatePublished)
							  .Skip(skip)
							  .Take(_pageSize);

			Pages = packages.Count() / _pageSize;
			CurrentPage = page;
		}
	}
}
