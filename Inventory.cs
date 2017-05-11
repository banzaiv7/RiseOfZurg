using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/*
- attached to player
- keeps track of number of each item
*/
public class Inventory : MonoBehaviour 
{
	//collection
	public int crystals = 0;

	//search
	public int alien = 0;

	//activation
	public int redFuelRod = 0;
	public int greenFuelRod = 0;
	public int blueFuelRod = 0;
	public int yellowFuelRod = 0;

	//repair
	public int item1 = 0; //canister
	public int item2 = 0; //pump
	public int battery = 0;

	//revenge
	public int targetComponent = 0;
	public int laserComponent = 0;
	public int prismComponent = 0;
}