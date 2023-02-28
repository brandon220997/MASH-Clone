using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraConfiner : MonoBehaviour
{
    public BoxCollider2D cameraBounds;

    private float minX;
    private float maxX;
    private float minY;
    private float maxY;

    // Start is called before the first frame update
    void Start()
    {
        var height = Camera.main.orthographicSize * 2f;
        var width = height * Camera.main.aspect;

        minX = transform.position.x - (width / 2f);
        maxX = transform.position.x + (width / 2f);
        minY = transform.position.y - (height / 2f);
        maxY = transform.position.y + (height / 2f);
    }

    // Update is called once per frame
    void LateUpdate()
    {

        
    }
}
