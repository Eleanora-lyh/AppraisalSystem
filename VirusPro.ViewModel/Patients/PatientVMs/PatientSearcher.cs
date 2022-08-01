using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using VirusPro.Model;


namespace VirusPro.ViewModel.Patients.PatientVMs
{
    public partial class PatientSearcher : BaseSearcher
    {
        [Display(Name = "病人名称")]
        public String PatientName { get; set; }
        [Display(Name = "病人身份证号")]
        public String IdNumber { get; set; }
        [Display(Name = "病人性别")]
        public GenderEnums? Gender { get; set; }
        [Display(Name = "病人状态")]
        public PatientStatusEnum? status { get; set; }
        [Display(Name = "病毒")]
        public List<Guid> SelectedVirusesIDs { get; set; }

        protected override void InitVM()
        {
        }

    }
}
