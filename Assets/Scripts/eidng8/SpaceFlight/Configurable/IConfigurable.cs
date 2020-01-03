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
        /// Text description of the configurable. Will be display at the top of
        /// custom inspectors.
        /// </summary>
        string InfoBoxContent { get; }

        /// <summary>
        /// Text description of the configurable suitable for in-game display.
        /// </summary>
        /// <todo>
        /// Currently this is not used. It's supposed to be implemented while
        /// proper localization facility is utilized.
        /// </todo>
        string Description { get; }

        /// <summary>
        /// Convert the instance's attribute data to dictionary.
        /// </summary>
        /// <returns></returns>
        Dictionary<string, float> Dict();

        Dictionary<string, float> Aggregate();

        /// <summary>
        /// Validate the configuration and returns all errors found.
        /// </summary>
        /// <returns></returns>
        string[] Validate();
    }
}
