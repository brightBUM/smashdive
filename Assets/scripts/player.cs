using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    Touch _touch;
    bool launched = false;
    [SerializeField] float speed = 2f;
    [SerializeField] float jumpforce;
    [SerializeField] Animator anim;
    [SerializeField] Rigidbody rb;
    [SerializeField] GameObject arrow;
    Vector3 direction;

    // Update is called once per frame
    void Update()
    {
        touchinput();
    }
    private void touchinput()
    {
        if (Input.touchCount > 0)
        {
            _touch = Input.GetTouch(0);
            if (!launched)
            {
                if(_touch.phase == TouchPhase.Began)
                {
                    anim.SetTrigger("aim");
                }
                else if (_touch.phase == TouchPhase.Moved || _touch.phase == TouchPhase.Stationary)
                {
                    direction = transform.up;
                    //aiming
                }
                else if (_touch.phase == TouchPhase.Ended)
                {
                    //launch.
                    arrow.SetActive(false);
                    rb.AddForce(direction*jumpforce, ForceMode.Impulse);
                    //change state to launched
                    anim.SetTrigger("jump");
                    launched = true;
                }
            }
            else if(launched)
            {
                if (_touch.phase == TouchPhase.Moved || _touch.phase == TouchPhase.Stationary)
                {
                    //tuck
                    anim.SetBool("tuck", true);
                }
                else if (_touch.phase == TouchPhase.Ended)
                {
                    //stretched
                    anim.SetBool("tuck", false);
                }
            }

        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if(other.collider.CompareTag("Ground"))
        {
            rb.isKinematic = true;
        }
    }
    private void touchinputwithoutanim()
    {
        if (Input.touchCount > 0)
        {
            _touch = Input.GetTouch(0);
            if (!launched)
            {
                if (_touch.phase == TouchPhase.Began)
                {
                    anim.SetTrigger("aim");
                }
                if (_touch.phase == TouchPhase.Moved || _touch.phase == TouchPhase.Stationary)
                {
                    direction = transform.up;
                    //aiming
                    //transform.rotation = Quaternion.Slerp(new Quaternion(0, 0, 0, 0), new Quaternion(25, 0, 0, 0), aimspeed*Time.deltaTime);
                    //transform.Rotate(new Vector3())
                }
                if (_touch.phase == TouchPhase.Ended)
                {
                    arrow.SetActive(false);
                    rb.AddForce(direction * jumpforce, ForceMode.Impulse);
                    //launch.
                    //change state to launched
                    anim.SetTrigger("jump");
                    launched = true;
                }
            }
            else if (launched)
            {
                if (_touch.phase == TouchPhase.Moved || _touch.phase == TouchPhase.Stationary)
                {
                    anim.SetTrigger("tuck");
                    //aiming
                }
                if (_touch.phase == TouchPhase.Ended)
                {
                    
                    //stretched
                    Debug.Log("stretched");
                }
            }

        }
    }







}
