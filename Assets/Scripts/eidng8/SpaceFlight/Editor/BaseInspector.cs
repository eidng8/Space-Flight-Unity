// ---------------------------------------------------------------------------
// <copyright file="BaseInspector.cs" company="eidng8">
//      GPLv3
// </copyright>
// <summary>
// 
// </summary>
// ---------------------------------------------------------------------------

using UnityEngine;


namespace eidng8.SpaceFlight.Editor
{
    /// <summary>
    /// Base class of customer editor.
    /// </summary>
    public abstract class BaseInspector : UnityEditor.Editor
    {
        private GUIStyle _labelStyle;
        private GUIStyle _warning;

        protected GUIStyle LabelStyle =>
            this._labelStyle
            ?? (this._labelStyle = new GUIStyle(GUI.skin.label)
                {alignment = TextAnchor.MiddleRight});

        protected GUIStyle Warning =>
            this._warning
            ?? (this._warning = new GUIStyle(GUI.skin.label) {
                alignment = TextAnchor.MiddleCenter,
                normal = {textColor = Color.red},
            });
    }
}
