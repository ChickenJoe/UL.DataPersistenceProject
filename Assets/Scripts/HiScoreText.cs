using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiScoreText : MonoBehaviour
{
    public static HiScoreText Instance;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}