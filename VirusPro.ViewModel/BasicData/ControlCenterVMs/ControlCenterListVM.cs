using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using VirusPro.Model;


namespace VirusPro.ViewModel.BasicData.ControlCenterVMs
{
    public partial class ControlCenterListVM : BasePagedListVM<ControlCenter_View, ControlCenterSearcher>
    {

        protected override IEnumerable<IGridColumn<ControlCenter_View>> InitGridHeader()
        {
            return new List<GridColumn<ControlCenter_View>>{
                this.MakeGridHeader(x => x.CenterName),
                this.MakeGridHeader(x => x.CityName_view),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<ControlCenter_View> GetSearchQuery()
        {
            var query = DC.Set<ControlCenter>()
                .CheckContain(Searcher.CenterName, x=>x.CenterName)
                .CheckEqual(Searcher.LocationId, x=>x.LocationId)
                .Select(x => new ControlCenter_View
                {
				    ID = x.ID,
                    CenterName = x.CenterName,
                    CityName_view = x.Location.CityName,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class ControlCenter_View : ControlCenter{
        [Display(Name = "城市名称")]
        public String CityName_view { get; set; }

    }
}
