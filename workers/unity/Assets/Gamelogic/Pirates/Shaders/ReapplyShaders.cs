using UnityEngine;
using Improbable.Unity;
using Improbable.Unity.Visualizer;

namespace Assets.Gamelogic.Pirates.Shaders
{
    [EngineType(EnginePlatform.Client)]
    public class ReapplyShaders : MonoBehaviour
    {
        // This script fixes a Unity bug that prevents shaders from correctly being visualised on Macs.

        private Renderer[] renderers;

        private void Awake()
        {
            renderers = GetComponentsInChildren<Renderer>();
        }

        private void Start()
        {
            foreach (var renderer in renderers)
            {
                var materials = renderer.sharedMaterials;

                foreach (var material in materials)
                {
                    var shader = material.shader.name;
                    material.shader = Shader.Find(shader);
                }
            }
        }
    }
}