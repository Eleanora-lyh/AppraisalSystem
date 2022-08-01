using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using VirusPro.Model;


namespace VirusPro.ViewModel.Patients.ReportVMs
{
    public partial class ReportListVM : BasePagedListVM<Report_View, ReportSearcher>
    {

        protected override IEnumerable<IGridColumn<Report_View>> InitGridHeader()
        {
            return new List<GridColumn<Report_View>>{
                this.MakeGridHeader(x => x.Temparature),
                this.MakeGridHeader(x => x.Remark),
                this.MakeGridHeader(x => x.PatientName_view),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<Report_View> GetSearchQuery()
        {
            var query = DC.Set<Report>()
                .CheckEqual(Searcher.Temparature, x=>x.Temparature)
                .CheckEqual(Searcher.PatientID, x=>x.PatientID)
                .Select(x => new Report_View
                {
				    ID = x.ID,
                    Temparature = x.Temparature,
                    Remark = x.Remark,
                    PatientName_view = x.Patient.PatientName,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class Report_View : Report{
        [Display(Name = "病人名称")]
        public String PatientName_view { get; set; }

    }
}
