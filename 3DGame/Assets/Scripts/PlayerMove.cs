using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    [SerializeField] private float _speed;
    private float _oldMousePositionX;
    private float _rotationY;
    [SerializeField] private Animator _animator;
   
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _oldMousePositionX = Input.mousePosition.x;
            _animator.SetBool("Run", true);
           
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 newPosition = transform.position + transform.forward * _speed * Time.deltaTime;
            newPosition.x = Mathf.Clamp(newPosition.x, -2.7f, 2.7f);
            transform.position = newPosition;
            var deltaX = Input.mousePosition.x - _oldMousePositionX;
            _oldMousePositionX = Input.mousePosition.x;

            _rotationY = deltaX;
            _rotationY = Mathf.Clamp(_rotationY, -90, 90);
            transform.eulerAngles = new Vector3(0, _rotationY, 0);
         
        }

        if (Input.GetMouseButtonUp(0))
        {
            _animator.SetBool("Run", false);
        }
    }

}

