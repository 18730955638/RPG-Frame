using UnityEngine; 
using Game.Network;
using System;

/// <summary>
/// APP检测更新
/// </summary>
public class CheckAppUpdateModel : HTTPPacketRequest
{
    public string scopeName = HttpUtils.SCOPE_NAME;
}