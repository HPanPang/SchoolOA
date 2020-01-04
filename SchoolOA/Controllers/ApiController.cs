using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OABackground.Services;
using SchoolOA.Models;

namespace SchoolOA.Controllers
{
    public class ApiController : Controller
    {
        protected LoginSevice loginsevice = new LoginSevice();
        protected IndexService indexservice = new IndexService();
        protected ZhenJiaoService zhenjiaoservice = new ZhenJiaoService();
        protected FileService fileService = new FileService();
        public class FileData
        {
            public int id;
            public string teacherid;
            public string filepath;
            public string filename;
            public string committime;
            public string state;
            public string issue;
        }
        public enum FileState
        {
            等待审核 = 0,
            已通过,
            等待修正,
            已修正,
            已驳回
        }
        public object LogInJudge(string username, string password, string type)
        {
            bool isVerifyPassword = loginsevice.VerifyPassword(username, password);
            bool isMatchSection = loginsevice.VerifySection(username, type);
            if (!isMatchSection)
            {
                return Json(new
                {
                    code = 270,
                    msg = "请选择与您帐号匹配的部门"
                });
            }
            if (isVerifyPassword)
            {
                switch (type)
                {
                    case "js":
                    case "xz":
                    case "zjc":
                    case "cwc":
                        return Json(new
                        {
                            code = 200,
                            msg = "登录成功，正在跳转页面。。。"
                        });
                    default:
                        return Json(new
                        {
                            code = 100,
                            msg = "内部服务器错误"
                        });
                }
            }
            else
            {
                return Json(new
                {
                    code = 210,
                    msg = "密码与帐号不匹配。",
                });
            }
        }
        public object GetConventionApply(int page, int limit)
        {
            var conventionList = indexservice.QueryConventionapply();
            var showConventionList = conventionList.Skip((page - 1) * limit).Take(limit);
            return Json(new
            {
                code = 0,
                msg = "会议信息",
                count = conventionList.Count,
                data = showConventionList
            });
        }
        public object AwardPunishList(int page, int limit)
        {
            var awardPunishList = indexservice.QueryAwardPunish();
            var showAwardPunishList = awardPunishList.Skip((page - 1) * limit).Take(limit);
            return Json(new
            {
                code = 0,
                msg = "奖惩信息",
                count = awardPunishList.Count,
                data = showAwardPunishList
            }); 
        }
        public object ShowAwardPunishList(int id)
        {
            var awardPunishDetail = indexservice.QueryAwardPunishDetail(id);
            if(awardPunishDetail.punishContent==null)
            {
                return Json(new
                {
                    code = 0,
                    msg = "奖励信息",
                    awardDetail = awardPunishDetail
                });
            }
            return Json(new
            {
                code =1,
                msg="惩罚信息",
                punishDetail = awardPunishDetail
            });
        }

        public object ShowAwardList (int id)
        {
            var awardDetail = zhenjiaoservice.QueryAwardDetail(id);
            if (awardDetail==null || id == 0)
            {
                return Json(new
                {
                    code = 270,
                    msg ="错误请求"
                });
            }
            return Json(new
            {
                code = 0,
                msg = "奖励信息",
                award = awardDetail,
            });
        }
        public object ShowPunishList(int id)
        {
            var punishDetail = zhenjiaoservice.QueryPunishDetail(id);
            if (punishDetail == null || id == 0)
            {
                return Json(new
                {
                    code = 270,
                    msg = "错误请求"
                });
            }
            return Json(new
            {
                code = 0,
                msg = "惩罚信息",
                award = punishDetail,
            });
        }
        public object AwardList(int page,int limit)
        {
            var awardDetail = zhenjiaoservice.QueryAllAwardDetail();
            var showAwardDetail = awardDetail.Skip((page - 1) * limit).Take(limit);
            
            return Json(new
            {
                code = 0,
                msg ="所有奖励信息",
                count = awardDetail.Count,
                data = showAwardDetail,
            });
        }
        public object PunishList(int page, int limit)
        {
            var punishDetail = zhenjiaoservice.QueryAllPunishDetail();
            var showPunishDetail = punishDetail.Skip((page - 1) * limit).Take(limit);
            return Json(new
            {
                code = 0,
                msg = "所有惩罚信息",
                count = punishDetail.Count,
                data = showPunishDetail,
            });
        }
        public object SubmitHandleAwardPunish(int id,string issue,string state)
        {
            bool isSuccess = zhenjiaoservice.UpdateAwardPunish(id, issue, state);
            var updateDate = zhenjiaoservice.QueryPunishDetail(id);
            if (isSuccess)
            {
                return Json(new
                {
                    code = 0,
                    msg = "修改成功",
                    data = updateDate
                });
            }
            else
            {
                return Json(new
                {
                    code = 1,
                    msg = "修改失败",
                    data = updateDate
                });
            }
        }
        public object QueryFile(string teacherid, int page = 1, int limit = 10)
        {
            var fileData = fileService.QueryFile(teacherid).Skip((page - 1) * limit).Take(limit);
            List<FileData> fileDataList = new List<FileData>();
            foreach (var item in fileData)
            {
                var temData = new FileData();
                temData.id = item.Id;
                temData.teacherid = item.Teacherid;
                temData.filepath = item.Filepath;
                temData.filename = item.Filename;
                temData.committime = item.Committime.ToString().Replace('T', ' ');
                temData.state = ((FileState)item.State).ToString();
                fileDataList.Add(temData);
            }
            return Json(new
            {
                code = 0,
                msg = "查询成功",
                data = fileDataList
            });
        }
        public object QueryAllFile(int page = 1, int limit = 10)
        {
            var fileData = fileService.QueryAllFile().Skip((page - 1) * limit).Take(limit);
            List<FileData> fileDataList = new List<FileData>();
            foreach (var item in fileData)
            {
                var temData = new FileData();
                temData.id = item.Id;
                temData.teacherid = item.Teacherid;
                temData.filepath = item.Filepath;
                temData.filename = item.Filename;
                temData.committime = item.Committime.ToString().Replace('T', ' ');
                temData.state = ((FileState)item.State).ToString();
                fileDataList.Add(temData);
            }
            return Json(new
            {
                code = 0,
                msg = "查询成功",
                data = fileDataList
            });
        }


        //教职工信息
        public object QueryAllTeacher(int page,int limit)
        {
            var allTeacher = zhenjiaoservice.QueryAllTeacher();
            var showAllTeacher = allTeacher.Skip((page - 1) * limit).Take(limit);
            return Json(new
            {
                code = 0,
                msg = "教职工信息",
                count = allTeacher.Count,
                data = showAllTeacher,
            });
        }

        public object QueryBySection(string section)
        {
            var teacherFilterBySection = zhenjiaoservice.QueryTeacherBySection(section);
            if (teacherFilterBySection == null)
            {
                return Json(new
                {
                    code = 270,
                    msg="数据不存在"
                });
            }
            return Json(new
            {
                code = 200,
                msg="部门筛选信息",
                data = teacherFilterBySection
            });
        }

        public object QueryTeacher(string type,string key)
        {
            List<TeacherDetail> teacherList = new List<TeacherDetail>();        
            if (type == "教师工号")
            {
                var teacher = zhenjiaoservice.QueryTeacherById(key);
                if (teacher.teacherId == null)
                {
                    return Json(new
                    {
                        code = 270,
                        msg = "查询失败"
                    });
                }
                else
                    teacherList.Add(teacher);
                    return Json(new
                    {
                        code = 200,
                        msg = "查询教职工信息成功",
                        data = teacherList
                    });
            }
            else
            {
                var teacher = zhenjiaoservice.QueryTeacherByName(key);
                if (teacher.Count == 0)
                {
                    return Json(new
                    {
                        code = 270,
                        msg = "查询失败"
                    });
                }
                else
                    return Json(new
                    {
                        code = 200,
                        msg = "查询教职工信息成功",
                        data = teacher
                    });
            }
        }
    }
}
