using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class asyncScript : MonoBehaviour
{
    // Start is called before the first frame update
    async void Start()
    {
        MoveByAsync moveByAsync = new MoveByAsync();
        await moveByAsync.Move(transform);
        Debug.Log("等待await后语句执行完毕后,才会打印本句话.");
        //Move();
    }

    //async void Move()
    //{
    //    await Task.Delay(System.TimeSpan.FromSeconds(0.5f));
    //    transform.position += Vector3.right;
    //}
}
public class MoveByAsync
{
    public async Task Move(Transform transform)
    {
        await Task.Delay(System.TimeSpan.FromSeconds(0.5f));
        transform.position += Vector3.right;
    }
}
