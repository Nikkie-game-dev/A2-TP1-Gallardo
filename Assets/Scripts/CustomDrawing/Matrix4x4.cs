using System;
using UnityEngine;

namespace CustomDrawing
{
    public class Matrix4X4 : IEquatable<Matrix4X4>
    {
        public float M11;
        public float M12;
        public float M13;
        public float M14;
        public float M21;
        public float M22;
        public float M23;
        public float M24;
        public float M31;
        public float M32;
        public float M33;
        public float M34;
        public float M41;
        public float M42;
        public float M43;
        public float M44;

        public static Matrix4X4 Identity => new()
        {
            M11 = 1,
            M22 = 1,
            M33 = 1,
            M44 = 1
        };

        public static Matrix4X4 operator +(Matrix4X4 a, Matrix4X4 b)
        {
            return new Matrix4X4
            {
                M11 = a.M11 + b.M11,
                M12 = a.M12 + b.M12,
                M13 = a.M13 + b.M13,
                M14 = a.M14 + b.M14,
                M21 = a.M21 + b.M21,
                M22 = a.M22 + b.M22,
                M23 = a.M23 + b.M23,
                M24 = a.M24 + b.M24,
                M31 = a.M31 + b.M31,
                M32 = a.M32 + b.M32,
                M33 = a.M33 + b.M33,
                M34 = a.M34 + b.M34,
                M41 = a.M41 + b.M41,
                M42 = a.M42 + b.M42,
                M43 = a.M43 + b.M43,
                M44 = a.M44 + b.M44
            };
        }

        public static Matrix4X4 operator *(Matrix4X4 a, float k)
        {
            return new Matrix4X4
            {
                M11 = a.M11 * k,
                M12 = a.M12 * k,
                M13 = a.M13 * k,
                M14 = a.M14 * k,
                M21 = a.M21 * k,
                M22 = a.M22 * k,
                M23 = a.M23 * k,
                M24 = a.M24 * k,
                M31 = a.M31 * k,
                M32 = a.M32 * k,
                M33 = a.M33 * k,
                M34 = a.M34 * k,
                M41 = a.M41 * k,
                M42 = a.M42 * k,
                M43 = a.M43 * k,
                M44 = a.M44 * k
            };
        }

        public static Matrix4X4 operator -(Matrix4X4 a, Matrix4X4 b)
        {
            return new Matrix4X4
            {
                M11 = a.M11 - b.M11,
                M12 = a.M12 - b.M12,
                M13 = a.M13 - b.M13,
                M14 = a.M14 - b.M14,
                M21 = a.M21 - b.M21,
                M22 = a.M22 - b.M22,
                M23 = a.M23 - b.M23,
                M24 = a.M24 - b.M24,
                M31 = a.M31 - b.M31,
                M32 = a.M32 - b.M32,
                M33 = a.M33 - b.M33,
                M34 = a.M34 - b.M34,
                M41 = a.M41 - b.M41,
                M42 = a.M42 - b.M42,
                M43 = a.M43 - b.M43,
                M44 = a.M44 - b.M44
            };
        }

        public static Matrix4X4 operator *(Matrix4X4 a, Matrix4X4 b)
        {
            return new Matrix4X4
            {
                // First row
                M11 = a.M11 * b.M11 + a.M12 * b.M21 + a.M13 * b.M31 + a.M14 * b.M41,
                M12 = a.M11 * b.M12 + a.M12 * b.M22 + a.M13 * b.M32 + a.M14 * b.M42,
                M13 = a.M11 * b.M13 + a.M12 * b.M23 + a.M13 * b.M33 + a.M14 * b.M43,
                M14 = a.M11 * b.M14 + a.M12 * b.M24 + a.M13 * b.M34 + a.M14 * b.M44,

                // Second Row
                M21 = a.M21 * b.M11 + a.M22 * b.M21 + a.M23 * b.M31 + a.M24 * b.M41,
                M22 = a.M21 * b.M12 + a.M22 * b.M22 + a.M23 * b.M32 + a.M24 * b.M42,
                M23 = a.M21 * b.M13 + a.M22 * b.M23 + a.M23 * b.M33 + a.M24 * b.M43,
                M24 = a.M21 * b.M14 + a.M22 * b.M24 + a.M23 * b.M34 + a.M24 * b.M44,

                // Third Row
                M31 = a.M31 * b.M11 + a.M32 * b.M21 + a.M33 * b.M31 + a.M34 * b.M41,
                M32 = a.M31 * b.M12 + a.M32 * b.M22 + a.M33 * b.M32 + a.M34 * b.M42,
                M33 = a.M31 * b.M13 + a.M32 * b.M23 + a.M33 * b.M33 + a.M34 * b.M43,
                M34 = a.M31 * b.M14 + a.M32 * b.M24 + a.M33 * b.M34 + a.M34 * b.M44,

                // Fourth row
                M41 = a.M41 * b.M11 + a.M42 * b.M21 + a.M43 * b.M31 + a.M44 * b.M41,
                M42 = a.M41 * b.M12 + a.M42 * b.M22 + a.M43 * b.M32 + a.M44 * b.M42,
                M43 = a.M41 * b.M13 + a.M42 * b.M23 + a.M43 * b.M33 + a.M44 * b.M43,
                M44 = a.M41 * b.M14 + a.M42 * b.M24 + a.M43 * b.M34 + a.M44 * b.M44
            };
        }

        public static Matrix4X4 Rotate(Quaternion quat)
        {
            /*var x = Identity;
            var y = Identity;
            var z = Identity;

            //X Rotation
            x.M22 = quat.W;
            x.M33 = quat.W;
            x.M32 = quat.X;
            x.M23 = -quat.X;

            // Y Rotation
            y.M11 = quat.W;
            y.M33 = quat.W;
            y.M13 = quat.Y;
            y.M31 = -quat.Y;

            //Z Rotation
            z.M11 = quat.W;
            z.M22 = quat.W;
            z.M21 = quat.Z;
            z.M12 = -quat.Z;


            return z * x * y;*/

            return new Matrix4X4
            {
                // First Row
                M11 = quat.W * quat.W + quat.X * quat.X - quat.Y * quat.Y - quat.Z * quat.Z,
                M12 = 2 * quat.X * quat.Y - 2 * quat.Z * quat.W,
                M13 = 2 * quat.X * quat.Z + 2 * quat.Y * quat.W,
                M14 = 0,

                // Second Row
                M21 = 2 * quat.X * quat.Y + 2 * quat.Z * quat.W,
                M22 = quat.W * quat.W - quat.X * quat.X + quat.Y * quat.Y - quat.Z * quat.Z,
                M23 = 2 * quat.Y * quat.Z - 2 * quat.X * quat.W,
                M24 = 0,

                // Third Row
                M31 = 2 * quat.X * quat.Z - 2 * quat.Y * quat.W,
                M32 = 2 * quat.Y * quat.Z + 2 * quat.X * quat.W,
                M33 = quat.W * quat.W - quat.X * quat.X - quat.Y * quat.Y + quat.Z * quat.Z,
                M34 = 0,

                // Fourth Row
                M41 = 0,
                M42 = 0,
                M43 = 0,
                M44 = 1,
            };
        }

        public static Matrix4X4 RotateFromVec3(Vec3 rot) => Rotate(Quaternion.Rotate(rot));

        public static Matrix4X4 Scale(Vec3 scaling)
        {
            var matrix = Identity;
            matrix.M11 = scaling.X;
            matrix.M22 = scaling.Y;
            matrix.M33 = scaling.Z;
            return matrix;
        }

        public static Matrix4X4 Translate(Vec3 translate)
        {
            var matrix = Identity;
            matrix.M14 = translate.X;
            matrix.M24 = translate.Y;
            matrix.M34 = translate.Z;
            return matrix;
        }

        public static Matrix4X4 TRS(Vec3 pos, Quaternion q, Vec3 s) => Translate(pos) * Rotate(q) * Scale(s);

        public Matrix4x4 ToUnity()
        {
            var result = new Matrix4x4
            {
                m00 = M11,
                m01 = M12,
                m02 = M13,
                m03 = M14,
                m10 = M21,
                m11 = M22,
                m12 = M23,
                m13 = M24,
                m20 = M31,
                m21 = M32,
                m22 = M33,
                m23 = M34,
                m30 = M41,
                m31 = M42,
                m32 = M43,
                m33 = M44
            };
            return result;
        }

        #region Equatable

        public bool Equals(Matrix4X4 other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return M11.Equals(other.M11) && M12.Equals(other.M12) && M13.Equals(other.M13) && M14.Equals(other.M14) &&
                   M21.Equals(other.M21) && M22.Equals(other.M22) && M23.Equals(other.M23) && M24.Equals(other.M24) &&
                   M31.Equals(other.M31) && M32.Equals(other.M32) && M33.Equals(other.M33) && M34.Equals(other.M34) &&
                   M41.Equals(other.M41) && M42.Equals(other.M42) && M43.Equals(other.M43) && M44.Equals(other.M44);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Matrix4X4)obj);
        }

        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(M11);
            hashCode.Add(M12);
            hashCode.Add(M13);
            hashCode.Add(M14);
            hashCode.Add(M21);
            hashCode.Add(M22);
            hashCode.Add(M23);
            hashCode.Add(M24);
            hashCode.Add(M31);
            hashCode.Add(M32);
            hashCode.Add(M33);
            hashCode.Add(M34);
            hashCode.Add(M41);
            hashCode.Add(M42);
            hashCode.Add(M43);
            hashCode.Add(M44);
            return hashCode.ToHashCode();
        }

        #endregion
    }
}