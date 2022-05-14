using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target, target2;
    public GameObject playeractive;
    public float smoothing;
    public Vector2 maxPosition;
    public Vector2 minPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(transform.position != target.position)
        {
            if (playeractive.activeSelf)
            {
                Vector3 targetposition = new Vector3(target.position.x,
                target.position.y,
               transform.position.z);
            targetposition.x = Mathf.Clamp(targetposition.x,
                minPosition.x,
                maxPosition.x);

            targetposition.y = Mathf.Clamp(targetposition.y,
                minPosition.y,
                maxPosition.y);
            transform.position = Vector3.Lerp(transform.position, targetposition, smoothing);
            }
            else
            {
                Vector3 targetposition = new Vector3(target2.position.x,
               target2.position.y,
              transform.position.z);
                transform.position = Vector3.Lerp(transform.position, targetposition, smoothing);
            }
        }
    }
}
