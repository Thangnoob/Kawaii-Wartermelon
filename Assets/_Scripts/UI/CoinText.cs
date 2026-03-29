using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinText : MonoBehaviour
{
    public void UpdateCoinText(string newCoinText) => GetComponent<TMPro.TextMeshProUGUI>().text = newCoinText;
}
