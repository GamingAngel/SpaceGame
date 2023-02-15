using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
[ExecuteInEditMode]
public class Level : MonoBehaviour
{
   
    [SerializeField] private TMP_Text[] text;


    void Start()
    {
        for (int i = 0; i < text.Length; i++)
        {
            Debug.Log(i);
            text[i].text = $"{i+1}";
        }
    }


}
