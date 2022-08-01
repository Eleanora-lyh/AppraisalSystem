using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using VirusPro.Model;


namespace VirusPro.ViewModel.BasicData.HospitalVMs
{
    public partial class HospitalListVM : BasePagedListVM<Hospital_View, HospitalSearcher>
    {

        protected override IEnumerable<IGridColumn<Hospital_View>> InitGridHeader()
        {
            return new List<GridColumn<Hospital_View>>{
                this.MakeGridHeader(x => x.HostpitalName),
                this.MakeGridHeader(x => x.HostpitalLevel),
                this.MakeGridHeader(x => x.CityName_view),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<Hospital_View> GetSearchQuery()
        {
            var query = DC.Set<Hospital>()
                .CheckContain(Searcher.HostpitalName, x=>x.HostpitalName)
                .CheckEqual(Searcher.HostpitalLevel, x=>x.HostpitalLevel)
                .CheckEqual(Searcher.LocationId, x=>x.LocationId)
                .Select(x => new Hospital_View
                {
				    ID = x.ID,
                    HostpitalName = x.HostpitalName,
                    HostpitalLevel = x.HostpitalLevel,
                    CityName_view = x.Location.CityName,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class Hospital_View : Hospital{
        [Display(Name = "城市名称")]
        public String CityName_view { get; set; }

    }
}
