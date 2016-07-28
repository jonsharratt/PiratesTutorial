using Improbable.Ship;
using Improbable.Unity.Visualizer;
using UnityEngine;

namespace Assets.Gamelogic.Pirates.Behaviours
{
    public class PlayerInputController : MonoBehaviour {
    
        [Require] protected ShipControlsWriter ShipControls;
    
        void Update ()
        {
            ShipControls.Update
                .TargetSpeed(Mathf.Clamp01(Input.GetAxis("Vertical")))
                .TargetSteering(Input.GetAxis("Horizontal"))
                .FinishAndSend();
        }
    }
}
