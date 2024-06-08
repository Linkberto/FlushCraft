using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImage : MonoBehaviour
{
    public Image startingImage;
    public Sprite spriteOne;
    public Sprite spriteTwo;
    public Sprite spriteThree;
    public Sprite spriteFour;
    public int imageNumber = 0;
    public GameObject cutScene;
    public GameObject botaoDialogo;
    public GameObject dialogo;

  
    public void WhenButtonClicked()
    {

        imageNumber++;
        if (imageNumber == 1)
            startingImage.sprite = spriteOne;

        if (imageNumber == 2)
            startingImage.sprite = spriteTwo;

        if (imageNumber == 3)
            startingImage.sprite = spriteThree;

        if (imageNumber == 4)
        {
            startingImage.sprite = spriteFour;
            cutScene.SetActive(false);
            botaoDialogo.SetActive(true);
            dialogo.SetActive(true);
        }

    }
}
