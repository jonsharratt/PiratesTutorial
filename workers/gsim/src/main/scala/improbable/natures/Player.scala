// Copyright (c) 2014 All Right Reserved, Improbable Worlds Ltd.
package improbable.natures

import improbable.corelib.natures.{BaseNature, NatureApplication, NatureDescription}
import improbable.corelib.util.EntityOwnerDescriptor
import improbable.corelibrary.transforms.TransformNature
import improbable.papi.engine.EngineId
import improbable.papi.entity.EntityPrefab
import improbable.papi.entity.behaviour.EntityBehaviourDescriptor
import improbable.physical.ClientSideAuthorityBehaviour
import improbable.ship.{DelegateControlsToClientBehaviour, ShipControls}

object Player extends NatureDescription {

  override val dependencies = Set[NatureDescription](BaseNature, TransformNature)

  override def activeBehaviours: Set[EntityBehaviourDescriptor] = {
    Set(
      descriptorOf[ClientSideAuthorityBehaviour],
      descriptorOf[DelegateControlsToClientBehaviour]
    )
  }

  def apply(engineId: EngineId): NatureApplication = {
    application(
      states = Seq(EntityOwnerDescriptor(Some(engineId)), ShipControls(0, 0)),
      natures = Seq(BaseNature(EntityPrefab("PlayerShip")), TransformNature())
    )
  }
}
