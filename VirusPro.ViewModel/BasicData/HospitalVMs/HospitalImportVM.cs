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
    public partial class HospitalTemplateVM : BaseTemplateVM
    {
        [Display(Name = "医院名称")]
        public ExcelPropety HostpitalName_Excel = ExcelPropety.CreateProperty<Hospital>(x => x.HostpitalName);
        [Display(Name = "医院级别")]
        public ExcelPropety HostpitalLevel_Excel = ExcelPropety.CreateProperty<Hospital>(x => x.HostpitalLevel);
        [Display(Name = "医院地点")]
        public ExcelPropety Location_Excel = ExcelPropety.CreateProperty<Hospital>(x => x.LocationId);

	    protected override void InitVM()
        {
            Location_Excel.DataType = ColumnDataType.ComboBox;
            Location_Excel.ListItems = DC.Set<City>().GetSelectListItems(Wtm, y => y.CityName);
        }

    }

    public class HospitalImportVM : BaseImportVM<HospitalTemplateVM, Hospital>
    {

    }

}
