using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCLogin.Models
{
    public class Files
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int No { get; set; }
        public string Reference { get; set; }
        public string Attorney { get; set; }

        [Display(Name = "Claimant Name")]
        public string ClaimentName { get; set; }
        [Display(Name = "Claimant Surname")]
        public string ClaimentSurname { get; set; }
        [Display(Name = "Incident Type")]
        public string ClaimentID { get; set; }
    }
}