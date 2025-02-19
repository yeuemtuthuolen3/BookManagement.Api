using System;
namespace BookManagement.Api.Entities
{
	public class User: EntityBase
	{
		public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        // Mối quan hệ một User có thể có nhiều Order
        public ICollection<Order> Orders { get; set; }
    }
}

