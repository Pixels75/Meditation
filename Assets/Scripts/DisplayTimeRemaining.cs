using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayTimeRemaining : MonoBehaviour
{
    [SerializeField] GameObject player;

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerControl>().timeRemaining > 0)
            this.GetComponent<Text>().text = player.GetComponent<PlayerControl>().timeRemaining+"";
        else
            this.GetComponent<Text>().text = "";
    }
}
