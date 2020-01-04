using OABackground.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OABackground.Infrastructure
{
    public class LoginRepository
    {
        /// <summary>
        /// 根据帐号查询教师信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Teacherpassword Query(string id)
        {
            Teacherpassword teacher = null;
            using (var context = new oaContext())
            {
                teacher = context.Teacherpassword.FirstOrDefault(x => x.Teacherid.Equals(id));
                context.SaveChanges();
            }
            return teacher;
        }
        /// <summary>
        /// 根据登录账号查询教师信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Teacherinfomation QueryTeacherInformation(string id)
        {
            Teacherinfomation teacher = null;
            using (var context = new oaContext())
            {
                teacher = context.Teacherinfomation.FirstOrDefault(x => x.Teacherid == id);
                context.SaveChanges();
            }
            return teacher;
        }
        /// <summary>
        /// 查询教师所在部门
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Section QuerySection(string id)
        {
            Section section;
            using (var context = new oaContext())
            {
                section = context.Section.FirstOrDefault(x => x.Id == id);
                context.SaveChanges();
            }
            return section;
        }

    }
}
