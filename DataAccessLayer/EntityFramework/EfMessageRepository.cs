using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfMessageRepository : GenericRepository<Message>, IMessageDal
    {
        public List<Message> GetInboxWithMessageByWriter(int id)
        {
            using (var c = new Context())
            {
                return c.Messages.Include(x =>x.WrtierSender).Where(x=>x.ReceiverID == id).ToList();
            }
        }

        public List<Message> GetSendboxWithMessageByWriter(int id)
        {
            using (var c = new Context())
            {
                return c.Messages.Include(x => x.WriterReceiver).Where(x => x.SenderID == id).ToList();
            }
        }
    }
}
