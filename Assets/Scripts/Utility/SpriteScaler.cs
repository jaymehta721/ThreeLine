using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Uitilities
{
    public class SpriteScaler
    {

        /// <summary>
        /// This Method will return the Vector3 Scale value and help to fit sprite to the device screen
        /// </summary>
        /// <param name="SpriteRenderer"></param>
        /// <param name="Transform"></param>
        /// <param name="Camera"></param>
        /// <returns>Vector3</returns>
       public Vector3 TryToFitSprite(SpriteRenderer sr,Transform transform,Camera camera)
        {
            var sprite = sr.sprite;
            float worldScreenHeight = camera.orthographicSize * 2.0f;
            float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;
            Vector3 xScale = transform.localScale;
            xScale.x = worldScreenWidth / sprite.bounds.size.x;
            xScale.y = worldScreenHeight / sprite.bounds.size.y;
            return xScale;
        }

    }
}