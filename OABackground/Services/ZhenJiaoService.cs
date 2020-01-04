using OABackground.Entities;
using OABackground.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace OABackground.Services
{

    public class AllAwardPunishList
    {
        public int id;
        public string Sid;
        public string title;
        public string studentName;
        public string sex;
        public string studentClass;
        public string grade;
        public string punishContent;
        public string awardContent;
        public string state;
        public string issue;
        public string applyTime;
        public string checkTime;
    }
    public class Award
    {
        public int id;
        public string Sid;
        public string title;
        public string content;
        public string studentName;
        public string sex;
        public string studentClass;
        public string grade;
        public string awardContent;
        public string state;
        public string issue;
        public string applyTime;
        public string checkTime;
    }
    public class Punish
    {
        public int id;
        public string Sid;
        public string title;
        public string studentName;
        public string sex;
        public string content;
        public string studentClass;
        public string grade;
        public string punishContent;
        public string state;
        public string issue;
        public string applyTime;
        public string checkTime;
    }
    public class TeacherDetail
    {
        public string teacherId;
        public string Tname;
        public string Sex;
        public string Profession;
        public string entryTime;
        public string sectionName;
        public string Phone;
    }
    public class MaterailDetail
    {
        public int Id;
        public string sectionName;
        public string teacherName;
        public string goodsName;
        public int goodsNum;
        public float goodsPrice;
        public string Remarks;
        public string State;
    }
    public class ZhenJiaoService
    {
        private ZhenJiaoRepository zhenjiaoRepository = new ZhenJiaoRepository();
        private LoginRepository loginRepository = new LoginRepository();
        private IndexRepository indexRepository = new IndexRepository();
        public List<Award> QueryAllAwardDetail()
        {
            var list = indexRepository.QueryAwardPunish();
            List<Award> awardList = new List<Award>();
            for (int i = 0; i < list.Count; i++)
            {
                var student = indexRepository.QueryStudentById(list[i].Sid);
                if (student == null)
                    continue;
                var awardDetail = new Award
                {
                    id = list[i].Id,
                    Sid = list[i].Sid,
                    issue = list[i].Issue,
                    content = list[i].Content,
                    studentName = student.Name,
                    studentClass = student.Class,
                    grade = student.Grade,
                    sex = student.Sex,
                    title = list[i].Title,
                    applyTime = list[i].ApplyTime.ToString().Replace('T', ' '),
                    checkTime = list[i].CheckTime.ToString().Replace('T', ' '),
                };
                if (list[i].PunishContent > 3)
                    awardDetail.awardContent = list[i].AwardContent;
                else
                    continue;
                if (list[i].State == 0)
                {
                    awardDetail.state = "等待审核";
                }
                else if (list[i].State == 1)
                {
                    awardDetail.state = "已通过";
                }
                else
                    awardDetail.state = "已拒绝";
                awardList.Add(awardDetail);
            }
            return awardList;
        }
        public List<Punish> QueryAllPunishDetail()
        {
            var list = indexRepository.QueryAwardPunish();
            List<Punish> punishList = new List<Punish>();
            for (int i = 0; i < list.Count; i++)
            {
                var student = indexRepository.QueryStudentById(list[i].Sid);
                var punishType = list[i].PunishContent;
                if (student == null)
                    continue;
                var punishDetail = new Punish
                {
                    id = list[i].Id,
                    Sid = list[i].Sid,
                    content = list[i].Content,
                    issue = list[i].Issue,
                    studentName = student.Name,
                    studentClass = student.Class,
                    grade = student.Grade,
                    sex = student.Sex,
                    title = list[i].Title,
                    applyTime = list[i].ApplyTime.ToString().Replace('T', ' '),
                    checkTime = list[i].CheckTime.ToString().Replace('T', ' '),
                };
                if (list[i].PunishContent < 4)
                {
                    switch (punishType)
                    {
                        case 0:
                            punishDetail.punishContent = "警告";
                            break;
                        case 1:
                            punishDetail.punishContent = "记过";
                            break;
                        case 2:
                            punishDetail.punishContent = "留校察看";
                            break;
                        case 3:
                            punishDetail.punishContent = "开除学籍";
                            break;
                        default:
                            punishDetail.punishContent = null;
                            break;
                    }
                }
                else
                    continue;
                if (list[i].State == 0)
                {
                    punishDetail.state = "等待审核";
                }
                else if (list[i].State == 1)
                {
                    punishDetail.state = "已通过";
                }
                else
                    punishDetail.state = "已拒绝";
                punishList.Add(punishDetail);
            }
            return punishList;
        }
        public List<Award> QueryAwardDetail(int id)
        {
            List<Award> awardAllList = new List<Award>();
            if (id == 0)
            {
                awardAllList = QueryAllAwardDetail();
                return awardAllList;
            }
            var AwardDetail = zhenjiaoRepository.QueryAwardPunishById(id);
            if (AwardDetail == null || AwardDetail.PunishContent < 4)
            {
                return null;
            }
            var student = indexRepository.QueryStudentById(AwardDetail.Sid);
            List<Award> showAwardList = new List<Award>();
            if (student == null)
            {
                return null;
            }
            var awardList = new Award
            {
                id = AwardDetail.Id,
                title = AwardDetail.Title,
                applyTime = AwardDetail.ApplyTime.ToString().Replace('T', ' '),
                checkTime = AwardDetail.CheckTime.ToString().Replace('T', ' '),
                issue = AwardDetail.Issue,
                Sid = student.Id,
                sex = student.Sex,
                studentClass = student.Class,
                studentName = student.Name,
                grade = student.Grade,
            };
            if (AwardDetail.State == 0)
            {
                awardList.state = "等待审核";
            }
            else if (AwardDetail.State == 1)
            {
                awardList.state = "已通过";
            }
            else
                awardList.state = "已拒绝";
            showAwardList.Add(awardList);
            return showAwardList;
        }
        public List<Punish> QueryPunishDetail(int id)
        {
            List<Punish> punishAllList = new List<Punish>();
            if (id == 0)
            {
                punishAllList = QueryAllPunishDetail();
                return punishAllList;
            }
            var punishDetail = zhenjiaoRepository.QueryAwardPunishById(id);
            if (punishDetail == null || punishDetail.PunishContent > 3)
            {
                return null;
            }
            var punishType = punishDetail.PunishContent;
            var student = indexRepository.QueryStudentById(punishDetail.Sid);
            List<Punish> showPunishList = new List<Punish>();
            if (student == null)
            {
                return null;
            }
            var punishList = new Punish
            {
                id = punishDetail.Id,
                title = punishDetail.Title,
                applyTime = punishDetail.ApplyTime.ToString().Replace('T', ' '),
                checkTime = punishDetail.CheckTime.ToString().Replace('T', ' '),
                issue = punishDetail.Issue,
                Sid = student.Id,
                sex = student.Sex,
                studentClass = student.Class,
                studentName = student.Name,
                grade = student.Grade,
            };
            switch (punishType)
            {
                case 0:
                    punishList.punishContent = "警告";
                    break;
                case 1:
                    punishList.punishContent = "记过";
                    break;
                case 2:
                    punishList.punishContent = "留校察看";
                    break;
                case 3:
                    punishList.punishContent = "开除学籍";
                    break;
                default:
                    punishList.punishContent = null;
                    break;
            }
            if (punishDetail.State == 0)
            {
                punishList.state = "等待审核";
            }
            else if (punishDetail.State == 1)
            {
                punishList.state = "已通过";
            }
            else
                punishList.state = "已拒绝";
            showPunishList.Add(punishList);
            return showPunishList;
        }
        public bool UpdateAwardPunish(int id, string issue, string state)
        {
            Awardpunish awardPunish = zhenjiaoRepository.QueryAwardPunishById(id);
            awardPunish.CheckTime = DateTime.Now.ToLocalTime();
            if (issue == null)
            {
                awardPunish.Issue = "无";
            }
            else
            {
                awardPunish.Issue = issue;
            }
            switch (state)
            {
                case "等待审核":
                    awardPunish.State = 0;
                    break;
                case "已通过":
                    awardPunish.State = 1;
                    break;
                case "已拒绝":
                    awardPunish.State = 2;
                    break;
                default:
                    break;
            }
            bool flag = zhenjiaoRepository.Update(awardPunish);
            return flag;
        }
        public List<TeacherDetail> QueryAllTeacher()
        {
            List<TeacherDetail> teacherList = new List<TeacherDetail>();
            var list = zhenjiaoRepository.QueryAllTeacher();
            for (int i = 0; i < list.Count; i++)
            {
                var section = loginRepository.QuerySection(list[i].Departmentid);
                if (section == null)
                    continue;
                var teacher = new TeacherDetail
                {
                    teacherId = list[i].Teacherid,
                    Tname = list[i].Tname,
                    Sex = list[i].Sex,
                    Profession = list[i].Profession,
                    sectionName = section.Name,
                    Phone = list[i].Phone,
                    entryTime = list[i].EntryTime.ToString().Replace('T', ' '),
                };
                teacherList.Add(teacher);
            }
            return teacherList;
        }
        public TeacherDetail QueryTeacherById(string id)
        {
            var teacher = new TeacherDetail();
            var teacherList = QueryAllTeacher();
            for (int i = 0; i < teacherList.Count; i++)
            {
                if (teacherList[i].teacherId == id)
                {
                    teacher = teacherList[i];
                    break;
                }
            }
            return teacher;
        }
        public List<TeacherDetail> QueryTeacherByName(string name)
        {
            List<TeacherDetail> teacherList = new List<TeacherDetail>();
            var list = QueryAllTeacher();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Tname.Equals(name))
                {
                    teacherList.Add(list[i]);
                }
            }
            return teacherList;
        }
        public List<TeacherDetail> QueryTeacherBySection(string sectionname)
        {
            List<TeacherDetail> teacherList = new List<TeacherDetail>();
            var list = QueryAllTeacher();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].sectionName == sectionname)
                {
                    teacherList.Add(list[i]);
                }
            }
            return teacherList;
        }
        public List<MaterailDetail> QueryMaterialDetail()
        {
            List<MaterailDetail> materialList = new List<MaterailDetail>();
            var list = zhenjiaoRepository.QueryMaterialApply();
            for (int i = 0; i < list.Count; i++)
            {
                var section = loginRepository.QuerySection(list[i].Departmentid);
                var teacher = loginRepository.QueryTeacherInformation(list[i].Tid);
                if (section == null || teacher == null)
                    continue;
              
                var material = new MaterailDetail
                {
                    Id = list[i].Id,
                    sectionName = section.Name,
                    teacherName = teacher.Tname,
                    goodsName = list[i].Goodsname,
                    goodsNum = list[i].Goodsnum,
                    goodsPrice = list[i].Goodsprice,
                    Remarks = list[i].Remarks,
                };
                switch (list[i].State)
                {
                    case 0:
                        material.State = "未处理";
                        break;
                    case 1:
                        material.State = "同意";
                        break;
                    case 2:
                        material.State = "拒绝";
                        break;
                    default:
                        break;
                }
                materialList.Add(material);
            }
            return materialList;

        }
        public List<MaterailDetail> QueryMaterialDetailByState(string name)
        {
            List<MaterailDetail> materialList = new List<MaterailDetail>();
            var list = QueryMaterialDetail();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].State == name)
                {
                    materialList.Add(list[i]);
                }
            }
            return materialList;
        }
        public List<MaterailDetail> QueryMaterialDetailBySection(string name)
        {
            List<MaterailDetail> materialList = new List<MaterailDetail>();
            var list = QueryMaterialDetail();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].sectionName == name)
                {
                    materialList.Add(list[i]);
                }
            }
            return materialList;
        }
        public bool UpdateConvention(int state, int id)
        {
            Conventionapply convention = zhenjiaoRepository.QueryConventionById(id);
            convention.ConventionState = state;
            bool flag = zhenjiaoRepository.UpdateConventionApply(convention);
            return flag;
        }
        public bool UpdateMaterial(int state, int id)
        {
            Materialapply material = zhenjiaoRepository.QueryMaterialById(id);
            material.State = state;
            bool flag = zhenjiaoRepository.UpdateMaterialApply(material);
            return flag;
        }
    }

}
