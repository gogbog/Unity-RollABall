using UnityEngine;
using System.Collections;

public class FireworksScript : MonoBehaviour
{

    public GameObject ButtonName;

    // Use this for initialization
    void Start()
    {
        Destroy(GameObject.Find("Sphere"));
    }

    
}
