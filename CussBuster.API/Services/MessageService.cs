using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CussBuster.API.Services
{
    public class MessageService : IMessageService
    {

        //temporary list for testing purposes
            List<string> tempTable = new List<string>()
            {
                "Eat",
                "My",
                "Whole",
                "Ass"
            };

        public void ParseMessage(string message)
        {
            Array ParsedMessage = message.ToArray();
        }

        public List<string> Add(string naughtyWord)
        {
            tempTable.Add(naughtyWord);
            
            return tempTable;
        }

        public List<string> GetList(){
            return tempTable;
        }

    }
}
