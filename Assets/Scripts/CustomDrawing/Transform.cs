using UnityEngine;

namespace CustomDrawing
{
    public class Transform
    {
        private Vec3 _position = new(0f, 0f, 0f);
        private Vec3 _rotation = new(0f, 0f, 0f);
        private Vec3 _scale = new(1f, 1f, 1f);

        public Transform Parent = null;

        public Vec3 Position
        {
            get => _position;
            set
            {
                _position = value;
                ApplyTransform();
            }
        }

        public Vec3 Rotation
        {
            get => _rotation;
            set
            {
                _rotation = value;
                ApplyTransform();
            }
        }

        public Vec3 Scale
        {
            get => _scale;
            set
            {
                _scale = value;
                ApplyTransform();
            }
        }

        private void ApplyTransform()
        {
            if (Parent != null)
            {
                TRS = Parent.TRS * Matrix4X4.TRS(_position, Quaternion.Rotate(_rotation), _scale);
            }
            else
            {
                TRS = Matrix4X4.TRS(_position, Quaternion.Rotate(_rotation), _scale);
            }
        }

        public Matrix4X4 TRS = Matrix4X4.Identity;
    }
}