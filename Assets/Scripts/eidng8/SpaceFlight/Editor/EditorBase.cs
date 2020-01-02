// ---------------------------------------------------------------------------
// <copyright file="EditorBase.cs" company="eidng8">
//      GPLv3
// </copyright>
// <summary>
// 
// </summary>
// ---------------------------------------------------------------------------

using UnityEngine;
using UnityEngine.UIElements;


namespace eidng8.SpaceFlight.Editor
{
    public abstract class EditorBase : UnityEditor.Editor
    {
        private GUIStyle _labelStyle;
        private GUIStyle _warning;

        protected GUIStyle LabelStyle =>
            this._labelStyle
            ?? (this._labelStyle = new GUIStyle(GUI.skin.label)
                {alignment = TextAnchor.MiddleRight});

        protected GUIStyle Warning =>
            this._warning
            ?? (this._warning = new GUIStyle(GUI.skin.label)
                {normal = {textColor = Color.red}});
    }
}
