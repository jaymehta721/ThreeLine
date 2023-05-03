using System;
using UnityEngine;

namespace GamePlay
{
  [RequireComponent(typeof(Camera))]
  public class CameraControl : MonoBehaviour
  {
    [SerializeField] private Transform target;
    [SerializeField] private float smoothTime = 0.15f;
    [SerializeField] private Vector3 offset;
    private Vector3 _currentPos,_targetPosDist,_velocity = Vector3.zero;

    private void Update()
    {
      if (target)
      {
        _currentPos = transform.position;
        _targetPosDist = target.position;
        _targetPosDist.z = 0;
        _targetPosDist += offset;
        transform.position = Vector3.SmoothDamp(_currentPos, _targetPosDist, ref _velocity, smoothTime);
      }
    }
  }
}
