using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using Framework;
using Framework.EventType;
using UnityEngine;

public class Init : MonoBehaviour
{
    void Start()
    {
        StartAsync().Coroutine();
    }
    
    private async ETask StartAsync()
    {
        try
        {
            SynchronizationContext.SetSynchronizationContext(OneThreadSynchronizationContext.Instance);
            DontDestroyOnLoad(this.gameObject);

            string[] assemblies = { "Framework.dll" , "Samples.dll"};

            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                string assemblyName = assembly.ManifestModule.Name;
                if(!assemblies.Contains(assemblyName)) continue;
                Game.EventSystem.Add(assembly);
            }
            
            
            //添加一些软件必备组件
            Game.Scene.AddComponent<TimerComponent>();
            
            await Game.EventSystem.Publish(new AppStart());
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }

    private void Update()
    {
        OneThreadSynchronizationContext.Instance.Update();
        
        Game.EventSystem.Update();
    }

    private void LateUpdate()
    {
        Game.EventSystem.LateUpdate();
    }
}
