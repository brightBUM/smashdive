using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchRagdoll : MonoBehaviour
{
    [SerializeField] Rigidbody[] mainbones;
    [SerializeField] Rigidbody[] ragbones;
    Quaternion[] mainrotations;
    Quaternion[] ragrotations;
    [SerializeField] GameObject originalmesh;
    [SerializeField] GameObject ragdollref;

    Vector3 hippos;
    public Transform hip;

    [SerializeField] Animator anim;

    bool activateragdoll;
    public float rotationspeed = 3;
    public float movementspeed = 0.33f;

    // Start is called before the first frame update
    void Start()
    {
        mainbones = GetComponentsInChildren<Rigidbody>();
        ragbones = ragdollref.GetComponentsInChildren<Rigidbody>();
        ragrotations = new Quaternion[ragbones.Length];
    }

    public void enableragdoll()
    {
        updateragdollbones();
        activateragdoll = true;
        anim.enabled = false;
        originalmesh.SetActive(false);
        ragdollref.SetActive(true);
    }
    public void disableragdoll()
    {
        ragdollref.SetActive(false);
        anim.enabled = true;
        originalmesh.SetActive(true);
        
    }
    //IEnumerator toggleanimator(bool actv, float time)
    //{
    //    yield return new WaitForSeconds(time);
    //    anim.enabled = actv;
    //}
    public void updateragdollbones()
    {
        hippos = transform.position;
        hippos.y = hip.position.y;
        for (int i = 0; i < mainrotations.Length; i++)
        {
            ragbones[i].transform.rotation = mainbones[i].transform.rotation;
        }
    }
    //private void FixedUpdate()
    //{
    //    if (activateragdoll)
    //    {
    //        for (int i = 0; i < mainbones.Length; i++)
    //        {
    //            if (bones[i].isKinematic)
    //            {
    //                bones[i].isKinematic = false ;
    //            }
    //        }
    //    }
    //    else
    //    {
    //        for (int i = 0; i < bones.Length; i++)
    //        {
    //            if (bones[i].isKinematic)
    //            {
    //                bones[i].isKinematic = true;
    //            }
    //            bones[i].transform.rotation = Quaternion.Lerp(bones[i].transform.rotation, rotations[i], Time.deltaTime * rotationspeed);
    //            hip.position = Vector3.MoveTowards(hip.position, hippos, Time.deltaTime * movementspeed);
    //        }

    //    }
    //}
}
