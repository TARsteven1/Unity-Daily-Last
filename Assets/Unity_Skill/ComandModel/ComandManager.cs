using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComandManager : MonoBehaviour
{
    public static ComandManager Instance;
    private readonly List<Comand> comands = new List<Comand>();
    private void Awake()
    {
        if (Instance)
        {
            Destroy(Instance);
        }
        else
        {
            Instance = this;
        }
    }
   public void AddComand(Comand comand)
    {
        comands.Add(comand);
    }
   public IEnumerator UndoStart()
    {
        if (comands.Count==0)
        {
           yield return null;
            
        }
        comands.Reverse();//倒转天罡
        foreach (var item in comands)
        {
            yield return new WaitForSeconds(.2f);
            item.Undo();
        }
        comands.Clear();
    }
}
