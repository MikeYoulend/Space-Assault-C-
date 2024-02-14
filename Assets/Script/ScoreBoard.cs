using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl; //stiamo usando TextMeshPro

public class ScoreBoard : MonoBehaviour
{
   int score;
   TMP_Text scoreText; //Assegniamo TMP_Text;

   void Start() 
   {
      scoreText = GetComponent<TMP_Text>();
      scoreText.text = "Start";
   }

 

   public void IncreaseScore(int amountToIncrease)
   {
     score += amountToIncrease; //score = score + amountToIncrease;
     scoreText.text = score.ToString(); //prendiamo lo start di sopra e gli assegniamo score.tostring() per farlo trasformare nel punteggio
   }
}
