using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class ShipShop : MonoBehaviour
{
    public static GameObject currentBuildShip;
    public static float currentShipCost;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            MakeRay();
        }
    }

    private void MakeRay()
    {
        Touch touch = Input.GetTouch(0);

        Ray ray = Camera.main.ScreenPointToRay(touch.position);

        RaycastHit hitInfo;

        if (Physics.Raycast(ray.origin, ray.direction * 10, out hitInfo, Mathf.Infinity, 1, QueryTriggerInteraction.Ignore) && currentBuildShip != null)
        {
            GameObject buildPlace = hitInfo.collider.gameObject;

            BuildShip(buildPlace);

        }

    }

    private void BuildShip(GameObject buildPlace)
    {
        if (buildPlace.CompareTag("BuildPlace") && Energy.currentEnergy >= currentShipCost)
        {
       
            Instantiate(currentBuildShip, buildPlace.transform.position, buildPlace.transform.rotation);

            buildPlace.GetComponent<BoxCollider>().enabled = false;
            Energy.ChangeEnergy(-currentShipCost);
         
        }
    }
}
