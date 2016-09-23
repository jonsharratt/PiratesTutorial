using UnityEngine;
using Improbable.Unity;

public class ReapplyShaders : MonoBehaviour
{

    // This script fixes a Unity bug that prevents shaders from correctly being visualised on Macs.

    private Renderer[] renderers;
    private Material[] materials;
    private string[] shaders;

    private void Awake()
    {
        switch (EngineTypeUtils.CurrentEnginePlatform)
        {
            case EnginePlatform.Client:
                renderers = GetComponentsInChildren<Renderer>();
                break;
            case EnginePlatform.FSim:
                break;
        }
    }

    private void Start()
    {
        switch (EngineTypeUtils.CurrentEnginePlatform)
        {
            case EnginePlatform.Client:
                foreach (var renderer in renderers)
                {
                    materials = renderer.sharedMaterials;
                    shaders = new string[materials.Length];

                    for (int i = 0; i < materials.Length; i++)
                    {
                        shaders[i] = materials[i].shader.name;
                    }

                    for (int i = 0; i < materials.Length; i++)
                    {
                        materials[i].shader = Shader.Find(shaders[i]);
                    }
                }
                break;
            case EnginePlatform.FSim:
                break;
        }

    }
}
