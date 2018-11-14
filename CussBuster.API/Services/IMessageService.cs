using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace CussBuster.API.Services
{
    public interface IMessageService
    {
        void ParseMessage(string message);
        List<string> Add(string naughtyWord);
        List<string> GetList();
    }
}
