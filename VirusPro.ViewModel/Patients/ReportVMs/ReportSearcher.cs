using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using VirusPro.Model;


namespace VirusPro.ViewModel.Patients.ReportVMs
{
    public partial class ReportSearcher : BaseSearcher
    {
        [Display(Name = "体温")]
        public Single? Temparature { get; set; }
        public Guid? PatientID { get; set; }

        protected override void InitVM()
        {
        }

    }
}
