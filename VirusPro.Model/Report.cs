using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;

namespace VirusPro.Model
{
    public class Report : BasePoco
    {
        [Required(ErrorMessage = "体温是必填项")]
        [Display(Name = "体温")]
        [Range(30,50,ErrorMessage = "体温必须在30到50度之间")]
        public float? Temparature { get; set; }

        [Display(Name = "备注")]
        public string Remark { get; set; }
        /*
         * Report表中的PatientID参考自Patient表中的ID（一个patient有多个report）
         */
        public Patient Patient { get; set; }

        [Required(ErrorMessage = "患者是必填项")]
        [Display(Name = "患者")]
        public Guid? PatientID { get; set; }
    }
}
