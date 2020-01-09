using eidng8.SpaceFlight.UI;
using UnityEditor;
using UnityEngine;

namespace eidng8.SpaceFlight.Editor.UI
{
    [CustomEditor(typeof(AnchoredElement))]
    public class AnchoredElementInspector : UnityEditor.Editor
    {
        public override void OnInspectorGUI() {
            base.OnInspectorGUI();
            AnchoredElement ae =
                (AnchoredElement)this.serializedObject.targetObject;
            RectTransform rt = ae.GetComponent<RectTransform>();
            rt.anchoredPosition3D = new Vector3(ae.X, ae.Y);
        }
    }
}
