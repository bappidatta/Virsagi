using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Virsagi.Web.ViewModels
{
    public class IPAViewModel
    {
        public int IPAID { get; set; }
        public string PassportNo { get; set; }
        public string WorkerName { get; set; }
        public string Employer { get; set; }
        public string WorkPermitNo { get; set; }
        public string ReferenceNo { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime IssuanceDate { get; set; }
    }
}