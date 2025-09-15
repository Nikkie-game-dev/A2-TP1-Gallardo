using System;
using UnityEngine;
using UnityEngine.Rendering;

namespace CustomDrawing
{
    public class Quaternion : IEquatable<Quaternion>
    {
        public float W;
        public float X;
        public float Y;
        public float Z;

        public Quaternion(Vec3 vector)
        {
        }

        public Quaternion(Quaternion other)
        {
            W = other.W;
            X = other.X;
            Y = other.Y;
            Z = other.Z;
        }

        public Quaternion(float w, float x, float y, float z)
        {
            W = w;
            X = x;
            Y = y;
            Z = z;
        }

        private Quaternion()
        {
            W = 0;
            X = 0;
            Y = 0;
            Z = 0;
        }


        public static Quaternion operator *(Quaternion a, Quaternion b)
        {
            return new Quaternion
            {
                W = a.W * b.W - a.X * b.X - a.Y * b.Y - a.Z * b.Z,
                X = a.W * b.X + a.X * b.W + a.Y * b.X - a.Z * b.Y,
                Y = a.W * b.Y - a.X * b.Z + a.Y * b.W + a.Z * b.X,
                Z = a.W * b.Z + a.X * b.Y - a.Y * b.X + a.Z * b.W
            };
        }

        public static Quaternion Rotate(Vec3 angle)
        {
            var x = new Quaternion(Mathf.Cos(angle.X * 0.5f * Mathf.Deg2Rad), Mathf.Sin(angle.X * 0.5f * Mathf.Deg2Rad), 0, 0);
            var y = new Quaternion(Mathf.Cos(angle.Y * 0.5f * Mathf.Deg2Rad), 0, Mathf.Sin(angle.Y * 0.5f * Mathf.Deg2Rad), 0);
            var z = new Quaternion(Mathf.Cos(angle.Z * 0.5f * Mathf.Deg2Rad), 0, 0, Mathf.Sin(angle.Z * 0.5f * Mathf.Deg2Rad));

            return x * z * y;
        }

        public bool Equals(Quaternion other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return W.Equals(other.W) && X.Equals(other.X) && Y.Equals(other.Y) && Z.Equals(other.Z);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Quaternion)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(W, X, Y, Z);
        }
    }
}