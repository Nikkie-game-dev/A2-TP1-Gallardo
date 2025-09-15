// 07/09/2025 - TP1-Gallardo

using CustomDrawing;
using UnityEditor;
using UnityEngine;

namespace Inspector
{
    [CustomEditor(typeof(BasicMesh))]
    public class MeshInspector : Editor
    {
        private BasicMesh _mesh;
        private Vector3 _position;
        private Vector3 _scale;
        private Vector3 _rotation;


        public override void OnInspectorGUI()
        {
            _mesh = (BasicMesh) target;
            
            _position = EditorGUILayout.Vector3Field("Position", _position);
            _scale = EditorGUILayout.Vector3Field("Scale", _scale);
            _rotation = EditorGUILayout.Vector3Field("Rotation", _rotation);

            if (GUI.changed)
            {
                EditorUtility.SetDirty(_mesh);
            }

            if (!_mesh) return;
            
            _mesh.Transform.Position = Vec3.FromUnityVec(_position);
            _mesh.Transform.Scale = Vec3.FromUnityVec(_scale);
            _mesh.Transform.Rotation = Vec3.FromUnityVec(_rotation);
        }
    }
}