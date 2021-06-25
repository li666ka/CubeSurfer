using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ColliderRotate")
        {
            Destroy(other.gameObject);
            transform.Rotate(transform.rotation.x, transform.rotation.y + 90, transform.rotation.z, Space.Self);
        }
    }

    public GameObject platformFirst;

    private Rigidbody rigidbody;
    private Touch touchPast;
    

    [SerializeField] private float speedOfTouch;
    [SerializeField] private float speedOfMove;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        
    }

    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * Time.fixedDeltaTime * speedOfMove);

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    touchPast = touch;
                    break;

                case TouchPhase.Moved:

                    if (touch.position.x - touchPast.position.x > 0)
                    {
                        if (transform.localRotation.eulerAngles.y % 180 == 0)
                        {
                            rigidbody.velocity = Vector3.right * speedOfTouch;
                        }
                        else
                        {
                            rigidbody.velocity = -Vector3.forward * speedOfTouch;
                        }
                    }
                    else if (touch.position.x - touchPast.position.x < 0)
                    {
                        if (transform.localRotation.eulerAngles.y % 180 == 0)
                        {
                            rigidbody.velocity = Vector3.left * speedOfTouch;
                            
                        }
                        else
                        {
                            rigidbody.velocity = Vector3.forward * speedOfTouch;
                        }

                    }
                    touchPast = touch;
                    break;

                case TouchPhase.Stationary:
                    rigidbody.velocity = Vector3.zero;
                    break;
                case TouchPhase.Ended:
                    rigidbody.velocity = Vector3.zero;
                    break;
            }
        }
    }
}
