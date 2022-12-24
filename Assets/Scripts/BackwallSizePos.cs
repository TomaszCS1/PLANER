using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackwallSizePos
   : MonoBehaviour
{

    public float height=300f;
    public float depth=400f;
    public float width=220f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Transform transform = gameObject.transform;

        transform.localScale = new Vector3(width, height, 1);
        transform.position = new Vector3(0, 0, depth * 10);

    }
}
