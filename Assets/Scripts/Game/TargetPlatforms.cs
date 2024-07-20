using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Platforms { none, mobile, pc }

//Script for setting target platform
public class TargetPlatforms
{

#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
public static Platforms setPlatform = Platforms.mobile;
#elif UNITY_STANDALONE || UNITY_WEBGL || UNITY_EDITOR
    public static Platforms setPlatform = Platforms.pc;
#else
    public static Platforms setPlatform = Platforms.none;
#endif

}
