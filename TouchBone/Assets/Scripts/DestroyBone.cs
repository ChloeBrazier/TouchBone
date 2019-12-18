using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Eddie Brazier
 *TouchBone.exe
 */

public class DestroyBone : MonoBehaviour
{
    //field for bone prefab
    [SerializeField]
    private GameObject bone;

    //field for bone spawn location
    [SerializeField]
    private GameObject boneSpawn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        //remove bone from bone list
        BoneManager.instance.boneList.Remove(collision.gameObject);

        //destroy the bone
        Destroy(collision.gameObject);

        //spawn a new bone if none are left
        if (BoneManager.instance.boneList.Count == 0)
        {
            BoneSpawn.instance.SpawnBone();
        }
    }
}
