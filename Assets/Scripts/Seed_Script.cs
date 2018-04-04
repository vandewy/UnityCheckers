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
        int row_counter = 1;
        int row_num = 1;
        for(int i = 1; i < 13; i++)
        {
            red_chip = "RedChip" + i.ToString();
            square = "Square" + i.ToString();
            GameObject.Find(red_chip).GetComponent<Move_Chip>().square_touching_name = square;
            GameObject.Find(red_chip).GetComponent<Move_Chip>().origin = GameObject.Find(square);
            GameObject.Find(square).GetComponent<Square_Script>().occupied = true;
            GameObject.Find(square).GetComponent<Square_Script>().square_number = i;
            GameObject.Find(square).GetComponent<Square_Script>().row_number = row_num;
            row_counter += 1;
            if (row_counter > 4)
            {
                row_num += 1;
                row_counter = 1;
            }
        }
        for(int i = 13; i < 21; i++)
        {
            square = "Square" + i.ToString();
            GameObject.Find(square).GetComponent<Square_Script>().occupied = false;
            GameObject.Find(square).GetComponent<Square_Script>().square_number = i;
            GameObject.Find(square).GetComponent<Square_Script>().row_number = row_num;
            row_counter += 1;
            if (row_counter > 4)
            {
                row_num += 1;
                row_counter = 1;
            }
        }
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
