using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HeartSystem : MonoBehaviour
{
    public int vida;
    public int vidaMaxima;
    public Image[] coracao;
    public Sprite cheio;
    public Sprite vazio;
    
    // Start is called before the first frame update
    void Start()
    {
    }

        void Update() 
    {
        HealtLogic();
    }


    void HealtLogic()
    {
        if (vida > vidaMaxima)
        {
            vida = vidaMaxima;
        }

        for (int i = 0; i < coracao.Length; i++) 
        {
            if (i < vida) 
            {
                coracao[i].sprite = cheio;
            } 

            else 
            {
                coracao[i].sprite = vazio;

            }

            if (i < vidaMaxima) {
                coracao[i].enabled = true;
            } 

            else 
            {
                coracao[i].enabled = false;
            }

            if (coracao[0].sprite == vazio)
            {
                SceneManager.LoadScene("GameOver");
            }
        }
    }
}