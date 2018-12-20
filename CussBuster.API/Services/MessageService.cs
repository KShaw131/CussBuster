using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CussBuster.API.Repository;
using CussBuster.Database.Entities;
using CussBuster.Database.Repository;
using CussBuster.Models;
using System.Text;

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
            string[] parsedMessage = message.Message.Split(delimiters);
            //string updatedMessage = message.Message;

            //Gather curse words from db that are above the severity level
            IEnumerable<CurseWords> curseWords = _curseWordsRepository.Queryable();
            List<string> curseWordList = curseWords.Where(x=>x.Severity > message.SeverityLimit).Select(x => x.CurseWord).ToList();

            //Using FlexSeal to resolve my leaky code
            StringBuilder updatedMessage = new StringBuilder(message.Message);

            var test = parsedMessage.Where(o => curseWordList.Any().Equals(o));

            message.Message = updatedMessage.ToString();

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