using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Eddie Brazier
 *TouchBone.exe
 */

public class BoneSpawn : MonoBehaviour
{
    //create static instance of this class
    public static BoneSpawn instance;

    //field for bone prefab
    [SerializeField]
    private GameObject bone;

    //field for bone spawn location
    [SerializeField]
    private GameObject boneSpawn;

    //fields for bone spawn cooldown
    private float baseSpawnSpeed = 1;
    private float spawnTier;
    private float spawnSpeed;

    //field for bone spawn bool
    private bool canSpawn = true;

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

        //initialize spawn speed floats
        spawnSpeed = baseSpawnSpeed;
        spawnTier = baseSpawnSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.B))
        {
            if(canSpawn == true)
            {
                //spawn the bone
                SpawnBone();

                //decrement spawn speed tier
                spawnTier -= 0.07f;

                //set canspawn bone to false
                canSpawn = false;
            }
            else
            {
                //decrement spawn cooldown
                spawnSpeed -= 1 * Time.deltaTime;

                //check if spawn speed has fully decremented
                if(spawnSpeed <= 0)
                {
                    //set new spawn speed
                    spawnSpeed = spawnTier;

                    //set canSpawn to true
                    canSpawn = true;
                }
            }
        }

        //reset bone spawn cooldown when B key is released
        if(Input.GetKeyUp(KeyCode.B))
        {
            spawnSpeed = baseSpawnSpeed;
            spawnTier = baseSpawnSpeed;

            //reset canSpawn to true
            canSpawn = true;
        }
    }

    public void SpawnBone()
    {
        //create semi-random spawn vector
        Vector3 spawnVector = new Vector3(boneSpawn.transform.position.x + Random.Range(-0.3f, 0.3f), boneSpawn.transform.position.y, boneSpawn.transform.position.z + Random.Range(-0.5f, 0.5f));

        //spawn a new bone and add it to the bone list
        GameObject newBone = Instantiate(bone, spawnVector, Quaternion.identity);
        BoneManager.instance.boneList.Add(newBone);

        //rotate bone
        newBone.transform.Rotate(0, 90, 0);
    }
}
