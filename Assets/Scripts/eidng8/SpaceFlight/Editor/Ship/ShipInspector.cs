// ---------------------------------------------------------------------------
// <copyright file="ShipInspector.cs" company="eidng8">
//      GPLv3
// </copyright>
// <summary>
// 
// </summary>
// ---------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using eidng8.SpaceFlight.Configurable.Ship;
using eidng8.SpaceFlight.Laws;
using UnityEditor;
using UnityEngine;


namespace eidng8.SpaceFlight.Editor.Ship
{
    [CustomEditor(typeof(ShipConfig))]
    public class ShipInspector : ConfigurationInspector
    {
        /// <inheritdoc />
        public override void OnInspectorGUI() {
            base.OnInspectorGUI();
            this.GenerateSummary();
        }

        private void GenerateSummary() {
            EditorGUILayout.Separator();
            EditorGUILayout.LabelField("Summary", EditorStyles.boldLabel);
            ShipConfig cfg = (ShipConfig)this.serializedObject.targetObject;
            Dictionary<string, float> dict = cfg.Aggregate();
            this.ListAttributes(cfg, dict);
            this.EstimateCapacityRecharge(dict);
        }

        private void ListAttributes(
            ShipConfig cfg,
            Dictionary<string, float> attributes
        ) {
            Texture2D info =
                EditorGUIUtility.FindTexture("console.infoicon.sml");
            Texture2D warn =
                EditorGUIUtility.FindTexture("console.warnicon.sml");
            attributes.ToList()
                      .ForEach(
                          attr => {
                              EditorGUILayout.BeginHorizontal();
                              string label =
                                  ObjectNames.NicifyVariableName(attr.Key);
                              EditorGUILayout.LabelField(
                                  $"{label}:",
                                  this.LabelStyle
                              );
                              GUIContent content =
                                  new GUIContent(
                                      $"{attr.Value}",
                                      attr.Value < 0 ? warn : info
                                  ) {
                                      tooltip =
                                          this.ListAttribute(cfg, attr.Key)
                                  };
                              EditorGUILayout.LabelField(content);
                              EditorGUILayout.EndHorizontal();
                          }
                      );
        }

        private string ListAttribute(ShipConfig cfg, string attr) {
            string list = "";
            if ("mass" == attr) {
                list = $"{cfg.name}: {cfg.mass}\n";
            } else if ("size" == attr) {
                list = $"{cfg.name}: {cfg.size}\n";
            }

            foreach (ComponentConfig c in cfg.components) {
                Dictionary<string, float> dict = c.Dict();
                if (dict.TryGetValue(attr, out float v)) {
                    if (!Maths.AboutZero(v)) { list += $"{c.name}: {v}\n"; }
                }
            }

            return list.Length > 0 ? list.Trim() : "Couldn't break down";
        }

        private void EstimateCapacityRecharge(Dictionary<string, float> dict) {
            if (!dict.TryGetValue("capacitor", out float cap) || cap <= 0) {
                return;
            }

            float eps;
            if (!dict.TryGetValue("recharge", out eps)) {
                eps = 0;
            }

            eps = Mathf.Min(dict["power"], eps);
            float sec = cap / eps;
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField(
                "Capacitor recharge in (sec):",
                this.LabelStyle
            );
            EditorGUILayout.LabelField($"{sec}");
            EditorGUILayout.EndHorizontal();
        }
    }
}
