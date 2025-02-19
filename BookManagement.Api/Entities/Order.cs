using System;
namespace BookManagement.Api.Entities
{
	public class Order : EntityBase
	{
        public string OrderNumber { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }

        // Khóa ngoại (foreign key) để liên kết với User
        public long UserId { get; set; }

        // Điều hướng đến User
        public User User { get; set; }
    }
}

