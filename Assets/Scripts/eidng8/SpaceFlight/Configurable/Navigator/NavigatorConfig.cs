// ---------------------------------------------------------------------------
// <copyright file="NavigatorConfig.cs" company="eidng8">
//      GPLv3
// </copyright>
// <summary>
// 
// </summary>
// ---------------------------------------------------------------------------

using System.Collections.Generic;


namespace eidng8.SpaceFlight.Configurable.Navigator
{
    public class NavigatorConfig : Configurable
    {
        /// <inheritdoc />
        public override Dictionary<string, float> Dict() =>
            new Dictionary<string, float>();

        /// <inheritdoc />
        public override string[] Validate() => new string[0];
    }
}
