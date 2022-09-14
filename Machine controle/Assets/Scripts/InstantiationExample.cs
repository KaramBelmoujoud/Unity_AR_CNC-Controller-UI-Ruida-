using UnityEngine;
public class InstantiationExample : MonoBehaviour
{
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject myPrefab;
    //public GameObject ArSession;

    // This script will simply instantiate the Prefab when the game starts.
    void Start()
    {
        // Instantiate at position (0, 0, 0) and zero rotation.
        Instantiate(myPrefab/*, new Vector3(0, -1.31f, 1.80f), Quaternion.identity*/);
        //Instantiate(ArSession);
    }
}