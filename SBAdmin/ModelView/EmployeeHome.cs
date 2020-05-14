using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBAdmin.ModelView
{
    public class EmployeeHomeModelView
    {
        public string EmployeeName { get; set; }

        public int InboxCount { get; set; }

        public string ProfilePicture { get; set; }

        public List<UserMessages> Messages { get; set; } = new List<UserMessages>();
        
    }
    public class UserMessages
    {
        public string SenderProfile { get; set; }

        public string SenderName { get; set; }

        public string MessageBody { get; set; }
    }
}