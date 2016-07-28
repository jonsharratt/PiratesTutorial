using Improbable.Ship;
using Improbable.Unity.Visualizer;
using UnityEngine;

namespace Assets.Gamelogic.Pirates.Behaviours
{
    public class CameraEnablerVisualizer : MonoBehaviour
    {
        [Require] protected ShipControlsWriter ShipControlsAuthorityCheck;

        public UnityEngine.Camera OurCamera;

        public void OnEnable()
        {
            OurCamera.enabled = true;
        }

        public void OnDisable()
        {
            OurCamera.enabled = false;
        }
    }
}
