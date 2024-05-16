using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IAO.Models.ApplicantUser
{
    public class SubjectAndMarks
    {
        public SubjectAndMarks(string subj, int mark) { 
            Subject = subj;
            Mark = mark;
        }
        public string Subject { get; set; }
        public int Mark { get; set; }
    }
}