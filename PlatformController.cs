using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public float speed;

    float rotateSpeed = 45;



    // Start is called before the first frame update
    void Start()
    {
        rotateSpeed = Random.Range(1,4) * 5;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.y += speed * Time.deltaTime;
        transform.position = pos;

        transform.Rotate(0,0,rotateSpeed * Time.deltaTime);
    }
}
