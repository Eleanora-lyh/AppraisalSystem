using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;

namespace VirusPro.Model
{
    public enum VirusTypeEnum
    {
        RNA, DNA
    }
    public class Virus : TopBasePoco
    {
        [Display(Name = "病毒名称")]
        [Required(ErrorMessage = "病毒名称是必填项")]
        public string VirusName { get; set; }

        [Display(Name = "病毒代码")]
        [Required(ErrorMessage = "病毒代码是必填项")]
        [StringLength(10, ErrorMessage = "病毒代码最多10个字符")]
        public string VirusCode { get; set; }

        [Display(Name = "病毒描述")]
        public string VirusRemark { get; set; }

        [Display(Name = "病毒种类")]
        [Required(ErrorMessage = "病毒种类是必填项")]
        public VirusTypeEnum VirusType { get; set; }

    }
}
