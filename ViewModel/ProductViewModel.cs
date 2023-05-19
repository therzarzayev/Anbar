using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace EFCore.ViewModel
{
	public class ProductViewModel
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public string? Description { get; set; }
		[RegularExpression(@"^[0-9]+(\.[0-9]{1,2})", ErrorMessage ="Qiymət düzgün formatda deyil!")]
		public decimal? Price { get; set; }
		public DateTime? Date { get; set; }
		public DateTime? ExDate { get; set; }
		public string? Category { get; set; }
		public string? State { get; set; }
	}
}
