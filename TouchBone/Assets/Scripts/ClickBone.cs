using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Eddie Brazier
 *TouchBone.exe
 */

public class ClickBone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //send out a raycast from the mouse when the player clicks the left mouse button
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //send ray
            Ray clickRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            //draw ray for debug
            Debug.DrawRay(clickRay.origin, clickRay.direction * 100, Color.green);

            //raycast with the ray
            Physics.Raycast(clickRay.origin, clickRay.direction, out RaycastHit hit, Mathf.Infinity);

            //check if the bone was hit
            if (hit.transform != null && hit.transform.gameObject == this.gameObject)
            {
                //RATTLE THAT BONE
                gameObject.GetComponent<Rigidbody>().AddForce(0, 50, 0);
                gameObject.transform.Rotate(Random.Range(-10, 10), 0, 0);
            }
        }

        //send out a raycast from the mouse when the player clicks the left mouse button
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            //send ray
            Ray clickRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            //draw ray for debug
            Debug.DrawRay(clickRay.origin, clickRay.direction * 100, Color.green);

            //raycast with the ray
            Physics.Raycast(clickRay.origin, clickRay.direction, out RaycastHit hit, Mathf.Infinity);

            //check if the bone was hit
            if (hit.transform != null && hit.transform.gameObject == this.gameObject)
            {
                //push the bone
                gameObject.GetComponent<Rigidbody>().AddForce(0, 0, 100);
            }
        }
    }
}
