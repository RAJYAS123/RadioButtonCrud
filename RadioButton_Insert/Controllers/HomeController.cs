using RadioButton_Insert.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RadioButton_Insert.Controllers
{
    public class HomeController : Controller
    {
      

        DatabaseContext db = new DatabaseContext();
        DatabaseContextt obj = new DatabaseContextt();
        
        public ActionResult Index()
        {


            var data = new QuestionAndAnswer()
            {
                lstquestion =db.tblQuestions.ToList(),
                lstanswer = db.tblAnswers.ToList(),
                lstresult = db.tblResults.ToList()
            };
            return View(data);
        }

        [HttpPost]
        public JsonResult InsertIntoDatabase(List<tblResult> result)
        {

            tblResult obj = new tblResult();
            foreach (var item in result)
            {
                obj.tblQuestionID = item.tblQuestionID;
                obj.SelectedAnswer = item.SelectedAnswer;

                var data = db.tblResults.Where(s => s.tblQuestionID == obj.tblQuestionID).ToList();
                if(data.Count > 0)
                {
                    var test = db.UpdateQuestionAnsAnswer(obj.tblQuestionID,obj.SelectedAnswer).ToString();
                    //tblResult updated = (from c in db.tblResults
                    //                     where c.tblQuestionID == obj.tblQuestionID
                    //                     select c).FirstOrDefault();
                    //updated.SelectedAnswer = item.SelectedAnswer;
                    //db.SaveChanges();
                }
                else
                {
                    var test1 = db.InsertQuestionAnsAnswer(obj.tblQuestionID,obj.SelectedAnswer).ToString();
                    //obj.tblQuestionID = item.tblQuestionID;
                    //obj.SelectedAnswer = item.SelectedAnswer;
                    //db.tblResults.Add(obj);
                    //db.SaveChanges();
                }
                            
            }
            
            return Json(obj, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult GetSingleQuestionAndAnswer()
        {

            var data = db.JoinQuestionAndAnswer().ToList();
            //var query = from c in db.tblResults
            //            join cn in db.tblQuestions on c.tblQuestionID equals cn.tblQuestionID
            //            join ct in db.tblAnswers on c.SelectedAnswer equals ct.tblAnswersID orderby c.tblQuestionID descending
            //            select new {  questionid = c.tblQuestionID, question = cn.Question, answer = ct.Answer };
            
           
            //var result = query.ToList();
             return Json(data, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult GetAnswer()
        {
            //var ans = db.tblResults.Select(x => new
            //{
            //    QuestionID = x.tblQuestionID,
            //    answerID = x.SelectedAnswer

            //}).ToList();
            var ans = db.GetAllQuestionAndAnswer().ToList();
            return Json(ans, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult QuestionPage()
        {
            HobbyModel hobbyModel = new HobbyModel();
            hobbyModel.getHobby = obj.tblhobbies.ToList();
            return View(hobbyModel);
        }

        [HttpPost]
        public JsonResult Save(List<tblhobby> hobbies)
        {
            DatabaseContextt entities = new DatabaseContextt();
            foreach(var item in hobbies)
            {
                tblhobby updatedHobby = entities.tblhobbies.ToList().Find(p => p.hid == item.hid);
                updatedHobby.IsChecked = item.IsChecked;
            }

            entities.SaveChanges();
            return Json(JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveDataInDatabase(tblhobby model)
        {

            tblhobby Stu = new tblhobby();
            Stu.hid = model.hid;
            Stu.hname = model.hname;
            Stu.IsChecked = model.IsChecked;          
            obj.tblhobbies.Add(Stu);
            var i = db.SaveChanges();
            return Json(Stu, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Dashboard()
        {
            return View();
        }

    }
}  