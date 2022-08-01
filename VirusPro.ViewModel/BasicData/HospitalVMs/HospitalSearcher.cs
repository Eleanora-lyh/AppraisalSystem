using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using VirusPro.Model;


namespace VirusPro.ViewModel.BasicData.HospitalVMs
{
    public partial class HospitalSearcher : BaseSearcher
    {
        [Display(Name = "医院名称")]
        public String HostpitalName { get; set; }
        [Display(Name = "医院级别")]
        public HospitalLevelEnum? HostpitalLevel { get; set; }
        [Display(Name = "医院地点")]
        public Guid? LocationId { get; set; }

        protected override void InitVM()
        {
        }

    }
}
