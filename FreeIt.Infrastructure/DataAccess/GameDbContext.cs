using FreeIt.Domain.Common.Models.Db;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FreeIt.Infrastructure.DataAccess
{
    public class GameDbContext: DbContext
    {
        public GameDbContext(DbContextOptions options): base(options) { }

        public DbSet<PlayerDbModel> Players { get; set; }

        public DbSet<SavedGameDbModel> SavedGames { get; set; }

        public DbSet<QuestionDataDbModel> Questions { get; set; }

    }
}
