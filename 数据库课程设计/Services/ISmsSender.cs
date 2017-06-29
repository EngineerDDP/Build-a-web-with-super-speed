using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace 数据库课程设计.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
