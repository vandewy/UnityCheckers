using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed_Script : MonoBehaviour {

    private Dictionary<string, string> dict = new Dictionary<string, string>();
    private string red_chip;
    private string black_chip;
    private string square;

    // Use this for initialization
    void Start () {
        for(int i = 1; i < 3; i++)
        {
            red_chip = "RedChip" + i.ToString();
            square = "Square" + i.ToString();
            GameObject.Find(red_chip).GetComponent<Move_Chip>().square_touching_name = square;
            GameObject.Find(square).GetComponent<Square_Script>().occupied = true;
        }
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
