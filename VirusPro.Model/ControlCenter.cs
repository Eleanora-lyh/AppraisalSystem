using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;

namespace VirusPro.Model
{
    public class ControlCenter : TopBasePoco
    {
        [Display(Name = "中心名称")]
        [Required(ErrorMessage = "中心名称不能为空")]
        public string CenterName { get; set; }

        /*
         * ControlCenter表中的属性Location为外键，参考自City表中CityName(一个city有多个hospital)
         */
        [Display(Name = "中心地点")]
        public City Location { get; set; }
        [Display(Name = "中心地点")]
        public Guid? LocationId { get; set; }
    }
}
