// ---------------------------------------------------------------------------
// <copyright file="ShipFactory.cs" company="eidng8">
//      GPLv3
// </copyright>
// <summary>
// 
// </summary>
// ---------------------------------------------------------------------------

using eidng8.SpaceFlight.Configurable.Ship;


namespace eidng8.SpaceFlight.Factories.Ship
{
    public sealed class ShipFactory
    {
        public static readonly ShipFactory Fab = new ShipFactory();

        private ShipFactory() { }

        public void Make(ShipConfig config) { }
    }
}
