import improbable.corelib.launcher.ShutdownAfterInput
import improbable.dapi.Launcher
import improbable.unity.fabric.engine.DownloadableClientEngineDescriptor

object SpatialOSLauncherWithManualWorkers extends DemonstrationGameLauncher(ManualEngineStartupLaunchConfig) with App with ShutdownAfterInput

object SpatialOSLauncherWithAutomaticWorkers extends DemonstrationGameLauncher(AutomaticEngineStartupLaunchConfig) with App with ShutdownAfterInput

object LocalDemonstration extends DemonstrationGameLauncher(AutomaticEngineStartupLaunchConfig) with App with ShutdownAfterInput

object VisibleClient extends DownloadableClientEngineDescriptor(withGui = true)

class DemonstrationGameLauncher(gameSetupSettings: DefaultPirateLauncher, options: String*) {
  val allOptions = options ++ Seq(
    "--game_world_edge_length=8000",
    "--resource_based_config_name=one-gsim-one-jvm",
    "--entity_activator=improbable.corelib.entity.CoreLibraryEntityActivator"
  )
  Launcher.startGame(gameSetupSettings, allOptions: _*)
}
