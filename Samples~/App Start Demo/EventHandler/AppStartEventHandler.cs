using Framework;
using Framework.EventType;
using UnityEngine;

namespace Framework_Package.App_Start_Demo
{
    public class AppStartEventHandler : AEvent<AppStart>
    {
        public override async ETask Run(AppStart a)
        {
            Debug.Log("AppStart");
        }
    }
}