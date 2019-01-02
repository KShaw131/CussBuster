using System;
using System.Collections.Generic;
using CussBuster.Database.Entities;

namespace CussBuster.API.Services
{
    public interface IAdminService
    {
        CurseWords GetCurseWord(int id);
        IEnumerable<CurseWords> GetCurseWords();
        CurseWords AddCurseWord(CurseWords curseword);
        void RemoveCurseWord(CurseWords curseWord);
        CurseWords UpdateCurseWord(CurseWords curseWord);
    }
}
