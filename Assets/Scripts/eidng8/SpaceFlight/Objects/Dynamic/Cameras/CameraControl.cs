using eidng8.SpaceFlight.Objects.Interactive.Automated.Controllers;
using UnityEngine;


namespace eidng8.SpaceFlight.Objects.Dynamic.Cameras
{
    public class CameraControl : MonoBehaviour
    {
        private AccelerationAutoPilot _ctl;

        private void Start()
        {
            this._ctl = this.GetComponent<AccelerationAutoPilot>();
            this._ctl.SetTarget(GameObject.FindWithTag("Player").transform);
        }
    }
}
