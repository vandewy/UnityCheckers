using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rule_Enforcer : MonoBehaviour {

    public int[,] moves;
    public Dictionary<int, List<int>> dict_moves;

    void Start()
    {
        moves = new int[33, 33];

        int right_edge = 4;
        int left_edge = 5;
        dict_moves = new Dictionary<int, List<int>>();

        for(int i = 1; i < 29; i++)
        {
            if (i == right_edge)
            {
                dict_moves.Add(i, new List<int> { i + 4 });
                right_edge += 4;
            }else if(i == left_edge)
            {
                dict_moves.Add(i, new List<int> { i + 4 });
                left_edge += 4;
            }else
            {
                dict_moves.Add(i, new List<int> { i + 4, i + 5 });
            }
        }

        print(dict_moves[6]);
    }
}
