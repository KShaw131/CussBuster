using System;
using System.Collections.Generic;

namespace CussBuster.Database.Entities
{
    public partial class WordType
    {
        public WordType()
        {
            CurseWords = new HashSet<CurseWords>();
        }

        public int Id { get; set; }
        public string TypeName { get; set; }

        public ICollection<CurseWords> CurseWords { get; set; }
    }
}
