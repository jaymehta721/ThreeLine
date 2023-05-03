using System;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay
{
    public class InfiniteBackground : MonoBehaviour
    {
        private Camera m_camera;
        private Transform m_camTransform;

        private Vector3 _newPos;
        [SerializeField] private float sideLineScale = 0.6f;
        [SerializeField] private BackgroundTile m_backgroundTile;
        private List<BackgroundTile> m_backgroundTiles;
        private List<SideLineTiles> m_sideLine;
        private Bounds m_bounds;

        
        //[SerializeField] private SpriteRenderer[] sideLineSr;
      //  [SerializeField] private Transform[] bgGo;
        [SerializeField] private Material sideLineMaterial;
        private static readonly int EmissionColor = Shader.PropertyToID("_EmissionColor");
        private Vector3 _leftLinePos, _rightLinePos;
        public Color SetLineColor
        {
            get => sideLineMaterial.GetColor(EmissionColor);
            set => sideLineMaterial.SetColor(EmissionColor, value);
        }

        private void Start()
        {
            _newPos = Vector3.zero;
            m_camera = Camera.main;
            m_camTransform = m_camera.transform;
           
            
            for (int i = 0; i < bgSr.Length; i++)
            {
                bgSr[i].transform.localScale = TryToFitSprite(bgSr[i]);
            }
            _leftLinePos = m_camera.ViewportToWorldPoint(new Vector3(0, 0, 0));
            _rightLinePos = m_camera.ViewportToWorldPoint(new Vector3(1, 0, 0));
            for (int i = 0; i < sideLineSr.Length; i++)
            {
                var tempScale = TryToFitSprite(sideLineSr[i]);
                tempScale.x = sideLineScale;
                sideLineSr[i].transform.localScale = tempScale;
                var position = sideLineSr[i].transform.position;

                if (i % 2 == 0)
                {
                    position.x = _leftLinePos.x + (sideLineScale / 2);
                }
                else
                {
                    position.x = _rightLinePos.x - (sideLineScale / 2);
                }

                sideLineSr[i].transform.position = position;
            }
            SetLineColor = Color.yellow;
        }

        public bool MoveBackground()
        {
            if (m_camTransform.position.y > ((m_screenSize * 2) * (_lastBgPos - 1)))
            {
                _lastBgPos++;
                _newPos.y = (m_screenSize * 2) * _lastBgPos;
                bgGo[_bgLength].transform.position = _newPos;
                (bgGo[0], bgGo[_bgLength]) = (bgGo[_bgLength], bgGo[0]);
                (bgGo[_bgLength], bgGo[1]) = (bgGo[1], bgGo[_bgLength]);
                return true;
            }

            return false;
        }


        public bool isPlayerOutOfLine(Vector3 pos)
        {
            if (pos.x <= _leftLinePos.x || pos.x > _rightLinePos.x)
            {
                return true;
            }

            return false;
        }
    }
}