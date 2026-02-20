using UnityEngine;
using UnityEngine.UI;

public class BarreDeVie : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxHealth (int health) //Permet de mettre la vie au max au début de la partie 
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f); //La couleur de la barre de vie est égale à notre gradient (la valeur 100% donc le vert)
    }

    public void SetHealth (int health)   //Sert à indiquer la vie 
    {
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue); //La couleur de la barre de vie est égale au gradient, la valeur du slider normalisé 
    }
}
