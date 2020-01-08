// ---------------------------------------------------------------------------
// <copyright file="INavigator.cs" company="eidng8">
//      GPLv3
// </copyright>
// <summary>
// 
// </summary>
// ---------------------------------------------------------------------------

using eidng8.SpaceFlight.Configurable.Navigator;
using eidng8.SpaceFlight.Objects;
using UnityEngine;

namespace eidng8.SpaceFlight.Mechanics.Nav
{
    /// <summary>Handles object movement.</summary>
    public interface INavigator
    {
        bool HasTarget { get; }

        Transform Target { get; set; }

        void ClearTarget();

        void Configure(NavigatorConfig config);

        void Man(IMovableObject obj);
    }
}
