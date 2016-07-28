package improbable.apps

import com.typesafe.scalalogging.Logger
import improbable.math.Vector3d
import improbable.natures.Terrain
import improbable.papi.world.AppWorld
import improbable.papi.worldapp.{WorldApp, WorldAppLifecycle}

class Spawner(val world: AppWorld, logger: Logger, val lifecycle: WorldAppLifecycle) extends WorldApp {

  //Code here will be run when the simulation first starts.
  world.entities.spawnEntity(Terrain(Vector3d.zero))
}
