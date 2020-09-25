using System.Collections.Generic;
using FreeIt.Domain.Common.Enums;
using FreeIt.Domain.Common.Models.Db.Base;

namespace FreeIt.Domain.Common.Models.Db
{
    public class SavedGameDbModel : Entity<int>
    {
        public ushort LastStep { get; set; }

        public StatusGame Status { get; set; }

        public List<QuestionDataDbModel> Questions { get; set; } = new List<QuestionDataDbModel>();
    }
}