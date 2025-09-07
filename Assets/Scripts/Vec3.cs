using System;
using JetBrains.Annotations;
using UnityEngine;

public struct Vec3 : IEquatable<Vec3>
{

    public float X;
    public float Y;
    public float Z;

    public float SqrMagnitude => Mathf.Pow(X, 2) + Mathf.Pow(Y, 2) + Mathf.Pow(Z, 2);

    public Vec3 Normalized => new(X / Magnitude, Y / Magnitude, Z / Magnitude);

    public float Magnitude => Mathf.Sqrt(SqrMagnitude);
        
    public static Vec3 Zero => new(0.0f, 0.0f, 0.0f);

    public Vec3(float x, float y, float z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public Vec3(Vec3 v3)
    {
        X = v3.X;
        Y = v3.Y;
        Z = v3.Z;
    }

    public Vec3(Vector3 v3)
    {
        X = v3.x;
        Y = v3.y;
        Z = v3.z;
    }

    public static bool operator ==(Vec3 left, Vec3 right)
    {
        var diffX = left.X - right.X;
        var diffY = left.Y - right.Y;
        var diffZ = left.Z - right.Z;
        var sqrMag = diffX * diffX + diffY * diffY + diffZ * diffZ;
        return sqrMag < Mathf.Epsilon * Mathf.Epsilon;
    }

    public static bool operator !=(Vec3 left, Vec3 right) => !(left == right);

    public static Vec3 operator +(Vec3 leftV3, Vec3 rightV3) => new(leftV3.X + rightV3.X, leftV3.Y + rightV3.Y, leftV3.Z + rightV3.Z);

    public static Vec3 operator -(Vec3 leftV3, Vec3 rightV3) => new(leftV3.X - rightV3.X, leftV3.Y - rightV3.Y, leftV3.Z - rightV3.Z);

    public static Vec3 operator -(Vec3 v3) => new(-v3.X, -v3.Y, v3.Z);

    public static Vec3 operator *(Vec3 v3, float scalar) => new(scalar * v3.X, scalar * v3.Y, scalar * v3.Z);

    public static Vec3 operator *(float scalar, Vec3 v3) => v3 * scalar;

    public static Vec3 operator /(Vec3 v3, float scalar) => v3 * (1 / scalar);

    public static implicit operator Vector3(Vec3 v3) => new(v3.X, v3.Y, v3.Z);

    public static implicit operator Vector2(Vec3 v2) => new Vector3(v2.X, v2.Y, 0.0f);
    
    public override string ToString() => "X = " + X.ToString() + "   Y = " + Y.ToString() + "   Z = " + Z.ToString();

    public static float Angle(Vec3 from, Vec3 to) => Mathf.Acos(Dot(from, to) / (from.Magnitude * to.Magnitude));

    public static Vec3 ClampMagnitude(Vec3 vector, float maxLength)
    {
        if (vector.Magnitude > maxLength)
        {
            return new Vec3(vector.Normalized.X * maxLength, vector.Normalized.Y * maxLength,
                vector.Normalized.Z * maxLength);
        }

        return new Vec3(vector);
    }


    public static Vec3 Cross(Vec3 a, Vec3 b) => new(a.Y * b.Z - b.Y * a.Z, b.X * a.Z - a.X * b.Z, a.X * b.Y - b.X * a.Y);

    public static float Distance(Vec3 a, Vec3 b) => Mathf.Sqrt(Mathf.Pow(b.X - a.X, 2) + Mathf.Pow(b.Y - a.Y, 2) + Mathf.Pow(b.Z - a.Z, 2));

    public static float Dot(Vec3 a, Vec3 b) => (a.X * b.X + a.Y * b.Y + a.Z * b.Z);

    public static Vec3 Lerp(Vec3 a, Vec3 b, float t)
    {
        var ret = a + (b - a) * t;
        var distance = Distance(a, b);

        if (Distance(a, ret) < distance && Distance(b, ret) < distance)
        {
            return ret;
        }

        return b;
    }

    public static Vec3 LerpUnclamped(Vec3 a, Vec3 b, float t)
    {
        var ret = a + (b - a) * t;
        var distance = Distance(a, b);

        if (Distance(a, ret) <= distance && Distance(b, ret) <= distance + 1.5)
        {
            return ret;
        }

        return b;
    }

    public static Vec3 Max(Vec3 a, Vec3 b)
    {
        var x = a.X > b.X ? a.X : b.X;
        var y = a.Y > b.Y ? a.Y : b.Y;
        var z = a.Z > b.Z ? a.Z : b.Z;

        return new Vec3(x, y, z);
    }

    public static Vec3 Min(Vec3 a, Vec3 b)
    {
        var x = a.X < b.X ? a.X : b.X;
        var y = a.Y < b.Y ? a.Y : b.Y;
        var z = a.Z < b.Z ? a.Z : b.Z;

        return new Vec3(x, y, z);
    }
    
    public void Normalize()
    {
        var norml = Normalized;

        X = norml.X;
        Y = norml.Y;
        Z = norml.Z;
    }


    #region Internals

    public override bool Equals([CanBeNull] object other)
    {
        return other is Vec3 vec3 && Equals(vec3);
    }

    public bool Equals(Vec3 other)
    {
        return Mathf.Approximately(X, other.X) && Mathf.Approximately(Y, other.Y) && Mathf.Approximately(Z, other.Z);
    }

    public override int GetHashCode()
    {
        return X.GetHashCode() ^ (Y.GetHashCode() << 2) ^ (Z.GetHashCode() >> 2);
    }

    #endregion
}