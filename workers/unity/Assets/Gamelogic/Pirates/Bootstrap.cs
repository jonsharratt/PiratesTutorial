using System;
using System.Collections.Generic;
using Improbable.Core;
using Improbable.Core.Network;
using Improbable.Fapi.Receptionist;
using Improbable.Unity;
using Improbable.Unity.Core;
using UnityEngine;

public class Bootstrap : MonoBehaviour, IBootstrapHandler
{
    public string ReceptionistIp = "localhost";
    public int ReceptionistPort = 7777;
    public EnginePlatform EngineType = EnginePlatform.Client;
    public int FixedUpdateRate = 20;
    public int TargetFps = 60;
    public bool UsePrefabPooling = true;
    public bool Instrument = true;
    public bool IsDebugMode = true;
    public LinkProtocol LinkProtocol = LinkProtocol.RakNet;
    public int MsgProcessLimitPerFrame = 0;
    public int EntityCreationLimitPerFrame = 0;

    public void Start()
    {
        var engineConfiguration = EngineConfiguration.Instance;
        engineConfiguration.AssemblyName = "";
        engineConfiguration.Ip = ReceptionistIp;
        engineConfiguration.Port = ReceptionistPort;
        engineConfiguration.TargetFps = TargetFps;
        engineConfiguration.FixedUpdateRate = FixedUpdateRate;
        engineConfiguration.UsePrefabPooling = UsePrefabPooling;
        engineConfiguration.EngineType = EngineTypeUtils.ToEngineName(EngineType);
        engineConfiguration.UseInstrumentation = Instrument;
        engineConfiguration.IsDebugMode = IsDebugMode;
        engineConfiguration.LinkProtocol = LinkProtocol;
        engineConfiguration.AppName = "pirates";
        engineConfiguration.MsgProcessLimitPerFrame = MsgProcessLimitPerFrame;
        engineConfiguration.EntityCreationLimitPerFrame = EntityCreationLimitPerFrame;
        EngineLifecycleManager.StartGame(this, gameObject);
    }

    public void OnQueuingStarted()
    {
        Debug.Log("Queueing started");
    }

    public void OnQueuingUpdate(IQueueStatus status)
    {
        Debug.Log("Queue status: " + status);
    }

    public void OnQueuingCompleted(IQueueStatus status)
    {
        Debug.Log("Queueing complete");
    }

    public void OnBootstrapError(Exception exception)
    {
        Debug.LogException(exception, this);
    }

    public void OnDeploymentListRetrieved(IList<IDeployment> deployments, Action<IDeployment> handleChosenDeployment)
    {
        handleChosenDeployment(deployments[0]);
    }

    public void BeginPreconnectionTasks(IDeployment deployment, IContainer container, Action onCompletedPreconnectionTasks)
    {
        onCompletedPreconnectionTasks();
    }
}