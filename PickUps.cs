using UnityEngine;
using System.Collections;
/*
- attached to each pick up item
- checks the name of the object and increments number of item that corresponds to name of object
*/
public class PickUps : MonoBehaviour 
{
	string _name;

	void Start()
	{
		_name = this.gameObject.name; //sets the name to the object's name in the inspector
	}

	void PickUp()
	{
		Inventory inv = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
		//collection
		if (_name == "PowerCrystal") 
		{
			inv.GetComponent<Inventory> ().crystals++;
			Debug.Log ("Crystals: " + inv.GetComponent<Inventory> ().crystals); //translate to UI later
			Destroy (this.gameObject);
		}
		//activation
		else if(_name == "RedFuelRod")
		{
			inv.GetComponent<Inventory>().redFuelRod++;
			Debug.Log ("Red fuel rod");
			Destroy (this.gameObject);
		}
		else if(_name == "GreenFuelRod")
		{
			inv.GetComponent<Inventory>().greenFuelRod++;
			Debug.Log ("Green fuel rod");
			Destroy (this.gameObject);
		}
		else if(_name == "BlueFuelRod")
		{
			inv.GetComponent<Inventory>().blueFuelRod++;
			Debug.Log ("Blue fuel rod");
			Destroy (this.gameObject);
		}
		else if(_name == "YellowFuelRod")
		{
			inv.GetComponent<Inventory>().yellowFuelRod++;
			Debug.Log ("Yellow fuel rod");
			Destroy (this.gameObject);
		}
		//search
		else if (_name == "Alien") 
		{
			inv.GetComponent<Inventory> ().alien++;
			Debug.Log ("Aliens: " + inv.GetComponent<Inventory> ().alien);
			Destroy (this.gameObject);
		} 
		else if (_name == "Canister") 
		{
			inv.GetComponent<Inventory> ().item1++;
			Debug.Log ("Item1: " + inv.GetComponent<Inventory> ().item1);
			Destroy (this.gameObject);
		} 
		else if (_name == "Pump") 
		{
			inv.GetComponent<Inventory> ().item2++;
			Debug.Log ("Item2: " + inv.GetComponent<Inventory> ().item2);
			Destroy (this.gameObject);
		} 
		else 
		{
			Debug.Log ("Object name does not exist. Possible spelling error or the object was not defined.");
		}
	}

	/*
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") //checks if item makes contact with the player only
		{
			if (_name == "PowerCrystal") 
			{
				other.GetComponent<Inventory> ().crystals++;
				Debug.Log ("Crystals: " + other.GetComponent<Inventory> ().crystals); //translate to UI later
				Destroy (this.gameObject);
			}
			else if(_name == "RedFuelRod")
			{
				other.GetComponent<Inventory>().redFuelRod++;
				Debug.Log ("Red fuel rod");
				Destroy (this.gameObject);
			}
			else if(_name == "GreenFuelRod")
			{
				other.GetComponent<Inventory>().greenFuelRod++;
				Debug.Log ("Green fuel rod");
				Destroy (this.gameObject);
			}
			else if(_name == "BlueFuelRod")
			{
				other.GetComponent<Inventory>().blueFuelRod++;
				Debug.Log ("Blue fuel rod");
				Destroy (this.gameObject);
			}
			else if(_name == "YellowFuelRod")
			{
				other.GetComponent<Inventory>().yellowFuelRod++;
				Debug.Log ("Yellow fuel rod");
				Destroy (this.gameObject);
			}
			else if (_name == "Alien") 
			{
				other.GetComponent<Inventory> ().alien++;
				Debug.Log ("Aliens: " + other.GetComponent<Inventory> ().alien);
				Destroy (this.gameObject);
			} 
			else 
			{
				Debug.Log ("Object name does not exist. Possible spelling error or the object was not defined.");
			}
		} 
		else 
		{
			return; //does nothing if the player did not make contact with this object
		}
	}
	*/
}
