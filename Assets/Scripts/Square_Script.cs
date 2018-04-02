using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square_Script : MonoBehaviour {

    public bool occupied;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject chip = GameObject.Find(collider.name);
        chip.GetComponent<Move_Chip>().over_square = true;
        chip.GetComponent<Move_Chip>().square_touching_name = gameObject.name;
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        GameObject chip = GameObject.Find(collider.name);
        chip.GetComponent<Move_Chip>().over_square = false;
        chip.GetComponent<Move_Chip>().square_touching_name = null;
    }
}
