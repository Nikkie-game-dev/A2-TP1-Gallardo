
using System;
using CustomDrawing;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Inspector
{
    [CustomEditor(typeof(BasicMesh))]
    public class MeshInspector : Editor
    {
        private BasicMesh _mesh;
        private Object _parent;
        private Vector3 _position;
        private Vector3 _scale;
        private Vector3 _rotation;
        private Color _color;

        public void OnEnable()
        {
            _mesh = (BasicMesh) target;
            _position = Vec3.ToUnityVec(_mesh.Transform.Position);
            _scale = Vec3.ToUnityVec(_mesh.Transform.Scale);
            _rotation = Vec3.ToUnityVec(_mesh.Transform.Rotation);
            _parent = _mesh.parent;
            _color = _mesh.color;
        }

        public override void OnInspectorGUI()
        {
            _position = EditorGUILayout.Vector3Field("Position", _position);
            _scale = EditorGUILayout.Vector3Field("Scale", _scale);
            _rotation = EditorGUILayout.Vector3Field("Rotation", _rotation);
            _parent = EditorGUILayout.ObjectField("parent", _parent, typeof(BasicMesh), true);
            _color = EditorGUILayout.ColorField("Color", _color);
            
            if (GUI.changed)
            {
                _mesh.Transform.Position = Vec3.FromUnityVec(_position);
                _mesh.Transform.Scale = Vec3.FromUnityVec(_scale);
                _mesh.Transform.Rotation = Vec3.FromUnityVec(_rotation);
                _mesh.parent = (BasicMesh)_parent;
                _mesh.color = _color;
                
                EditorUtility.SetDirty(_mesh);
            }

            /*if (!_mesh) return;
            
            _mesh.Transform.Position = Vec3.FromUnityVec(_position);
            _mesh.Transform.Scale = Vec3.FromUnityVec(_scale);
            _mesh.Transform.Rotation = Vec3.FromUnityVec(_rotation);
            _mesh.parent = (BasicMesh)_parent;
            _mesh.color = _color;*/
        }
    }
}