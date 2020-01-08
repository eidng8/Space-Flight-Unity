// ---------------------------------------------------------------------------
// <copyright file="SystemEvents.cs" company="eidng8">
//      GPLv3
// </copyright>
// <summary>
// 
// </summary>
// ---------------------------------------------------------------------------

namespace eidng8.SpaceFlight.Events
{
    public enum SystemEvents
    {
        /// <summary>
        ///     The current scene is about to change. This is triggered before
        ///     the
        ///     scene were changed.
        /// </summary>
        SceneWillChange,

        /// <summary>
        ///     The current scene has changed. This is triggered after the
        ///     scene
        ///     has been loaded.
        /// </summary>
        SceneChanged
    }
}
