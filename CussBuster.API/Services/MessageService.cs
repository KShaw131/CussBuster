using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CussBuster.API.Repository;
using CussBuster.API.DataAccess;
using CussBuster.Database.Entities;
using CussBuster.Database.Repository;
using CussBuster.Models;

namespace CussBuster.API.Services
{
    public class MessageService : IMessageService
    {
        private readonly IBadWordCache _badWordCache;

        public MessageService(IBadWordCache badwordCache)
        {
            _badWordCache = badwordCache;
        }
        public MessageModel ParseMessage(string message)
        {
            //Parse message
            char[] delimiters = { ' ', ',', '.', ':', '-', '\t' };
            var parsedMessage = message.ToLower().Split(delimiters);
            var curseWords = _badWordCache.CurseWords;

            var foundCurseWords = curseWords
                .Where(badWord => parsedMessage.Any(word => word.Contains(badWord.CurseWord)))
                .Select(badWord => new CurseWordModel 
                    { 
                        CurseWord = badWord.CurseWord, 
                        Severity = badWord.Severity, 
                        Type = badWord.Type.TypeName,
                        Occurrences = parsedMessage.Count(word => word.Contains(badWord.CurseWord))
                    });

            MessageModel resultModel = new MessageModel()
            {
                Message = message,
                FoundCurseWords = foundCurseWords
            };

        return resultModel;
        }
    }
}

//requirements doc  DONE
//request = string  DONE
//curseword cache   DONE
//Log4net logging   
//read paper
//adminmodel
//unit testing


//list of parsed words
//list of bad words

//for every word in bad words, see if there are any matches in list of words. If so, add to list with severity, number of times used,

