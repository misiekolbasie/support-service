using Microsoft.EntityFrameworkCore;
using SupportService.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SupportService.DataAccess
{
    public class SupportServiceDbContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; } // tables
        public DbSet<TicketEntity> Tickets { get; set; }
        public DbSet<MessageEntity> Messages { get; set; }

        public SupportServiceDbContext(DbContextOptions<SupportServiceDbContext> options) : base(options) //-----construct
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<UserEntity>()
            //    .HasMany(c => c.Tickets)
            //    .WithOne(c => c.User)
            //    .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<UserEntity>()
            //    .HasMany(c => c.Messages)
            //    .WithOne(c => c.User)
            //    .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<TicketEntity>()
            //    .HasOne(c => c.User)
            //    .WithOne(c => c.User)
            //    .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<GroupMember>()
            //    .HasOne(pt => pt.User)
            //    .WithMany(p => p.MemberOf)
            //    .HasForeignKey(pt => pt.UserId);

            //modelBuilder.Entity<GroupMember>()
            //    .HasOne(pt => pt.Group)
            //    .WithMany(t => t.GroupMembers)
            //    .HasForeignKey(pt => pt.GroupId);
        }
    }
}
