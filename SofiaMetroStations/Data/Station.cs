using System;
using System.Collections.Generic;

namespace SofiaMetroStations.Data
{
    //{
    //    "id": 5,
    //    "route_id": 1,
    //    "code": 2985,
    //    "point_id": 105,
    //    "name": "Лъвов мост",
    //    "latitude": 42.705369,
    //    "longitude": 23.323891
    //}
public class Station
    {
        public int Id { get; set; }
        public int Route_Id { get; set; }
        public int Code { get; set; }
        public string Point_Id { get; set; }
        public string Name { get; set; }
    }
}

