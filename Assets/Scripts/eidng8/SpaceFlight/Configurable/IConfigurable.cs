// ---------------------------------------------------------------------------
// <copyright file="IConfigurable.cs" company="eidng8">
//      GPLv3
// </copyright>
// <summary>
// 
// </summary>
// ---------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;


namespace eidng8.SpaceFlight.Configurable
{
    public interface IConfigurable
    {
        /// <summary>
        /// Convert the instance's attribute data to dictionary.
        /// </summary>
        /// <returns></returns>
        Dictionary<string, float> Dict();
    }


    public static class ConfigurableExtension
    {
        /// <summary>
        /// Aggregates all attributes from <c>items</c>.
        /// </summary>
        /// <param name="cfg"></param>
        /// <param name="items"></param>
        /// <returns>A dictionary containing all aggregated attributes</returns>
        public static Dictionary<string, float> Aggregate(
            this IConfigurable cfg,
            IEnumerable<Dictionary<string, float>> items
        ) {
            Dictionary<string, float> dict = cfg.Dict();
            foreach (Dictionary<string, float> item in items) {
                item.ToList()
                    .ForEach(
                        attr => dict[attr.Key] =
                            dict.TryGetValue(attr.Key, out float v)
                                ? v + attr.Value
                                : attr.Value
                    );
            }

            return dict;
        }
    }
}
