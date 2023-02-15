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

        if (Physics.Raycast(ray.origin, ray.direction * 10, out hitInfo, Mathf.Infinity, 1, QueryTriggerInteraction.Ignore))
        {
            GameObject buildPlace = hitInfo.collider.gameObject;

            if (currentBuildShip != null)
            {
                BuildShip(buildPlace);
            }
            else if (hitInfo.collider.gameObject.GetComponent<PlayerShip>())
            {
                SellShip(hitInfo.collider.gameObject);
            }  
        }

    }

    private void BuildShip(GameObject buildPlace)
    {
        if ( !buildPlace.GetComponentInChildren<PlayerShip>() && Energy.currentEnergy >= currentShipCost)
        {
       
            GameObject buildShip = Instantiate(currentBuildShip, buildPlace.transform.position, buildPlace.transform.rotation);

            buildShip.transform.parent = buildPlace.transform;

            Energy.ChangeEnergy(-currentShipCost);
         
        }
    }

    private void SellShip(GameObject shipToSell)
    {
        Destroy(shipToSell);
    }
}
