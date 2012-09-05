using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;

namespace Gustaf.Lab1.Web.Models
{
    public class NewPersonModel
    {

        [Required]
        [Display(Name = "FirstName")]
        public String FirstName { get; set; }

        [Required]
        [Display(Name = "LastName")]
        public String LastName { get; set; }

    }
    public class NewPersonResultModel
    {
        [Required]
        [Display(Name = "Message")]
        public String Message { get; set; }

    }

    public class NewGroupModel
    {
        [Required]
        [Display(Name = "Group Name")]
        public Group Group { get; set; }
    }
    public class AddPersonToGroupModel
    {
        [Required]
        [Display(Name = "PersonId")]
        public int PersonId { get; set; }

        [Required]
        [Display(Name = "GroupId")]
        public int GroupId { get; set; }

        [Display(Name = "Message")]
        public string Message { get; set; }
    }
}