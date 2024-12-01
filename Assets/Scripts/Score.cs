using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private float score = 0;

    [SerializeField]private Text textScore;

    public void AddScore(float value){
        score += value;
    }

    private void Update(){
        textScore.text = "" + score;
    }
}
