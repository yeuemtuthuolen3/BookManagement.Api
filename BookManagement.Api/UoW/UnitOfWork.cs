using System;
using BookManagement.Api.DbContexts;
using BookManagement.Api.Repositories;

namespace BookManagement.Api.UoW
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        Task CommitAsync();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private IUserRepository _userRepository;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IUserRepository Users => _userRepository ??= new UserRepository(_context);

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

