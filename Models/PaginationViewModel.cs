using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppNorthWind.Models
{
    public class PaginationViewModel
    {
        public int CurrentPage { get; set; }

        public int PageSize { get; set; }

        public int TotalItems { get; set; }

        public string SortOrder { get; set; }

        public int TotalPages
        {
            get
            {
                return (int)Math.Ceiling(
                    (double)TotalItems / PageSize
                );
            }
        }
    }
}