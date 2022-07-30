using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : Comand
{
    private GameObject _player;
    public override void Excute(GameObject gameObject)
    {
        _player = gameObject;
        gameObject.transform.Translate(Vector3.forward);
    }

    public override void Undo( )
    {
        _player .
        transform.Translate(Vector3.down);
    }
}public class MoveDown : Comand
{
    private GameObject _player;
    public override void Excute(GameObject gameObject)
    {
        _player = gameObject;
        gameObject.transform.Translate(Vector3.down);
    }

    public override void Undo()
    {
        _player . 
        transform.Translate(Vector3.forward);
    }
}public class MoveLeft : Comand
{
    private GameObject _player;
    public override void Excute(GameObject gameObject)
    {
        _player = gameObject;
        _player.transform.Translate(Vector3.left);
    }

    public override void Undo()
    {
        _player.transform.Translate(Vector3.right);
    }
}public class MoveRight : Comand
{
    private GameObject _player;
    public override void Excute(GameObject gameObject)
    {
        _player = gameObject;
        gameObject.transform.Translate(Vector3.right);
    }

    public override void Undo()
    {
      
        _player.transform.Translate(Vector3.left);
    }
}
