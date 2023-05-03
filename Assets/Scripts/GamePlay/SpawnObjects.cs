using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnObjects : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float distanceBetweenObs;
    [SerializeField] private float obsticalParBack;
    [SerializeField] private Transform[] spawnObstacle;
    private Vector3 _pastPos;
    private Camera _camera;
    private float _leftEndPos, _rightEndPos,_bottomEndPos,_topEndPos;

    private void Start()
    {
        _pastPos = Vector3.positiveInfinity;
        _camera = Camera.main;
        var scale = spawnObstacle[0].localScale.x / 2;
        var xPos = _camera.ViewportToWorldPoint(new Vector3(0, 0, 0));
        var yPos = _camera.ViewportToWorldPoint(new Vector3(1, 0, 0));
        _leftEndPos = xPos.x + scale;
        _rightEndPos = yPos.x  - scale;
        _bottomEndPos = xPos.y  + scale + player.position.y;
        _topEndPos =  yPos.y  - scale;

    }

    public void GenerateObstacle()
    {
        ResetObstaclePoint();
        for (int i = 0; i < obsticalParBack; i++)
        {
            if (Vector3.Distance(_pastPos, player.transform.position) > distanceBetweenObs)
            {
                var obj =  spawnObstacle[i].gameObject;
                var xPos = Random.Range(_leftEndPos,_rightEndPos);
                var yPos = Random.Range(_bottomEndPos,_topEndPos);
                yPos += _camera.transform.position.y;
                obj.transform.position = new Vector3(xPos,yPos,0);
                _pastPos = obj.transform.position;
                obj.SetActive(true);
            }
        }

    }

    private void ResetObstaclePoint()
    {
        for (int i = 0; i < spawnObstacle.Length; i++)
        {
            spawnObstacle[i].gameObject.SetActive(false);
        }
    }
    
}
