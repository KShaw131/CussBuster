using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CussBuster.API.Repository;
using CussBuster.Database.Entities;
using CussBuster.Database.Repository;

namespace CussBuster.API.Services
{
    public class AdminService : IAdminService
    {
        private readonly ICurseWordsRepository _curseWordsRepository;
        
        public AdminService(ICurseWordsRepository curseWordsRepository)
        {
            _curseWordsRepository = curseWordsRepository;
        }

        public IEnumerable<CurseWords> GetCurseWords() => _curseWordsRepository.Queryable();

        public CurseWords GetCurseWord(int id)
        {
            return _curseWordsRepository.GetById(id);
        }

        public CurseWords AddCurseWord(CurseWords curseWord)
        {
            return _curseWordsRepository.Add(curseWord);
        }

        public void RemoveCurseWord(CurseWords curseWord)
        {
            _curseWordsRepository.Delete(curseWord);
        }

        public CurseWords UpdateCurseWord(CurseWords curseWord)
        {
            return _curseWordsRepository.Update(curseWord);
        }
    }
}