using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine;

public class notas : MonoBehaviour
{
    public TMP_Text Monedas;
    public GameObject coinText;
    public int coinsCount = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Nota"))
        {
            coinsCount++;
            Monedas.text = $"Puntos: {coinsCount}";
            GameObject texto = Instantiate(coinText);
            texto.transform.position = new Vector3(this.gameObject.transform.position.x, 1.251261f, this.gameObject.transform.position.z);
            Destroy(other.gameObject);
        }
    }


}