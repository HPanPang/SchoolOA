using OABackground.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OABackground.Infrastructure
{
    public class FileRepository
    {
        public void Upload(string fileAddress, string fileName, string teacherId,string issue)
        {
            using (oaContext context = new oaContext())
            {
                Plantable upload = new Plantable();
                upload.Filepath = fileAddress;
                upload.Filename = fileName;
                upload.Teacherid = teacherId;
                upload.Committime = DateTime.Now;
                upload.Issue = issue;
                context.Plantable.Add(upload);
                context.SaveChanges();
            }
        }
        public List<Plantable> QueryFile(string teacherid)
        {
            List<Plantable> fileOrder = new List<Plantable>();
            using (oaContext context = new oaContext())
            {
                fileOrder = (from u in context.Plantable
                             where u.Teacherid.Equals(teacherid)
                             select u).ToList();
                context.SaveChanges();
            }
            return fileOrder;
        }
        public List<Plantable> QueryAllFile()
        {
            List<Plantable> fileOrder = new List<Plantable>();
            using (oaContext context = new oaContext())
            {
                fileOrder = (from u in context.Plantable
                             select u).ToList();
                context.SaveChanges();
            }
            return fileOrder;
        }
    }
}
