using System;
using UnityEngine;

namespace GamePlay
{
    public class PlayerControl : MonoBehaviour
    {


        private Vector3 _dist;
        public bool _circularMotion=false;
        public float searchRadius = 20;
        public LayerMask obstacleLM;
         Transform linkPoint = null;
        [SerializeField] float rotateSpeed;
        [SerializeField] private int speed = 3;
        private Rigidbody2D rb;
        private float radiusRotation;
        [SerializeField]  private Transform PlayerParent;

   
        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            _circularMotion = false;
        }

        public void PlayerMovement()
        {
            if (!_circularMotion)
            {
                rb.velocity = transform.up * speed;
                transform.SetParent(PlayerParent);
            }
            else
            {
                print(transform.parent.name);
 /*               rb.velocity =Vector2.zero;
                Quaternion rotation = Quaternion.LookRotation(linkPoint.position - transform.position, Vector3.up);
                transform.SetParent(linkPoint);
                linkPoint.Rotate(Vector3.forward * (rotateSpeed * Time.deltaTime * speed));
                transform.rotation = rotation; */
            }

            if (Input.GetMouseButtonDown(0))
            {
                GetNearestPoint();
                print("Get Nearest Point !");
            }

            if (linkPoint != null && !_circularMotion)
            {
                Vector3 dir = linkPoint.position - transform.position; 
                if (Vector3.Dot(dir, transform.up) <= 0)
                { 
                    _circularMotion = true;
                    radiusRotation = dir.magnitude;
                    
                }
        
            }

            if ((_circularMotion && Input.GetMouseButtonUp(0)) || linkPoint == null)
            {
                _circularMotion = false;
                linkPoint = null;
                radiusRotation =0;
            }

         
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.collider.CompareTag("Obstacle"))
            {
                Time.timeScale = 0;
            }
        }

        private void GetNearestPoint()
        {
            
            var colliders = Physics2D.OverlapCircleAll(transform.position, searchRadius, obstacleLM);
            float dist = float.PositiveInfinity;
            for (int i = 0; i < colliders.Length; i++)
            {
                var link = colliders[i].transform;
                Vector3 dir = link.position - transform.position;
                float tangentDist = Vector3.ProjectOnPlane(dir, transform.forward).magnitude;
                if (tangentDist < (link.localScale.x + 1))
                    continue;
                float d = dir.sqrMagnitude;
                if (Vector3.Dot(dir, transform.forward) < 0)
                    d *= 8;
                if (d < dist)
                {
                    linkPoint = link;
                    dist = d;
                }
            }
        }
        
    }
}
