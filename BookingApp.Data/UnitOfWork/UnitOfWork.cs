﻿using BookingApp.Data.Context;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BookingAppDbContext _context;

        private IDbContextTransaction _transaction;

        public UnitOfWork(BookingAppDbContext context)
        {
            _context = context;
        }
        public async Task BeginTransactions()
        {
            _transaction=await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactions()
        {
            await _transaction.CommitAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
            //Garbage Collector'a sen bunu temizleyebilirsin iznini verdiğimiz yer yalnızca silme izni verilir dikkat!

            //Garbage Collector'ı hemen çalıştırmak istersek;
            //GC.Collect();
            //GC.WaitForPendingFinalizers(); kullanırız
        }

        public async Task RollBackTransaction()
        {
            await _transaction.RollbackAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await SaveChangesAsync();
        }
    }
}
