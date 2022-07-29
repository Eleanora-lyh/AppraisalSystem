using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirusPro.Model
{
    public enum HospitalLevelEnum
    {
        Class1,
        Class2,
        Class3
    }
    class Hospital
    {
        [Display(Name = "医院名称")]
        [Required(ErrorMessage = "医院名称是必填项")]
        public string HostpitalName { get; set; }
        [Display(Name = "医院级别")]
        [Required(ErrorMessage = "医院级别是必填项")]
        public HospitalLevelEnum HostpitalLevel { get; set; }
        /*
         * Hostpital表中的属性Location为外键，参考自City表中CityName(一个city有多个hospital)
         */
        public City Location { get; set; }
        public Guid LocationId { get; set; }

        
    }
}

