using OABackground.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OABackground.Infrastructure
{
    public class ZhenJiaoRepository
    {
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
        public Awardpunish QueryAwardPunishById(int id)
        {
            Awardpunish award = null;
            using (var context = new oaContext())
            {
                award = context.Awardpunish.FirstOrDefault(x => x.Id == id);
                context.SaveChanges();
            }
            return award;
        }
        public bool Update(Awardpunish awardPunish)
        {
            using (var context = new oaContext())
            {
                try
                {
                    context.Awardpunish.Update(awardPunish);
                }
                catch
                {
                    return false;
                }
                context.SaveChanges();
            }
            return true;
        }
        public List<Teacherinfomation> QueryAllTeacher()
        {
            List<Teacherinfomation> teacherList = new List<Teacherinfomation>();
            using (var context = new oaContext())
            {
                teacherList = (from u in context.Teacherinfomation
                               select u).ToList();
                context.SaveChanges();
            }
            return teacherList;
        }
        public Teacherinfomation QueryTeacherById(string id)
        {
            Teacherinfomation teacher = null;
            using (var context = new oaContext())
            {
                teacher = context.Teacherinfomation.FirstOrDefault(x => x.Teacherid == id);
                context.SaveChanges();
            }
            return teacher;
        }
        public List<Materialapply> QueryMaterialApply()
        {
            List<Materialapply> materialList = new List<Materialapply>();
            using (var context = new oaContext())
            {
                materialList = (from u in context.Materialapply
                                   select u).ToList();
                context.SaveChanges();
            }
            return materialList;
        }
        public bool UpdateMaterialApply(Materialapply materialApply)
        {
            using (var context = new oaContext())
            {
                try
                {
                    context.Materialapply.Update(materialApply);
                }
                catch
                {
                    return false;
                }
                context.SaveChanges();
            }
            return true;
        }
        public bool UpdateConventionApply(Conventionapply conventionApply)
        {
            using (var context = new oaContext())
            {
                try
                {
                    context.Conventionapply.Update(conventionApply);
                }
                catch
                {
                    return false;
                }
                context.SaveChanges();
            }
            return true;
        }
        public Conventionapply QueryConventionById(int id)
        {
            Conventionapply convention = null;
            using (var context = new oaContext())
            {
                convention = context.Conventionapply.FirstOrDefault(x => x.Id == id);
                context.SaveChanges();
            }
            return convention;
        }
        public Materialapply QueryMaterialById(int id)
        {
            Materialapply material = null;
            using (var context = new oaContext())
            {
                material = context.Materialapply.FirstOrDefault(x => x.Id == id);
                context.SaveChanges();
            }
            return material;
        }
    }
}
