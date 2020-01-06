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
        void Configure(NavigatorConfig config);

        void FixedUpdate();

        /// <summary>
        /// Assigns the given <see cref="obj" /> and rigid <see cref="body" />
        /// to the instance. Once assigned, the instance will directly
        /// manipulate the <see cref="body" />. e.g. applying forces to the
        /// rigid body. The <see cref="obj" /> is necessary to obtain crucial
        /// information that is not on the rigid body.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="body"></param>
        void Man(IMovableObject obj, Rigidbody body);
    }
}
