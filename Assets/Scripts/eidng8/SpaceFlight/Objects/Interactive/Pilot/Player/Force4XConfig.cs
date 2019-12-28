// ---------------------------------------------------------------------------
// <copyright file="Force4xConfig.cs" company="eidng8">
//      GPLv3
// </copyright>
// <summary>
// 
// </summary>
// ---------------------------------------------------------------------------

using System;
using UnityEngine;


namespace eidng8.SpaceFlight.Objects.Interactive.Pilot.Player
{
    [Serializable]
    public struct Keys
    {
        public KeyCode accelerate;
        public KeyCode decelerate;
        public KeyCode pitchUp;
        public KeyCode pitchDown;
        public KeyCode yawC;
        public KeyCode yawCc;
        public KeyCode rollC;
        public KeyCode rollCc;
        public KeyCode panUp;
        public KeyCode panDown;
        public KeyCode panLeft;
        public KeyCode panRight;
    }


    [Serializable]
    public struct Force4XConfig : IPilotConfig
    {
        public Keys keys;

        public float incrementStep;

        public float sensitivity;

        public void AssignDefaultKeys()
        {
            this.keys = new Keys {
                accelerate = KeyCode.A,
                decelerate = KeyCode.G,
                pitchUp = KeyCode.E,
                pitchDown = KeyCode.D,
                yawC = KeyCode.F,
                yawCc = KeyCode.S,
                rollC = KeyCode.R,
                rollCc = KeyCode.W,
                panUp = KeyCode.UpArrow,
                panDown = KeyCode.DownArrow,
                panLeft = KeyCode.LeftArrow,
                panRight = KeyCode.RightArrow
            };
        }
    }
}
