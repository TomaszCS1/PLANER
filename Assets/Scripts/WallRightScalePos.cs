using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRightScalePos : MonoBehaviour
{
    public float height = 300f;
    public float depth = 400f;
    public float width = 220f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Transform transform = gameObject.transform;

        transform.localScale = new Vector3(1, height, depth);
        transform.position = new Vector3((width / 2) * 10, 0, 0);
    }
}
