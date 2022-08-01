using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using VirusPro.Model;


namespace VirusPro.ViewModel.BasicData.CityVMs
{
    public partial class CityListVM : BasePagedListVM<City_View, CitySearcher>
    {

        protected override IEnumerable<IGridColumn<City_View>> InitGridHeader()
        {
            return new List<GridColumn<City_View>>{
                this.MakeGridHeader(x => x.CityName),
                this.MakeGridHeader(x => x.CityName_view),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<City_View> GetSearchQuery()
        {
            var query = DC.Set<City>()
                .CheckContain(Searcher.CityName, x=>x.CityName)
                .CheckEqual(Searcher.ParentId, x=>x.ParentId)
                .Select(x => new City_View
                {
				    ID = x.ID,
                    CityName = x.CityName,
                    CityName_view = x.Parent.CityName,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class City_View : City{
        [Display(Name = "城市名称")]
        public String CityName_view { get; set; }

    }
}
