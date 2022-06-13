using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectAdapter
{
    public class CityFromExternalSystem
    { 
        public string Name { get; set; }
        public string NickName { get; set; }
        public int Inhabitants { get; set; }

        public CityFromExternalSystem(string name, string nickName, int inhabitants)
        {
            Name = name;
            NickName = nickName;
            Inhabitants = inhabitants;
        }
    }

    public class ExternalSystem
    {
        public CityFromExternalSystem GetCity()
        {
            return new CityFromExternalSystem("Antwerp", "'t Stad", 500000);
        }
    }

    public class City
    {
        public City(string fullName, long inhabitants)
        {
            FullName = fullName;
            Inhabitants = inhabitants;
        }

        public string FullName { get; set; }
        public long Inhabitants { get; set; }
    }

    public interface ICityAdapter
    {
        City GetCity();
    }

    public class CityAdapter : ICityAdapter
    {
        public ExternalSystem ExternalSystem { get; set; } = new();

        public City GetCity()
        {
            var cityFromExternaSystem = ExternalSystem.GetCity();

            return new City($"{cityFromExternaSystem.Name} - {cityFromExternaSystem.NickName}", cityFromExternaSystem.Inhabitants);
        }
    }
}
