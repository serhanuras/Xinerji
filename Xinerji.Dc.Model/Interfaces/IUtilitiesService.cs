using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xinerji.Dc.Model.Core;

namespace Xinerji.Dc.Model.Interfaces
{
    public interface IUtilitiesService : IDisposable
    {

        List<City> GetCityList();

        List<County> GetCountyList();

        List<County> GetCityCountyList(int CityId);

        City GetCity(int CityId);

        County GetCounty(int CountyId);

    }
}
