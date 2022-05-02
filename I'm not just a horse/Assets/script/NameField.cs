using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NameField : MonoBehaviour
{
    static string Name;
    [SerializeField]
    private TextMeshProUGUI playerName;

    void Update(){
        Name = playerName.text;
    }

}
