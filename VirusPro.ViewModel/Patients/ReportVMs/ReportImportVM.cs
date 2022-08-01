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
    public partial class ReportTemplateVM : BaseTemplateVM
    {
        [Display(Name = "体温")]
        public ExcelPropety Temparature_Excel = ExcelPropety.CreateProperty<Report>(x => x.Temparature);
        [Display(Name = "备注")]
        public ExcelPropety Remark_Excel = ExcelPropety.CreateProperty<Report>(x => x.Remark);
        public ExcelPropety Patient_Excel = ExcelPropety.CreateProperty<Report>(x => x.PatientID);

	    protected override void InitVM()
        {
            Patient_Excel.DataType = ColumnDataType.ComboBox;
            Patient_Excel.ListItems = DC.Set<Patient>().GetSelectListItems(Wtm, y => y.PatientName);
        }

    }

    public class ReportImportVM : BaseImportVM<ReportTemplateVM, Report>
    {

    }

}
