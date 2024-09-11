using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
public class DisplayScore : MonoBehaviour
{
    [SerializeField] GameObject player;

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Text>().text = "Score: " + player.GetComponent<PlayerControl>()._score;
    }
}
