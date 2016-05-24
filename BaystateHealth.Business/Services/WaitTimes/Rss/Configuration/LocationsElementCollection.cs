using System.Collections.Generic;
using System.Configuration;

namespace BaystateHealth.Business.Services.WaitTimes.Rss.Configuration
{
    public class LocationsElementCollection : ConfigurationElementCollection, IEnumerable<LocationElement>
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new LocationElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((LocationElement)element).Key;
        }

        public new IEnumerator<LocationElement> GetEnumerator()
        {
            int count = base.Count;
            for (int i = 0; i < count; i++)
            {
                yield return base.BaseGet(i) as LocationElement;
            }
        }
    }
}
