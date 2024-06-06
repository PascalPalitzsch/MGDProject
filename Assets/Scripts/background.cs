using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    public Transform player; // Referenz auf den Spieler
    public float parallaxEffectMultiplierX = 0.5f; // Multiplikator für die horizontale Parallaxen-Bewegung

    private Vector3 lastPlayerPosition;

    void Start()
    {
        if (player == null)
        {
            player = Camera.main.transform; // Fallback auf die Kamera, falls kein Spieler zugewiesen ist
        }
        lastPlayerPosition = player.position;
    }

    void Update()
    {
        Vector3 deltaMovement = player.position - lastPlayerPosition;
        float parallaxX = deltaMovement.x * parallaxEffectMultiplierX;

        // Nur die horizontale Position beeinflussen
        transform.position += new Vector3(parallaxX, 0, 0);

        // Vertikale Position mit der des Spielers synchronisieren
        transform.position = new Vector3(transform.position.x, player.position.y, transform.position.z);

        lastPlayerPosition = player.position;
    }
}
