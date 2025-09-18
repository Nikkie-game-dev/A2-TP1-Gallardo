
using CustomDrawing;
using UnityEditor;
using UnityEngine;

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


        public override void OnInspectorGUI()
        {
            _mesh = (BasicMesh) target;
            
            _position = Vec3.ToUnityVec(_mesh.Transform.Position);
            _scale = Vec3.ToUnityVec(_mesh.Transform.Scale);
            _rotation = Vec3.ToUnityVec(_mesh.Transform.Rotation);
            _parent = _mesh.parent;

            
            _position = EditorGUILayout.Vector3Field("Position", _position);
            _scale = EditorGUILayout.Vector3Field("Scale", _scale);
            _rotation = EditorGUILayout.Vector3Field("Rotation", _rotation);
            _parent = EditorGUILayout.ObjectField(_parent, typeof(BasicMesh), true);
            
            if (GUI.changed)
            {
                _mesh.Transform.Position = Vec3.FromUnityVec(_position);
                _mesh.Transform.Scale = Vec3.FromUnityVec(_scale);
                _mesh.Transform.Rotation = Vec3.FromUnityVec(_rotation);
                _mesh.parent = (BasicMesh)_parent;
                
                EditorUtility.SetDirty(_mesh);
            }

            if (!_mesh) return;
            
            _mesh.Transform.Position = Vec3.FromUnityVec(_position);
            _mesh.Transform.Scale = Vec3.FromUnityVec(_scale);
            _mesh.Transform.Rotation = Vec3.FromUnityVec(_rotation);
        }
    }
}