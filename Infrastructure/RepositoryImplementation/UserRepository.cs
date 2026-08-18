using Application.Interfaces.Repository;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.RepositoryImplementation
{
    public class UserRepository(AppDbContext context) : IUserRepository
    {
        public async Task Add(User user)
        {
           await context.Users.AddAsync(user);
        }

        public async Task<User?> Get(Guid id)
        {
            return await context.Users.AsNoTracking().FirstOrDefaultAsync(u  => u.Id == id);
        }

        public async Task<User?> Get(string email)
        {
            return await context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Email == email);
        }
        public async Task Update(User user)
        {
            context.Users.Update(user);
        }
    }
}
