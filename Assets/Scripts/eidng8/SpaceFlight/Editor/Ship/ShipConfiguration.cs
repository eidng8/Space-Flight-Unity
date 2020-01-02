// ---------------------------------------------------------------------------
// <copyright file="ShipConfiguration.cs" company="eidng8">
//      GPLv3
// </copyright>
// <summary>
// 
// </summary>
// ---------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using eidng8.SpaceFlight.Configurable.Ship;
using UnityEditor;
using UnityEngine;


namespace eidng8.SpaceFlight.Editor.Ship
{
    [CustomEditor(typeof(ShipConfig))]
    public class ShipConfiguration : EditorBase
    {
        /// <inheritdoc />
        public override void OnInspectorGUI() {
            base.OnInspectorGUI();
            this.GenerateSummary();
        }

        private void GenerateSummary() {
            EditorGUILayout.LabelField("Summary", EditorStyles.boldLabel);

            ShipConfig cfg = (ShipConfig)this.serializedObject.targetObject;
            cfg.Aggregate()
               .ToList()
               .ForEach(
                   attr => {
                       EditorGUILayout.BeginHorizontal();
                       string label =
                           ObjectNames.NicifyVariableName(attr.Key);
                       EditorGUILayout.LabelField(
                           $"{label}:",
                           this.LabelStyle
                       );
                       EditorGUILayout.LabelField($"{attr.Value}");
                       EditorGUILayout.EndHorizontal();
                   }
               );

            foreach (string error in cfg.Validate()) {
                EditorGUILayout.LabelField(error, this.Warning);
            }
        }
    }
}
