using UnityEngine;

namespace Assets.Gamelogic.Pirates.Cannons
{
    public class DestroyCannonball : MonoBehaviour
    {
        public float SecondsUntilDestroy = 4f;
        private float spawnTime;

        void Start()
        {
            spawnTime = Time.time;
        }

        void Update()
        {
            var lifeTime = Time.time - spawnTime;
            if (lifeTime > SecondsUntilDestroy)
            {
                Destroy(gameObject);
            }
        }
    }
}