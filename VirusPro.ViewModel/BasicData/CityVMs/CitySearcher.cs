using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using VirusPro.Model;


namespace VirusPro.ViewModel.BasicData.CityVMs
{
    public partial class CitySearcher : BaseSearcher
    {
        [Display(Name = "城市名称")]
        public String CityName { get; set; }
        [Display(Name = "_Admin.Parent")]
        public Guid? ParentId { get; set; }

        protected override void InitVM()
        {
        }

    }
}
