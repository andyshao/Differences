﻿using Differences.Interaction.Models;
using Differences.Interaction.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Microsoft.Extensions.Options;

namespace Differences.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DifferencesDbContext _dbContext;

        public UserRepository(DifferencesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool Exists(Guid userId)
        {
            return _dbContext.Users.Any(x => x.Id == userId);
        }

        public User Get(Guid userId)
        {
            return _dbContext.Users.SingleOrDefault(x => x.Id == userId);
        }

        public User Add(User user)
        {
            _dbContext.Users.Add(user);
            return user;
        }

        public IQueryable<User> GetAll()
        {
            return _dbContext.Users;
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
