// ---------------------------------------------------------------------------
// <copyright file="ConfigurationInspector.cs" company="eidng8">
//      GPLv3
// </copyright>
// <summary>
// 
// </summary>
// ---------------------------------------------------------------------------

using eidng8.SpaceFlight.Configurable;
using UnityEditor;


namespace eidng8.SpaceFlight.Editor
{
    /// <summary>
    /// Common elements of all <see cref="IConfigurable"/> objects.
    /// </summary>
    [CustomEditor(typeof(Configurable.Configurable), true)]
    public class ConfigurationInspector : BaseInspector
    {
        /// <inheritdoc />
        public override void OnInspectorGUI() {
            if (this.serializedObject.targetObject is IConfigurable cfg) {
                EditorGUILayout.HelpBox(cfg.InfoBoxContent, MessageType.Info);
                this.ListErrors(cfg);
            }

            base.OnInspectorGUI();
        }

        protected virtual void ListErrors(IConfigurable cfg) {
            string[] errors = cfg.Validate();
            if (0 == errors.Length) {
                return;
            }

            EditorGUILayout.HelpBox(
                string.Join("\n\n", errors),
                MessageType.Error
            );
        }
    }
}
