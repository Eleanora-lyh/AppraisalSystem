using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;

namespace VirusPro.Model
{
    public enum GenderEnums
    {
        [Display(Name = "男")]
        Male,
        [Display(Name = "女")]
        Female
    }
    public enum PatientStatusEnum
    {
        [Display(Name = "无症状")]
        asymptomatic,
        [Display(Name = "疑似")]
        suspected,
        [Display(Name = "确诊")]
        confirmed,
        [Display(Name = "治愈")]
        cured,
        [Display(Name = "死亡")]
        dead,

    }
    public class Patient : PersistPoco
    {
        /*
         * PersistPoco 中包括了 是否显示isValid 还继承自 BasePoco
         * BasePoco 中包括了 CreateBy CreateTime UpDateBy UpdateTime 还继承自 TopBasePoco
         * TopBasePoco 中包括了 ID Checked BatchError ExcelIndex IsBasePoco  
         */
        [Display(Name = "病人名称")]
        [Required(ErrorMessage = "病人名称不能为空")]
        public string PatientName { get; set; }

        [Display(Name = "病人身份证号")]
        [Required(ErrorMessage = "病人身份证号不能为空")]
        [RegularExpression("[1-9]\\d{5}(18|19|20|(3\\d))\\d{2}((0[1-9])|(1[0-2]))(([0-2][1-9])|10|20|30|31)\\d{3}[0-9Xx]", ErrorMessage= "身份格式不对")]
        public string IdNumber { get; set; }

        [Display(Name = "病人性别")]
        public GenderEnums? Gender { get; set; }

        [Display(Name = "病人状态")]
        public PatientStatusEnum? status { get; set; }

        [Display(Name = "病人出生日期")]
        [Required(ErrorMessage = "病人名称不能为空")]
        public DateTime? Birthday { get; set; }
        /*
         * Patient表中的属性Location为外键，参考自City表中CityName(一个city有多个Patient)
         */
        [Display(Name = "籍贯")]
        public City Location { get; set; }
        [Display(Name = "籍贯")]
        public Guid? LocationId { get; set; }
        /*
         * Patient表中的属性Hospital为外键，参考自Hospital表中HospitalName(一个city有多个Hospital)
         */
        [Display(Name = "所属医院")]
        public Hospital Hospital { get; set; }
        [Display(Name = "所属医院")]
        public Guid? HospitalId { get; set; }

        [NotMapped]
        [Display(Name = "年龄")]
        public int Age { get
            {
                return DateTime.Now.Year - Birthday.Value.Year;
            }
        }
        [Display(Name = "照片")]
        public FileAttachment Photo { get; set; }
        [Display(Name = "照片")]
        public Guid? PhotoId { get; set; }

        [Display(Name = "病毒")]
        //一个病人能感染多个病毒，指向中间表
        public List<PatientVirus> Viruses { get; set; }
    }
}
