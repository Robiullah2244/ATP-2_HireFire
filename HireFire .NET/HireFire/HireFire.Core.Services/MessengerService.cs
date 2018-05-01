using Hirefire.Core.Services.Interfaces;
using HireFire.Core.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireFire.Core.Services
{
    public class MessengerService : IMessengerService
    {
        DbContext _context;

        public MessengerService(DbContext context)
        {
            _context = context;
        }
        public IEnumerable<Message> GetAllMessage(string fromUser, string toUser)//At first we will have to see if a user is in
        {
            return _context.Set<Message>().Where(b => (b.FromUser == fromUser
                && b.ToUser == toUser) || (b.FromUser == toUser && b.ToUser == fromUser));//.OrderByDescending(b => b.Id);

        }

        public Message GetLatestMessageByUesrName(string userName)
        {
            return _context.Set<Message>().Where(b => b.FromUser == userName || b.ToUser == userName).OrderByDescending(b => b.Id).FirstOrDefault();
            //return _context.Set<Message>().Where(b => b.FromUser == userName || b.ToUser==userName).OrderBy(b=>b.Id).LastOrDefault();
            //return x;
            //throw new NotImplementedException();
        }

        //public IEnumerable<Message> GetAllContactListByUserName(string userName)//Version 1
        //{
        //    //select * from Messages where FromUser='tanim'or ToUser='tanim' order by id desc
        //    //int y = _context.Set<Message>().Select(b => b.ConversionNumber).Distinct().Count();
        //    int y = _context.Set<Message>().Where(b => b.FromUser == userName || b.ToUser == userName).Select(b => b.ConversionNumber).Distinct().Count();

        //    return _context.Set<Message>().Where(b => b.FromUser == userName || b.ToUser == userName).OrderByDescending(b => b.Id).Take(y);
            

        //    //throw new NotImplementedException();
        //}

        public IEnumerable<string> GetAllContactListByUserName(string userName)//Final version
        {
            //select * from Messages where FromUser='tanim'or ToUser='tanim' order by id desc
            //int y = _context.Set<Message>().Select(b => b.ConversionNumber).Distinct().Count();
            int y = _context.Set<Message>().Where(b => b.FromUser == userName || b.ToUser == userName).Select(b => b.ConversionNumber).Distinct().Count();
            var x= _context.Set<Message>().Where(b => b.FromUser == userName || b.ToUser == userName).OrderByDescending(b => b.Id).Take(y);
            List <string> userList=new List<string>();
            foreach (var x1 in x)
            {
                if (x1.FromUser != userName)
                    userList.Add(x1.FromUser);
                else if (x1.ToUser != userName)
                    userList.Add(x1.ToUser);
            }

            return userList;
        }


        public bool Insert(string fromUser, string toUser, string text)//Insert the reply message to the table
        {
            int conversionNumber = _context.Set<Message>().Where(b => (b.FromUser == fromUser
                && b.ToUser == toUser) || (b.FromUser == toUser && b.ToUser == fromUser)).Select(b => b.ConversionNumber).FirstOrDefault();
            if (conversionNumber > 0)//It means I have previously communicate with this user
            {
                try
                {
                    Message message = new Message();
                    message.FromUser = fromUser;
                    message.ToUser = toUser;
                    message.Text = text;
                    message.ConversionNumber = conversionNumber;
                    _context.Set<Message>().Add(message);
                    _context.SaveChanges();
                    return true;
                }
                catch 
                {
                    return false;
                }
            }

            else
            {
                int nextConversionNumber = _context.Set<Message>().Select(b => b.ConversionNumber).Max()+1;// SingleOrDefault()
                try
                {
                    Message message = new Message();
                    message.FromUser = fromUser;
                    message.ToUser = toUser;
                    message.Text = text;
                    message.ConversionNumber = nextConversionNumber;
                    _context.Set<Message>().Add(message);
                    _context.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            
        }


    }
}
