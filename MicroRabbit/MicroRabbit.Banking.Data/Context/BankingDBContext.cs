using MicroRabbit.Banking.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroRabbit.Banking.Data.Context
{
    public partial class BankingDBContext:DbContext
    {

        public BankingDBContext(DbContextOptions options):base(options)
        {
            
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        string connection = @"Server=NAG1-LHP-N07326\\MSSQLSERVER2019;Initial Catalog=BankingDB;User ID=sa;Password=Gl@#$12345";
        //        optionsBuilder.UseSqlServer(connection);
        //    }
        //}

        public virtual DbSet<Account> Accounts { get; set; }
    }
}
