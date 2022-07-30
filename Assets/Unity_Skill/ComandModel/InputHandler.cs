using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private readonly MoveForward forward = new MoveForward();
    private readonly MoveDown down = new MoveDown();
    private readonly MoveLeft left = new MoveLeft();
    private readonly MoveRight right = new MoveRight();

    private GameObject _player;
    private KeyCode[] keyCodes;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("ComandPlayer");
        keyCodes = new[] { KeyCode.A, KeyCode.D, KeyCode.W, KeyCode.S, KeyCode.B };
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInputHandler();
    }

    private void PlayerInputHandler()
    {
        if (Input.GetKeyDown(keyCodes[4]))
        {
            StartCoroutine(ComandManager.Instance.UndoStart());
        }
        if (Input.GetKeyDown(keyCodes[2]))
        {
            forward.Excute(_player);
            ComandManager.Instance.AddComand(forward);
        }
        if (Input.GetKeyDown(keyCodes[3]))
        {
            down.Excute(_player);
            ComandManager.Instance.AddComand(down);
        }
        if (Input.GetKeyDown(keyCodes[0]))
        {
            left.Excute(_player);
            ComandManager.Instance.AddComand(left);
        }
        if (Input.GetKeyDown(keyCodes[1]))
        {
            right.Excute(_player);
            ComandManager.Instance.AddComand(right);
        }
    }
}
