using System;
using System.Collections.Generic;

namespace CussBuster.Database.Entities
{
    public partial class CurseWords
    {
        public int Id { get; set; }
        public string CurseWord { get; set; }
        public int Severity { get; set; }
        public int TypeId { get; set; }
        public DateTime InsertedDate { get; set; }
        public string InsertedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        public WordType Type { get; set; }
    }
}
