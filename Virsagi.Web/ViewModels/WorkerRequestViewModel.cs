using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Virsagi.Web.ViewModels
{
    public class WorkerRequestViewModel
    {
        public int WorkerRequestID { get; set; }

        public int RequestType { get; set; }
        public string RequestTypeString { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string ContactPerson { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string ContactNumber { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string CompanyUENNumber { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string CompanyName { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Email { get; set; }

        public string Details { get; set; }
        public string SpecialRequest { get; set; }

        [DisplayFormat(DataFormatString = "{0 : dd/MM/yyyy}")]
        public DateTime CreatedDate { get; set; }
    }
}