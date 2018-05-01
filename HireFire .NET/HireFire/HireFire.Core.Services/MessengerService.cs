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
            throw new NotImplementedException();
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


        public bool Insert(Message message)//Insert the reply message to the table
        {
            throw new NotImplementedException();
        }


    }
}
