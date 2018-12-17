using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CussBuster.Models;
using CussBuster.API.Repository;
using CussBuster.Database.Entities;
using CussBuster.Database.Repository;

namespace CussBuster.API.Services
{
    public class MessageService : IMessageService
    {
        private readonly ICurseWordsRepository _curseWordsRepository;
        
        public MessageService(ICurseWordsRepository curseWordsRepository)
        {
            _curseWordsRepository = curseWordsRepository;
        }

        public IEnumerable<CurseWords> GetCurseWords() => _curseWordsRepository.Queryable();

        public CurseWords GetCurseWord(int id)
        {
            return _curseWordsRepository.GetById(id);
        }
    }
}