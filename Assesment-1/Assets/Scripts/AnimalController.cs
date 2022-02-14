using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalController : MonoBehaviour
{
    private bool IsParent=false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //this script use by animals to move forward
        if (IsParent == false)
        {
            transform.Translate(Vector3.right * 2f * Time.deltaTime);
        }
    
    }
    public void IsATTACHED(bool Isatt)
    {
        IsParent = Isatt;
    }
 
}
