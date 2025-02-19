using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookManagement.Api.Entities
{
	public class EntityBase
	{
        [Key]  // Đánh dấu thuộc tính là khóa chính
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
		public DateTime CreateAt { get; set; }
		public string CreateBy { get; set; } = string.Empty;
        public DateTime UpdateAt { get; set; }
        public string UpdateBy { get; set; } = string.Empty;
    }
}

