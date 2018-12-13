using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Virsagi.Web.ViewModels
{
    public class AgentViewModel
    {
        public int AgentID { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string RLName { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string RLNo { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string RLAddress { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string ContactNumber { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Email { get; set; }
    }
}