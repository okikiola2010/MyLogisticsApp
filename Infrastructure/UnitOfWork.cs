using Application.Interfaces;
using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public class UnitOfWork(AppDbContext context):IUnitOfWork
    {
        public Task<int> SaveChanges()
        {
            return context.SaveChangesAsync();
        }
    }
}
