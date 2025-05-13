using System.Numerics;

namespace NexusForever.Game.Abstract.Entity.Movement
{
    public class Position
    {
        public Vector3 Vector { get; protected set; }

        public Position()
        {
        }

        public Position(Vector3 vector)
        {
            Vector = vector;
        }
    }
}
