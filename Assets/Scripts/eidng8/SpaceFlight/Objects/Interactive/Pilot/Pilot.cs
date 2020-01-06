// ---------------------------------------------------------------------------
// <copyright file="Pilot.cs" company="eidng8">
//      GPLv3
// </copyright>
// <summary>
// 
// </summary>
// ---------------------------------------------------------------------------

using eidng8.SpaceFlight.Events;
using eidng8.SpaceFlight.Managers;
using eidng8.SpaceFlight.Objects.Dynamic;
using eidng8.SpaceFlight.Objects.Interactive.Automated;
using UnityEngine;


namespace eidng8.SpaceFlight.Objects.Interactive.Pilot
{
    public abstract class Pilot<TConfig, TMotor> : IPilot
        where TConfig : IPilotConfig
        where TMotor : IMotorBase
    {
        protected TConfig config;

        protected TMotor motor;

        protected IFlightController targetControl;
        private bool _listeningEvents;
        private Transform _target;

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
                    this.targetControl =
                        this._target.GetComponent<IFlightController>();
                }
            }
        }

        public virtual void Awake() {
            if (!this._listeningEvents) {
                this.RegisterEvents();
                this._listeningEvents = true;
            }
        }

        /// <inheritdoc />
        public void Configure(IPilotConfig cfg) {
            this.config = (TConfig)cfg;
        }

        /// <inheritdoc />
        public abstract void FixedUpdate();

        public void TakeControlOfMotor(IMotorBase mtr) =>
            this.motor = (TMotor)mtr;

        /// <summary>
        /// The objected selected event handler. Sets <c>Target</c> to the
        /// selected object.
        /// </summary>
        protected virtual void OnSelectTarget(UserEventArgs args) {
            if (args?.hasTarget == true) {
                // ReSharper disable once PossibleNullReferenceException
                this.Target = args.target.transform;
            }
        }

        /// <summary>Register listeners to game events.</summary>
        protected virtual void RegisterEvents() {
            EventManager.M.OnUserEvent(
                UserEvents.Select,
                this.OnSelectTarget
            );
        }
    }
}
