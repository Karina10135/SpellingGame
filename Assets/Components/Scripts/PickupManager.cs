using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupManager : MonoBehaviour
{

    public GameObject heldObject;
    public Transform holdPos;
    public bool holding;
    public float maxDistance;
    Color debugColor = Color.red;
    public bool placeArea;

    private void FixedUpdate()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        if(Physics.Raycast(ray, out hit, maxDistance))
        {
            if (hit.collider.gameObject.CompareTag("Object"))
            {
                debugColor = Color.green;

                if (Input.GetMouseButtonDown(0))
                {
                    if (!holding)
                    {
                        Pickup(hit.collider.gameObject);
                        return;
                    }

                }
            }
            
        }
        else debugColor = Color.red;

        if (Input.GetMouseButtonDown(0))
        {
            

            if (holding)
            {

                if (placeArea)
                {
                    CheckLetterPlacement();
                }
                else
                {
                    Drop();
                    return;
                }
                
            }

        }


        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * 4, debugColor);
    }

    void Pickup(GameObject obj) //Pick up tagged object
    {
        heldObject = obj;
        heldObject.GetComponent<Rigidbody>().isKinematic = true;
        heldObject.transform.parent = holdPos;
        heldObject.transform.position = holdPos.position;
        holding = true;
    }

    void Drop() //Simply drop held object.
    {
        print("<color=red>Dropped Object</color>");
        heldObject.GetComponent<Rigidbody>().isKinematic = false;
        heldObject.transform.SetParent(null);
        heldObject = null;
        holding = false;
    }

    void CheckLetterPlacement()
    {
        print("checking letter");
        print(heldObject.GetComponent<LetterManager>().letter);
        print(WordManager.wordManager.currentLetter);
        if (heldObject.GetComponent<LetterManager>().letter == WordManager.wordManager.currentLetter)
        {
            print("<color=green>Placed Object</color>");
            heldObject.GetComponent<Rigidbody>().isKinematic = false;
            heldObject.transform.SetParent(null);
            heldObject = null;
            holding = false;


            WordManager.wordManager.NextLetter();
        }
        else { Drop(); }
    }

    

}
