using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteractiveRayCast : MonoBehaviour//, IPointerClickHandler
{

    public GameObject obj;
    public GameObject obj2;
    InteractiveBoxItem thisBox;

    private IEnumerator onClickCustom() 
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit raycastHit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out raycastHit, 100f))
            {
                if (raycastHit.transform != null)
                {
                    if (raycastHit.transform.CompareTag("InteractivePlane"))
                    {
                        Instantiate(obj, raycastHit.point+ raycastHit.normal/2, new Quaternion());
                    }
                    if (raycastHit.transform.TryGetComponent<InteractiveBoxItem>(out InteractiveBoxItem boxItem))
                    {
                        if(thisBox == null)
                        {
                            thisBox = boxItem;
                        }
                        else
                        {
                            thisBox.gameObject.GetComponent<InteractiveBoxItem>().AddNext(boxItem);
                            thisBox = null;
                        }
                    }
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit raycastHit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out raycastHit, 100f))
            {
                if (raycastHit.transform != null)
                {
                    if (raycastHit.transform.CompareTag("InteractivePlane"))
                    {
                        Instantiate(obj2, raycastHit.point + raycastHit.normal / 2, new Quaternion());
                    }
                    if (raycastHit.transform.TryGetComponent<InteractiveBoxItem>(out InteractiveBoxItem boxItem))
                    {
                        if (thisBox == null)
                        {
                            thisBox = boxItem;
                        }
                        else
                        {
                            thisBox.gameObject.GetComponent<InteractiveBoxItem>().AddNext(boxItem);
                            thisBox = null;
                        }
                    }
                }
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit raycastHit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out raycastHit, 100f))
            {
                if (raycastHit.transform != null)
                {
                    if (raycastHit.transform.TryGetComponent<InteractiveBoxItem>(out InteractiveBoxItem boxItem))
                    {
                        Destroy(raycastHit.transform.gameObject);
                    }
                }
            }
        }
        yield return null;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(onClickCustom());
        //Check for mouse click 
        
    }
}
