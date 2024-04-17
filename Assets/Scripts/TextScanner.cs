using UnityEngine;

public class TextScanner : MonoBehaviour
{
    // Define a class to represent each pair of colliders and their corresponding game object
    [System.Serializable]
    public class ColliderPair
    {
        public string pairName;
        public Collider topCollider;
        public Collider bottomCollider;
        public GameObject objectToEnable;
        [HideInInspector] public bool topCollision = false;
        [HideInInspector] public bool bottomCollision = false;
    }

    public ColliderPair[] colliderPairs;

    private void OnTriggerEnter(Collider other)
    {
        foreach (ColliderPair pair in colliderPairs)
        {
            if (other == pair.topCollider)
            {
                pair.topCollision = true;
                Debug.Log(pair.pairName + " Top collider hit!");
            }
            else if (other == pair.bottomCollider)
            {
                pair.bottomCollision = true;
                Debug.Log(pair.pairName + " Bottom collider hit!");
            }

            CheckCollisions(pair);
        }
    }

    private void CheckCollisions(ColliderPair pair)
    {
        if (pair.topCollision && pair.bottomCollision)
        {
            pair.objectToEnable.SetActive(true);
        }
    }
}
