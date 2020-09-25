using System.Collections.Generic;
using FreeIt.Domain.Common.Models.Db.Base;

namespace FreeIt.Domain.Common.Models.Db
{
    public class PlayerDbModel: Entity<int>
    {
        public string Name { get; set; }

        public List<SavedGameDbModel> Games { get; set; } = new List<SavedGameDbModel>(); 
    }
}