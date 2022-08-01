﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using VirusPro.Model;


namespace VirusPro.ViewModel.BasicData.ControlCenterVMs
{
    public partial class ControlCenterSearcher : BaseSearcher
    {
        [Display(Name = "中心名称")]
        public String CenterName { get; set; }
        [Display(Name = "中心地点")]
        public Guid? LocationId { get; set; }

        protected override void InitVM()
        {
        }

    }
}
