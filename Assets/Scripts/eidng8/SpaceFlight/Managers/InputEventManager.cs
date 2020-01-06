// ---------------------------------------------------------------------------
// <copyright file="InputEventManager.cs" company="eidng8">
//      GPLv3
// </copyright>
// <summary>
// 
// </summary>
// ---------------------------------------------------------------------------

using System.IO;
using Luminosity.IO;
using UnityEngine;
using UO = UnityEngine.Object;


namespace eidng8.SpaceFlight.Managers
{
    /// <summary>
    /// A singleton manager that deals with user input. The manager
    /// produces raw input events which are consumed by the
    /// <see cref="EventManager" />. Event binding is perform in the
    /// inspector UI.
    /// </summary>
    /// <remarks>This manager must be added to scene and enabled.</remarks>
    public class InputEventManager : Luminosity.IO.Events.InputEventManager
    {
        private static InputEventManager _instance;

        public static InputEventManager M => InputEventManager._instance;

        protected override void Awake() {
            if (!InputEventManager._instance) {
                base.Awake();
                InputEventManager._instance = this;
                UO.DontDestroyOnLoad(this.gameObject);
                this.Init();
            } else {
                UO.Destroy(this.gameObject);
            }
        }

        private void Init() {
            Debug.Log("InputEventManager.Init");
            string file = GameManager.DataFilePath("Key Bindings/input_4x");
            var res = Resources.Load<TextAsset>(file);
            InputManager.Load(new InputLoaderXML(new StringReader(res.text)));
        }
    }
}
