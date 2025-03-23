using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Vector3 spwanPos;

    private void Start()
    {
        spwanPos = transform.position;
    }

    //Tekrardan topun gelmesi saglaniyor
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Resetter"))
        {
            RepositionBall();
        }
    }

    public void RepositionBall()
    {
        this.gameObject.SetActive(false);
        transform.position = spwanPos;
        this.GetComponent<Animator>().enabled = true; //topu firlattiktan sonra
        gameObject.SetActive(true);

        //StartCoroutine ile belli bir sure bekledikten sonra SetReadyToShoot fonksiyonun calismasini sagladik.
        //Eger yazmsaydik direkt olarak calisip 2 saniye beklemezdi.
        StartCoroutine(SetReadyToShoot());
    }

    IEnumerator SetReadyToShoot()
    {
        yield return new WaitForSeconds(2.00f);
        GameManager.instance.readyToShoot = true;
    }
}
