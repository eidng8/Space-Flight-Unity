// ---------------------------------------------------------------------------
// <copyright file="IConfigurable.cs" company="eidng8">
//      GPLv3
// </copyright>
// <summary>
// 
// </summary>
// ---------------------------------------------------------------------------

using System.Collections.Generic;


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
