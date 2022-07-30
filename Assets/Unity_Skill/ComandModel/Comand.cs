using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Comand 
{
    /// <summary>
    /// 命令模式包含:执行,撤销命令
    /// 在命令管理器中逐条记录命令,以实现逐条撤销或逐条执行
    /// </summary>
    /// <param name="gameObject"></param>
    public abstract void Excute(GameObject gameObject);
    public abstract void Undo();
}
