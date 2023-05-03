using System;
using System.Collections;
using System.Collections.Generic;
using GamePlay;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private InfiniteBackground infiniteBackground;
    [SerializeField] private SpawnObjects spawnObjects;
    [SerializeField] private PlayerControl _playerControl;
    private void Start()
    {
     //   spawnObjects.GenerateObstacle(); 
    }

    void Update()
    {
        if (infiniteBackground.MoveBackground())
        {
        //    spawnObjects.GenerateObstacle();
        }
        
        _playerControl.PlayerMovement();


    }
}
