using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryManager : MonoBehaviour
{
    public static Story GetStartingStory()
    {
        Story story = new Story();
        story.Text = "¡Bienvenido a la aventura! Comencemos creando a tu personaje.";

        Player player = new Player();

        int remainingPoints = 100;
        int maxStrength = remainingPoints;
        int maxDexterity = remainingPoints;
        int maxHealth = remainingPoints;

        player.playerName = "Nombre del Jugador";

        while (remainingPoints > 0)
        {
            story.Text += $"\n\nTienes {remainingPoints} puntos restantes para distribuir. Elige una opción:";
            story.options.Add(new LogOption($"Aumentar fuerza (Max {maxStrength})", 1, 0, 0, player));
            story.options.Add(new LogOption($"Aumentar destreza (Max {maxDexterity})", 0, 1, 0, player));
            story.options.Add(new LogOption($"Aumentar vida (Max {maxHealth})", 0, 0, 1, player));

            remainingPoints--;

            maxStrength = Mathf.Max(remainingPoints, maxStrength - 1);
            maxDexterity = Mathf.Max(remainingPoints, maxDexterity - 1);
            maxHealth = Mathf.Max(remainingPoints, maxHealth - 1);
        }

        story.nextStory = new Story("¡Personaje creado! Ahora comienza tu aventura.");

        return story;
    }
}
