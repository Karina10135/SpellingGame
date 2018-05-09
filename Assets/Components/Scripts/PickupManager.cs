using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupManager : MonoBehaviour
{

    public Transform holdPos;
    public float maxDistance;


    public Image pick;
    public Image heldObj;

    [HideInInspector]
    public bool placeArea;
    bool holding;
    bool pickAxe;
    Color debugColor = Color.red;
    GameObject heldObject;

    private void Start()
    {
        pickAxe = true;
    }

    private void FixedUpdate()
    {
        if(GameManager.GM.inPlay == false) { return; }
        RaycastHit hit;
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        if(Physics.Raycast(ray, out hit, maxDistance))
        {
            if (hit.collider.gameObject.CompareTag("HitObject"))
            {

                debugColor = Color.green;
                if (Input.GetMouseButtonDown(0))
                {
                    if (!holding)
                    {
                        if(pickAxe == true)
                        {
                            Destroy(hit.collider.gameObject);

                        }
                    }

                }
            }



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


        //if (Input.GetKeyDown(KeyCode.Alpha1))
        //{
        //    if (holding) { return; }
        //    Select(1);
        //}
        

        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * 4, debugColor);
    }

    public void Select(int i)
    {
        if(i == 1)
        {
            pick.color = Color.white;
            heldObj.color = Color.gray;
            pickAxe = true;
        }

        if (i == 2)
        {
            pick.color = Color.gray;
            heldObj.color = Color.white;
            pickAxe = false;
        }
    }

    void Pickup(GameObject obj) //Pick up tagged object
    {
        pickAxe = false;
        pick.color = Color.gray;
        heldObject = obj;
        heldObject.GetComponent<Rigidbody>().isKinematic = true;
        heldObject.transform.parent = holdPos;
        heldObject.transform.position = holdPos.position;
        holding = true;
    }

    void Drop() //Simply drop held object.
    {
        pickAxe = true;
        pick.color = Color.white;
        print("<color=red>Dropped Object</color>");
        heldObject.GetComponent<Rigidbody>().isKinematic = false;
        heldObject.transform.SetParent(null);
        heldObject = null;
        holding = false;
    }

    void CheckLetterPlacement()
    {
        if (heldObject.GetComponent<LetterManager>().letter == WordManager.wordManager.currentLetter)
        {
            pick.color = Color.white;
            pickAxe = true;
            print("<color=green>Placed Object</color>");
            heldObject.GetComponent<Rigidbody>().isKinematic = false;
            heldObject.transform.SetParent(null);
            heldObject.GetComponent<LetterManager>().DestroyLetter();
            heldObject = null;
            holding = false;


            WordManager.wordManager.NextLetter();
        }
        else { Drop(); }
    }

    

}
