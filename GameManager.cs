using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class GameManager : MonoBehaviour
{
    List<Enemy> enemies = new List<Enemy>();

    private void Awake()
    {
        enemies = GameObject.FindObjectsOfType<Enemy>().ToList();

        if (enemies.Count <= 0)
        {
            SceneManager.LoadScene("Win");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Awake();
    }
}
