using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Application.DTOs.Admin
{
    public class PaginationRequestDto
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string SearchTerm { get; set; }
        public string SortColumn { get; set; } = "Created_At";
        public string SortDirection { get; set; } = "DESC";
        public string Username { get; set; }
        public string Email { get; set; }
    }
}
