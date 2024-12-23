﻿using LibraryData.Configurations;
using LibraryData.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryData.Context
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookGenre> BookGenres { get; set; }
        public DbSet<Customer> Customers { get; set; }  
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookConfig())
                        .ApplyConfiguration(new AuthorConfig())
                        .ApplyConfiguration(new AccountConfig())
                        .ApplyConfiguration(new OrderDetailConfig());

            modelBuilder.Entity<Book>()
                .HasMany(s => s.Authors)
                .WithMany(s => s.Books)
                .UsingEntity(a => a.ToTable("bookAuthor"));

        }
    }
}
