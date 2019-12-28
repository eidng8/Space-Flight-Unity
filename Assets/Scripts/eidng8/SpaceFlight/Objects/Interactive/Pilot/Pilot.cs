// ---------------------------------------------------------------------------
// <copyright file="Pilot.cs" company="eidng8">
//      GPLv3
// </copyright>
// <summary>
// 
// </summary>
// ---------------------------------------------------------------------------

using eidng8.SpaceFlight.Events;
using eidng8.SpaceFlight.Objects.Dynamic;
using eidng8.SpaceFlight.Objects.Interactive.Automated;
using UnityEngine;


namespace eidng8.SpaceFlight.Objects.Interactive.Pilot
{
    public abstract class Pilot<TConfig, TMotor> : IPilot
        where TConfig : IPilotConfig
        where TMotor : IMotorBase
    {
        private bool _listeningEvents;
        private Transform _target;

        protected IFlightController TargetControl;

        protected TConfig Config;

        protected TMotor Motor;

        /// <inheritdoc />
        public bool HasTarget { get; private set; }

        /// <inheritdoc />
        public Transform Target {
            get => this._target;
            set {
                this._target = value;
                bool hasTarget = null != value;
                this.HasTarget = hasTarget;
                if (hasTarget) {
                    this.TargetControl =
                        this._target.GetComponent<IFlightController>();
                }
            }
        }

        public virtual void Awake()
        {
            if (!this._listeningEvents) {
                this.RegisterEvents();
                this._listeningEvents = true;
            }
        }

        /// <inheritdoc />
        public void Configure(IPilotConfig config)
        {
            this.Config = (TConfig)config;
        }

        /// <inheritdoc />
        public abstract void FixedUpdate();

        public void TakeControlOfMotor(IMotorBase motor) =>
            this.Motor = (TMotor)motor;

        /// <summary>
        /// The objected selected event handler. Sets <c>Target</c> to the
        /// selected object.
        /// </summary>
        protected virtual void OnSelectTarget(ExtendedEventArgs arg0)
        {
            this.Target = arg0.source.transform;
        }

        /// <summary>Register listeners to game events.</summary>
        protected virtual void RegisterEvents()
        {
            EventManager.Mgr.OnUserEvent(
                UserEvents.Select,
                this.OnSelectTarget
            );
        }
    }
}
