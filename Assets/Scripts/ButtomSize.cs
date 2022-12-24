using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtomSize : MonoBehaviour
{
    public float height = 120f;
    public float depth = 100f;
    public float width = 8000f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Transform transform = gameObject.transform;

        transform.localScale = new Vector3(width, 1, depth);
    }
}
