using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using OABackground.Entities;

namespace OABackground.Infrastructure
{
    public class IndexRepository
    {
        /// <summary>
        /// 查询所有的会议申请
        /// </summary>
        /// <returns></returns>
        public List<Conventionapply> QueryConventionapply()
        {
            List<Conventionapply> conventionlist = new List<Conventionapply>();
            using (var context = new oaContext())
            {
                conventionlist = (from u in context.Conventionapply
                                  select u).ToList();
                context.SaveChanges();
            }
            return conventionlist;
        }
        /// <summary>
        /// 根据职工号查询教师信息
        /// </summary>
        /// <param name="Tid"></param>
        /// <returns></returns>
        public Teacherinfomation QueryTeacherById(string Tid)
        {
            Teacherinfomation teacher = null;
            using (var context = new oaContext())
            {
                teacher = context.Teacherinfomation.FirstOrDefault(x => x.Teacherid == Tid);
                context.SaveChanges();
            }
            return teacher;
        }
        /// <summary>
        /// 查询教师所在的部门
        /// </summary>
        /// <param name="Sid"></param>
        /// <returns></returns>
        public Section QuerySectionById(string Sid)
        {
            Section section = null;
            using (var context = new oaContext())
            {
                section = context.Section.FirstOrDefault(x => x.Id == Sid);
                context.SaveChanges();
            }
            return section;
        }
        /// <summary>
        /// 查询奖惩信息
        /// </summary>
        /// <returns></returns>
        public List<Awardpunish> QueryAwardPunish()
        {
            List<Awardpunish> awardpubishlist = new List<Awardpunish>();
            using (var context = new oaContext())
            {
                awardpubishlist = (from u in context.Awardpunish
                                   select u).ToList();
                context.SaveChanges();
            }
            return awardpubishlist;
        }
        public Awardpunish QueryAwardPunishDetail(int id)
        {
            Awardpunish awardpunish = new Awardpunish();
            using (var context = new oaContext())
            {
                awardpunish = context.Awardpunish.FirstOrDefault(x => x.Id == id);
                context.SaveChanges();
            }
            return awardpunish;
        }
        /// <summary>
        /// 查询学生信息
        /// </summary>
        /// <param name="Sid"></param>
        /// <returns></returns>
        public Student QueryStudentById(string Sid)
        {
            Student student = null;
            using (var context = new oaContext())
            {
                student = context.Student.FirstOrDefault(x => x.Id == Sid);
                context.SaveChanges();
            }
            return student;
        }
    }
}
