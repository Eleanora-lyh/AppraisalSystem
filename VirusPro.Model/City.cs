using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;

namespace VirusPro.Model
{
    /*
     * 继承自TreePoco后会使City变为树形结构
     */
    public class City : TreePoco<City>
    {
        [Display(Name = "城市名称")]
        [Required(ErrorMessage = "城市名称不能为空")]
        public string CityName { get; set; }


    }
}
