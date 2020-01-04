using OABackground.Entities;
using OABackground.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace OABackground.Services
{
    public class FileService
    {
        private FileRepository fileRepository;
        public FileService()
        {
            fileRepository = new FileRepository();
        }
        public List<Plantable> QueryFile(string teacherid)
        {
            var File = fileRepository.QueryFile(teacherid);
            return File;
        }
        public List<Plantable> QueryAllFile()
        {
            var File = fileRepository.QueryAllFile();
            return File;
        }
        public bool upload(string fileAddress, string fileName, string teacherId, string issue)
        {
            fileRepository.Upload(fileAddress, fileName, teacherId, issue);
            return true;
        }
    }
}
