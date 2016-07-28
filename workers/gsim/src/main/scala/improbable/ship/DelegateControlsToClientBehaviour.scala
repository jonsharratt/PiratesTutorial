package improbable.ship

import improbable.corelib.util.EntityOwnerUtils
import improbable.papi.entity.{Entity, EntityBehaviour}
import improbable.unity.papi.SpecificEngineConstraint

class DelegateControlsToClientBehaviour(entity: Entity) extends EntityBehaviour {

  override def onReady(): Unit = {
    entity.delegateState[ShipControls](SpecificEngineConstraint(EntityOwnerUtils.ownerIdOf(entity)))
  }
}
