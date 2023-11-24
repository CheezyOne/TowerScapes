using UnityEngine;
using UnityEngine.UI;
using System;
public class HighScoreInShop : MonoBehaviour
{
    public Text scoreText;
    private void Start()
    {
        scoreText.text = "<size=78>Best</size>:" + PlayerPrefs.GetInt("score");
    }
}
