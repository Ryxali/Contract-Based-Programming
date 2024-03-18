using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountTimer : MonoBehaviour
{
    private TMPro.TMP_Text text;

    private void Awake()
    {
        text = GetComponent<TMPro.TMP_Text>();
    }


    // Update is called once per frame
    void Update()
    {
        
        text.text = TimeSpan.FromSeconds(Time.time).ToString(@"mm\:ss");
    }
}
