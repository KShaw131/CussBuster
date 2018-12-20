using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CussBuster.API.Repository;
using CussBuster.Database.Entities;
using CussBuster.Database.Repository;
using CussBuster.Models;
using System.Text.RegularExpressions;

namespace CussBuster.API.Services
{
    public class MessageService : IMessageService
    {
        private readonly ICurseWordsRepository _curseWordsRepository;

        public MessageService(ICurseWordsRepository curseWordsRepository)
        {
            _curseWordsRepository = curseWordsRepository;
        }
        public MessageModel parseMessage(MessageModel message)
        {
            //Parse message
            char[] delimiters = { ' ', ',', '.', ':', '\t' };
            string[] parsedMessage = message.Message.ToLower().Split(delimiters);
            string updatedMessage = message.Message;

            //Gather current curse words from db. Enumerate to list
            IEnumerable<CurseWords> curseWords = _curseWordsRepository.Queryable();
            List<string> curseWordList = curseWords.Select(x => x.CurseWord).ToList();

            //Iterate through parsed message collection and see if it contains curse words
            foreach(var word in parsedMessage)
            {
                if(curseWordList.Contains(word.ToString()))
                {
                    //build orignal message with replaced curse words
                    if(curseWords.Where(x => x.CurseWord == word.ToString()).Select(x=>x.Severity).First() > message.SeverityLimit)
                    {
                        updatedMessage = Regex.Replace(updatedMessage, word, "****", RegexOptions.IgnoreCase);
                    }
                }
            }

            message.Message = updatedMessage;

            return message;
        }
    }
}


/*
-Post messageModel DONE
-Service should parse message into a collection
-Grab current list of curse words from db
-Iterate through collection and search for matching words using find
-If words are found store in a Found collection
-
-Business idea - set a severity limit which allows certain levels to pass through
-Return message with replaced words with stars and the collection of words found
*/