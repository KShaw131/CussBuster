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
            List<string> curseWordList = _curseWordsRepository.Queryable()
                .Where(x => x.Severity > message.SeverityLimit)
                .Select(x => x.CurseWord).ToList();

            //Iterate through parsed message collection and see if it contains curse words
            foreach(var word in parsedMessage)
            {
                if(curseWordList.Contains(word))
                {
                    updatedMessage = Regex.Replace(updatedMessage, word, "****", RegexOptions.IgnoreCase);
                }
            }

            message.Message = updatedMessage.ToString();

            return message;
        }
    }
}