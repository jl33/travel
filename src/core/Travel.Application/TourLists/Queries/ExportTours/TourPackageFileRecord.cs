using System;
using System.Collections.Generic;
using System.Text;
using Travel.Application.Common.Mappings;

namespace Travel.Application.TourLists.Queries.ExportTours
{
    public class TourPackageRecord:IMapFrom<TourPackage>
    {
        public string Name { get; set; }
        public string MapLocation { get; set; }
    }
}
