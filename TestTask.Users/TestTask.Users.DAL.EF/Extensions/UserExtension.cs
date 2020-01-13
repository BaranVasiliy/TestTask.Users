﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TestTask.Users.DAL.EF.Entities;

namespace TestTask.Users.DAL.EF.Extensions
{
    public static class UserExtension
    {
        public static void BuildUserModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(i => i.UserId);
                entity.Property(p => p.UserId).ValueGeneratedNever();
                entity.Property(p => p.FirstName).HasMaxLength(50).IsRequired();
                entity.Property(p => p.LastName).HasMaxLength(50).IsRequired();
            });
        }
    }
}