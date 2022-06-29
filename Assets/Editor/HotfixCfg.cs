using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public static class HotfixCfg 
{
    [Hotfix]
    public static List<Type> by_field = new List<Type>()
    {
        //typeof (HotFixSubClass),
        //typeof (GenericClass<>),
        typeof (HotfixScript),
        typeof (Cube)
    };
   /* [Hotfix]
    public static List<Type> by_property
    {
        get
        {
            return (from type in Assembly.Load("Assembly-CSharp").GetTypes()
                    where type.Namespace == "XXX"
                    select type).ToList();
        }
    }*/
}
