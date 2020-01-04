using OABackground.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace OABackground.Services
{
    public class LoginSevice
    {
        private LoginRepository loginRepository = new LoginRepository();
        /// <summary>
        /// 验证账号密码是否正确
        /// </summary>
        /// <param name="id"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool VerifyPassword(string id, string password)
        {

            var teacher = loginRepository.Query(id);
            if (teacher == null)
                return false;
            if (teacher.Teacherpassword1 == password)
            {
                return true;
            }
            else
                return false;
        }
        /// <summary>
        /// 判断登录教师与其所在的部门是否一致
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public bool VerifySection(string id, string type)
        {
            string sectionname;
            var teacher = loginRepository.QueryTeacherInformation(id);
            var section = loginRepository.QuerySection(teacher.Departmentid);
            if(teacher == null || section == null)
            {
                return false;
            }
            switch (type)
            {
                case "js":
                    sectionname = "教师";
                    break;
                case "cwc":
                    sectionname = "财务处";
                    break;
                case "zjc":
                    sectionname = "政教处";
                    break;
                case "xz":
                    sectionname = "校长";
                    break;
                default:
                    sectionname = "不存在";
                    break;
            }
            return section.Name == sectionname;
        }
    }
}
