using HireFire.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirefire.Core.Services.Interfaces
{
    public interface IMessengerService
    {
        IEnumerable<Message> GetAllMessage(string fromUser, string toUser);//At first we will have to see if a user is in

        Message GetLatestMessageByUesrName(string userName);

        //IEnumerable<Message> GetAllContactListByUserName(string userName);//version 1
        IEnumerable<string> GetAllContactListByUserName(string userName);//Final version


        bool Insert(string fromUser, string toUser, string text);//Insert the reply message to the table

        //bool Update(Message message);
        //bool Delete(int id);
    }
}
