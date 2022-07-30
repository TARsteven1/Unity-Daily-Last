using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LambdaScript : MonoBehaviour
{
    Func<int, int, bool> test4Equality = (x, y) => x == y;//返回bool
    Action<int, int, bool> eerr = (x,y,fasle) =>  x=y;//Action无返回值
    Predicate<string> isUpper = s => s.Equals(s.ToUpper());//默认返回bool

}
