// ---------------------------------------------------------------------------
// <copyright file="ShipFactory.cs" company="eidng8">
//      GPLv3
// </copyright>
// <summary>
// 
// </summary>
// ---------------------------------------------------------------------------

using eidng8.SpaceFlight.Configurable;


namespace eidng8.SpaceFlight.Factories
{
    public sealed class ShipFactory
    {
        public static readonly ShipFactory Builder = new ShipFactory();

        private ShipFactory() { }

        public void Make(ShipConfig config) { }
    }
}
