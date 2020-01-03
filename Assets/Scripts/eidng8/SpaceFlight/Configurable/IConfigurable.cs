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
        string InfoBoxContent { get; }

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
