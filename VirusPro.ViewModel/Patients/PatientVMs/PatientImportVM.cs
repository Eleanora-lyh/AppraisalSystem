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
    public partial class PatientTemplateVM : BaseTemplateVM
    {
        [Display(Name = "病人名称")]
        public ExcelPropety PatientName_Excel = ExcelPropety.CreateProperty<Patient>(x => x.PatientName);
        [Display(Name = "病人身份证号")]
        public ExcelPropety IdNumber_Excel = ExcelPropety.CreateProperty<Patient>(x => x.IdNumber);
        [Display(Name = "病人性别")]
        public ExcelPropety Gender_Excel = ExcelPropety.CreateProperty<Patient>(x => x.Gender);
        [Display(Name = "病人状态")]
        public ExcelPropety status_Excel = ExcelPropety.CreateProperty<Patient>(x => x.status);
        [Display(Name = "病人出生日期")]
        public ExcelPropety Birthday_Excel = ExcelPropety.CreateProperty<Patient>(x => x.Birthday);
        [Display(Name = "籍贯")]
        public ExcelPropety Location_Excel = ExcelPropety.CreateProperty<Patient>(x => x.LocationId);
        [Display(Name = "所属医院")]
        public ExcelPropety Hospital_Excel = ExcelPropety.CreateProperty<Patient>(x => x.HospitalId);

	    protected override void InitVM()
        {
            Location_Excel.DataType = ColumnDataType.ComboBox;
            Location_Excel.ListItems = DC.Set<City>().GetSelectListItems(Wtm, y => y.CityName);
            Hospital_Excel.DataType = ColumnDataType.ComboBox;
            Hospital_Excel.ListItems = DC.Set<Hospital>().GetSelectListItems(Wtm, y => y.HostpitalName);
        }

    }

    public class PatientImportVM : BaseImportVM<PatientTemplateVM, Patient>
    {

    }

}
