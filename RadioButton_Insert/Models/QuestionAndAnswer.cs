using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RadioButton_Insert.Models
{
    public class QuestionAndAnswer
    {
        public int tblQuestionID { get; set; }
        public string Question { get; set; }
        public int tblAnswersID { get; set; }
        public string Answer { get; set; }
        public string Finalresult { get; set; }
        public int tblResultID { get; set; }
        public Nullable<int> SelectedAnswer { get; set; }
        public List<tblQuestion> lstquestion { get; set; }
        public List<tblAnswer> lstanswer { get; set; }
        public List<tblResult> lstresult { get; set; }
    }
}