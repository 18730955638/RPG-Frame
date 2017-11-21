using UnityEngine;
using System.Collections;

using U3DEventFrame;
using System;

public enum UIEvents
{
    Initial = ManagerID.UIManager + 1,
    GetResource,
    MaxValue
}

public enum LoadTemplate
{
    Initial = UIEvents.MaxValue,
    GetConfig,
    GetResource,
    MaxValue
}
