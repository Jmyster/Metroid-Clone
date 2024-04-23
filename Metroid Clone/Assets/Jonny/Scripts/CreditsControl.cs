using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CreditsControl : MonoBehaviour
{
    public GameObject creditTxt;
    public GameObject _parent;
    // Start is called before the first frame update
    void Start()
    {
        LoopCredits();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnCreditText()
    {
        Instantiate(creditTxt, _parent.transform);
        yield return new WaitForSeconds(3.5f);
        LoopCredits();
    }
    private void LoopCredits()
    {
        StartCoroutine(SpawnCreditText());
    }
}
