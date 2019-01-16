using System;
using System.Collections.Generic;
using CussBuster.Database.Entities;
using CussBuster.Models;

namespace CussBuster.API.Services
{
    public interface IMessageService
    {
        MessageModel ParseMessage(string message);
    }
}