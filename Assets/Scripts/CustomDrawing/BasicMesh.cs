using System;
using UnityEditor;
using UnityEngine;

namespace CustomDrawing
{
    public class BasicMesh : MonoBehaviour
    {
        [SerializeField]
        public BasicMesh parent;
        public Transform Transform = new();
        
        private Mesh _mesh;
        [SerializeField] public Color color;

        private void Start()
        {
            _mesh = CreateCube();
            
            if (parent == null) return;
            Transform.Parent = parent.Transform;
        }


        private static Mesh CreateCube()
        {
            Vector3[] vertices =
            {
                new(0, 0, 0), // llf
                new(1, 0, 0), // lrf
                new(1, 1, 0), // urf
                new(0, 1, 0), // ulf
                new(0, 1, 1), // ulb
                new(1, 1, 1), // urb
                new(1, 0, 1), // lrb
                new(0, 0, 1), // llb
            };

            int[] triangles =
            {
                0, 2, 1, //face front
                0, 3, 2,
                2, 3, 4, //face top
                2, 4, 5,
                1, 2, 5, //face right
                1, 5, 6,
                0, 7, 4, //face left
                0, 4, 3,
                5, 4, 7, //face back
                5, 7, 6,
                0, 6, 7, //face bottom
                0, 1, 6
            };

            var mesh = new Mesh();
            mesh.Clear();
            mesh.vertices = vertices;
            mesh.triangles = triangles;
            mesh.Optimize();
            mesh.RecalculateNormals();

            return mesh;
        }
        
        
        private void OnDrawGizmos()
        {
            if (Transform == null) return;
            
            Gizmos.color = Color.red;
            Gizmos.matrix = Transform.TRS.ToUnity();
            Gizmos.DrawMesh(_mesh);
        }
    }
}