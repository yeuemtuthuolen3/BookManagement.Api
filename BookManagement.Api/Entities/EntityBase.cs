using System;
namespace BookManagement.Api.Entities
{
	public class EntityBase
	{
		public long Id { get; set; }
		public DateTime CreateAt { get; set; }
		public string CreateBy { get; set; } = string.Empty;
        public DateTime UpdateAt { get; set; }
        public string UpdateBy { get; set; } = string.Empty;
    }
}

