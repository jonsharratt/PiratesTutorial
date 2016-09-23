using UnityEngine;
using System.Collections;
using Assets.Gamelogic.Pirates.Cannons;
using Improbable.Ship;
using Improbable.Unity.Visualizer;

public class CannonVisualizer: MonoBehaviour
{
    [Require]
    protected ShipControlsReader ShipControls;
    private Cannon cannon;

    void Start()
    {
        cannon = gameObject.GetComponent<Cannon>();
    }

    void OnEnable()
    {
        // Write your code here!
    }

    private void FireCannons(Vector3 direction)
    {
        if (cannon != null)
        {
            cannon.Fire(direction);
        }
    }

    void OnDisable()
    {
        // Write your code here!
    }
}