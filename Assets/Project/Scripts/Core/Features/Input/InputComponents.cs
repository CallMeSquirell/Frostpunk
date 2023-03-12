using UnityEngine;

namespace Project.Scripts.Core.Systems
{
    public struct Selected
    {
        public int TouchId { get; }
        public Vector3 Position { get; }

        public Selected(Vector3 position, int touchId)
        {
            Position = position;
            TouchId = touchId;
        }
    }

    public struct SelectedUp
    {
        public Vector3 Position { get; }

        public SelectedUp(Vector3 position = default)
        {
            Position = position;
        }
    }

    public struct SelectedDown
    {
        public Vector3 Position { get; }

        public SelectedDown(Vector3 position = default)
        {
            Position = position;
        }
    }

    public struct Selectable
    {
        public Plane Plane { get; }
        public Transform Transform { get; }

        public Selectable(Transform transform)
        {
            Plane = new Plane(Vector3.up, transform.position);
            Transform = transform;
        }
    }
}