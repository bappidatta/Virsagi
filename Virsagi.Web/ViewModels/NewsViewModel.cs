using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Virsagi.Web.ViewModels
{
    public class NewsViewModel
    {
        public int NewsID { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string NewsHeadline1 { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string NewsDetails1 { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string NewsHeadline2 { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string NewsDetails2 { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string NewsHeadline3 { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string NewsDetails3 { get; set; }

        public DateTime LastUpdatedBy { get; set; }
    }
}