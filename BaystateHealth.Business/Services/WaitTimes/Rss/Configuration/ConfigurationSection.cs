using System.Configuration;

namespace BaystateHealth.Business.Services.WaitTimes.Rss.Configuration
{
    public class ConfigurationSection : System.Configuration.ConfigurationSection
    {
        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns></returns>
        public static ConfigurationSection Create()
        {
            return ConfigurationManager.GetSection("baystatehealth.business.services.waittimes.rss") as ConfigurationSection;
        }

        /// <summary>
        /// Gets the available markets.
        /// </summary>
        /// <value>
        /// The available markets.
        /// </value>
        [ConfigurationProperty("locations", IsDefaultCollection = true)]
        [ConfigurationCollection(typeof(LocationsElementCollection), AddItemName = "location", ClearItemsName = "clear", RemoveItemName = "remove")]
        public LocationsElementCollection Locations
        {
            get
            {
                return (LocationsElementCollection)base["locations"];
            }
        }
    }
}
