using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockdestroy : MonoBehaviour
{
    [SerializeField] GameObject vfx;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var temp = Instantiate(vfx, other.transform.position - new Vector3(0, 0.5f, 0), Quaternion.identity);
            Destroy(temp, 2f);
            Destroy(this.gameObject);

        }
    }
}
