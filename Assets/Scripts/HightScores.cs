using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using SaveAndLoad;

public class HightScores
{
    public static event System.Action<List<int>> ScoresLoadedEvent;

    private List<int> hightScores;

    public HightScores()
    {
        // Loading scores from file
        hightScores = SaveLoad.Load<List<int>>();
        
        // if file is empty or file not exist
        // crete new list
        if (hightScores == null)
            hightScores = new List<int>();
        else
            ScoresLoadedEvent?.Invoke(hightScores);
    }

    ~HightScores()
    {
        SaveLoad.Save<List<int>>(hightScores);
    }


    public void TryAddScore(int score)
    {
        hightScores.Add(score);

        hightScores = hightScores.OrderByDescending(x => x).Take(3).ToList();

        SaveLoad.Save<List<int>>(hightScores);
    }
}
