using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;

    public BoxCollider2D cameraBounds;

    private float height;
    private float width;

    // Start is called before the first frame update
    void Start()
    {
        height = Camera.main.orthographicSize * 2f;
        width = height * Camera.main.aspect;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        var positionX = Mathf.Clamp(player.transform.position.x, cameraBounds.bounds.min.x + (width / 2f), cameraBounds.bounds.max.x - (width / 2f));
        var positionY = Mathf.Clamp(player.transform.position.y, cameraBounds.bounds.min.y + (height / 2f), cameraBounds.bounds.max.y - (height / 2f));

        transform.position = new Vector3(positionX, positionY, transform.position.z);
    }
}
