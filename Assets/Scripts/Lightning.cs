
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{
    [SerializeField] float timeToLightning;
    [SerializeField] float LightningMin;
    [SerializeField] float LightningMax;
    [SerializeField] int timeToThunder;
    [SerializeField] GameObject player;
    [SerializeField] SpriteRenderer lightningImage; // Using SpriteRenderer for the lightning flash

    float lightningTimer;
    float timer;
    bool struck;
    // Start is called before the first frame update
    void Start()
    {
        // Set the initial lightning timer
        lightningTimer = timeToLightning + Random.Range(LightningMin, LightningMax);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        // If it's time for lightning to strike
        if (timer > lightningTimer)
        {
            // Flash the lightning
            Color flashColor = lightningImage.color;
            flashColor.a = 1f;
            lightningImage.color = flashColor;

            if(!struck)
            {
                player.GetComponent<PlayerControl>().StartCountdown(timeToThunder);
                struck = true;
            }
            
            
        }

        
        if (timer > lightningTimer + 0.5f)
        {
            // Hide the lightning flash
            Color flashColor = lightningImage.color;
            flashColor.a = 0f;
            lightningImage.color = flashColor;
            struck = false;
            // Reset the timer for the next lightning strike
            lightningTimer = Random.Range(LightningMin, LightningMax);
            timer = 0; // Reset the timer
        }
    }
}
