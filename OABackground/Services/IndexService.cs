using OABackground.Infrastructure;
using System.Collections.Generic;

namespace OABackground.Services
{
    public class ConventionList
    {
        public int id;
        public string proposerName;
        public string proposerSection;
        public string proposerPhone;
        public string startTime;
        public string endTime;
        public string place;
        public string currentState;
    }
    public class AwardPunishList
    {
        public int id;
        public string Sid;
        public string title;
        public string content;
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
    
    public class IndexService
    {
        private IndexRepository indexRepository = new IndexRepository();
        public List<ConventionList> QueryConventionapply()
        {
            var list = indexRepository.QueryConventionapply();
            List<ConventionList> conventions = new List<ConventionList>();
            for (int i = 0; i < list.Count; i++)
            {
                var teacher = indexRepository.QueryTeacherById(list[i].Contact);
                var section = indexRepository.QuerySectionById(teacher.Departmentid);
                if (teacher.Equals(""))
                    continue;
                ConventionList convention = new ConventionList
                {
                    id = list[i].Id,
                    place = list[i].ConventionPlace,
                    startTime = list[i].StartTime.ToString().Replace('T', ' '),
                    endTime = list[i].EndTime.ToString().Replace('T', ' '),
                    proposerName = teacher.Tname,
                    proposerSection = section.Name,
                    proposerPhone = teacher.Phone,
                };
                if (list[i].ConventionState == 0)
                {
                    convention.currentState = "正在审核";
                }
                else if (list[i].ConventionState == 1)
                {
                    convention.currentState = "通过申请";
                }
                else
                    convention.currentState = "已被拒绝";
                conventions.Add(convention);
            }
            return conventions;
        }
        public List<AwardPunishList> QueryAwardPunish()
        {
            var list = indexRepository.QueryAwardPunish();
            List<AwardPunishList> awardpunishList = new List<AwardPunishList>();
            for (int i = 0; i < list.Count; i++)
            {
                var student = indexRepository.QueryStudentById(list[i].Sid);
                if (student.Equals(""))
                    continue;
                var awardpunish = new AwardPunishList
                {
                    id = list[i].Id,
                    title = list[i].Title,
                    applyTime = list[i].ApplyTime.ToString().Replace('T', ' '),
                    checkTime = list[i].CheckTime.ToString().Replace('T', ' '),
                };
                if (list[i].State == 0)
                {
                    awardpunish.state = "等待审核";
                }
                else if (list[i].State == 1)
                {
                    awardpunish.state = "已通过";
                }
                else
                    awardpunish.state = "已拒绝";
                awardpunishList.Add(awardpunish);
            }
            return awardpunishList;
        }
        public AwardPunishList QueryAwardPunishDetail(int id)
        {
            var awardPunishDetail = indexRepository.QueryAwardPunishDetail(id);
            if (awardPunishDetail == null || id == 0)
            {
                return null;
            }
            var student = indexRepository.QueryStudentById(awardPunishDetail.Sid);
            if (student.Equals(""))
            {
                return null;
            }
            var awardpunish = new AwardPunishList
            {
                id = awardPunishDetail.Id,
                Sid = awardPunishDetail.Sid,
                awardContent = awardPunishDetail.AwardContent,
                title = awardPunishDetail.Title,
                content = awardPunishDetail.Content,
                issue = awardPunishDetail.Issue,
                applyTime = awardPunishDetail.ApplyTime.ToString().Replace('T', ' '),
                checkTime = awardPunishDetail.CheckTime.ToString().Replace('T', ' '),
                studentName = student.Name,
                sex = student.Sex,
                studentClass = student.Class,
                grade = student.Grade
            };
            switch (awardPunishDetail.State)
            {
                case 0:
                    awardpunish.state = "等待审核";
                    break;
                case 1:
                    awardpunish.state = "已通过";
                    break;
                case 2:
                    awardpunish.state = "已拒绝";
                    break;
                default:
                    awardpunish.state = "未知状态";
                    break;
            }
            switch (awardPunishDetail.PunishContent)
            {
                case 0:
                    awardpunish.punishContent = "警告";
                    awardpunish.awardContent = null;
                    break;
                case 1:
                    awardpunish.punishContent = "记过";
                    awardpunish.awardContent = null;
                    break;
                case 2:
                    awardpunish.punishContent = "留校察看";
                    awardpunish.awardContent = null;
                    break;
                case 3:
                    awardpunish.punishContent = "开除学籍";
                    awardpunish.awardContent = null;
                    break;
                default:
                    awardpunish.punishContent = null;
                    break;
            }
            return awardpunish;
        }
    }
}
