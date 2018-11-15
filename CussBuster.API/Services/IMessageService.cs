using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using CussBuster.Models;

namespace CussBuster.API.Services
{
    public interface IMessageService
    {
        void Add(string naughtyWord);
        MessageModel GetMessage();
    }
}
