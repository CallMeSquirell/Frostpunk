using UnityEngine;

namespace Project.Scripts.Core.Systems
{
    public struct MergeField
    {
        public Grid Grid { get; }
        
        public MergeField(Grid grid)
        {
            Grid = grid;
        }
    }

    public struct PickedItem
    {
    }

    public struct MergeItem
    {
        public Vector2Int Position { get; }
        public Transform Transform { get; }
    }
}