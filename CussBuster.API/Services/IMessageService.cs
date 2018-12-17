using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using CussBuster.Models;
using CussBuster.Database.Entities;

namespace CussBuster.API.Services
{
    public interface IMessageService
    {
        CurseWords GetCurseWord(int id);

        IEnumerable<CurseWords> GetCurseWords();

        // CurseWords PostCurseWord(CurseWords curseword);
    }
}
