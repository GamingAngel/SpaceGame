using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipToBuy : MonoBehaviour
{
    [SerializeField] private GameObject shipToBuy;
    [SerializeField] private float shipToBoyCost;

    public void SelectShip()
    {
        ShipShop.currentBuildShip = shipToBuy;
        ShipShop.currentShipCost = shipToBoyCost;
    }
}
