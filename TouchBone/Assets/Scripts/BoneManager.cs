using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Eddie Brazier
 *TouchBone.exe
 */

public class BoneManager : MonoBehaviour
{
    //create static instance of this class
    public static BoneManager instance;

    //field for a list of bones
    public List<GameObject> boneList;

    // Start is called before the first frame update
    void Start()
    {
        //initialize static instance
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

        //initialize bone list
        //boneList = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        //explode the bones when space is pressed
        if(Input.GetKeyDown(KeyCode.Space))
        {
            foreach(GameObject bone in boneList)
            {
                //add explosive force
                bone.GetComponent<Rigidbody>().AddExplosionForce(500, gameObject.transform.position, 5f);
            }
        }
    }
}
