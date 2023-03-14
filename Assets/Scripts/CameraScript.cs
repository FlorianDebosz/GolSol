using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    [SerializeField] private float distance;
    private float x = 0f;
    private float y = 0f;
    private Quaternion rotation;
    private Touch touch;
    private Vector3 position;
    private float shift = 3f;
    // Start is called before the first frame update
    void Start()
    {
        x = transform.eulerAngles.y;
        y = transform.eulerAngles.x;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //PC
        #if UNITY_EDITOR || UNITY_STANDALONE
            x += Input.GetAxis("Mouse X") * 3;
        #endif


        //Mobile
        #if UNITY_ANDROID || UNITY_IPHONE
            if(Input.touches.length == 1){
                x += Input.GetTouch(0).deltaPosition.x * 0.1f;
          }
        #endif


        if(!EventSystem.current.IsPointerOverGameObject()){
            rotation = Quaternion.Euler(y,x,0);    
        }

        Vector3 position = rotation * new Vector3(0f, ball.transform.position.y / shift, -distance) + ball.transform.position;

        transform.position = position;
        transform.rotation = rotation;

        if(transform.position.y < 2.5f){
            transform.position = new Vector3(transform.position.x,2.5f,transform.position.z);
        }
    }
}
