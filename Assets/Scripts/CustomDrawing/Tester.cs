using JetBrains.Annotations;
using UnityEngine;
using Object = UnityEngine.Object;

namespace CustomDrawing
{
    public class Tester : MonoBehaviour
    {
        [SerializeField] private BasicMesh cube;
        [SerializeField] private Vector3 spin;
        [SerializeField] private Vector3 speed;
        
        
        private void FixedUpdate()
        {
            if(!cube) return;
            
            cube.Transform.Rotation += Vec3.FromUnityVec(spin * Time.deltaTime);
            cube.Transform.Position += Vec3.FromUnityVec(speed * Time.deltaTime);
        }
    }
}
