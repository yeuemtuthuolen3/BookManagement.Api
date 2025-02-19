using System;
using BookManagement.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookManagement.Api.DbContexts.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            // Cấu hình mối quan hệ giữa Order và User
            builder.HasOne(o => o.User)  // Order có một User
                .WithMany(u => u.Orders)  // User có nhiều Order
                .HasForeignKey(o => o.UserId)  // Khóa ngoại là UserId trong bảng Order
                .OnDelete(DeleteBehavior.Cascade);  // Xóa các Order nếu User bị xóa
        }
    }
}

