using UnityEngine;

public class TextScanner : MonoBehaviour
{
    public AudioSource beep;
    // Define a class to represent each pair of colliders and their corresponding game object
    [System.Serializable]
    public class ColliderPair
    {
        public string pairName;
        public Collider textCollider;
        public GameObject objectToEnable;
        [HideInInspector] public bool topCollision = false;
    }

    public ColliderPair[] colliderPairs;

    private void OnTriggerEnter(Collider other)
    {
        foreach (ColliderPair pair in colliderPairs)
        {
            if (other == pair.textCollider)
            {
                pair.topCollision = true;
                beep.Play();
                Debug.Log(pair.pairName + " Text collider hit!");
            }
            CheckCollisions(pair);
        }
    }

    private void CheckCollisions(ColliderPair pair)
    {
        if (pair.topCollision)
        {
            pair.objectToEnable.SetActive(true);
        }
    }
}
