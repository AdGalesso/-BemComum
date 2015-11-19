using br.com.bemcomum.iof.Map;
using EZServiceLocation;

namespace br.com.bemcomum.iof
{
    public static class Bootstrap
    {
        public static void Go()
        {
            ServiceLocator.Current.LoadServiceMap<UserMap>();
            ServiceLocator.Current.LoadServiceMap<AddressMap>();
            ServiceLocator.Current.LoadServiceMap<CategoryMap>();
            ServiceLocator.Current.LoadServiceMap<InstitutionMap>();
            ServiceLocator.Current.LoadServiceMap<DashboardMap>();
        }
    }
}
