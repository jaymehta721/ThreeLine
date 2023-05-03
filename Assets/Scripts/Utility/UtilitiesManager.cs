    using Uitilities;
    using UnityEngine;

    namespace Utilities
    {
        public class UtilitiesManager : MonoBehaviour
        {
            public static UtilitiesManager Instance { get; private set; }

            public SpriteScaler spriteScaler { get; private set; }

            private void Awake()
            {
                if (Instance != null)
                {
                    Destroy(gameObject);
                    return;
                }

                Instance = this;
                spriteScaler = new SpriteScaler();
                DontDestroyOnLoad(gameObject);

            
            }
        }
    }