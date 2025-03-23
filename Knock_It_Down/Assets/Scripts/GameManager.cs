using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;  //Bu sayede diger siniflardan erisim saglayacagiz
    public GameObject ball;
    public Transform target; // Şu anki hedef küp (merkezde duran)
    public Transform[] cylinders; // Silindirlerin transformları
    public GameObject[] canSetGRP; //**************************
    public GameObject[] allLevels;
    public Ball ballScript;
    public int currentLevel;
    public float ballForce;
    public bool readyToShoot;
    public bool gameHasStarted;
    public int totalBalls;
    
    private bool isDragging = false;
    Plane plane = new(Vector3.back, 0); // Fare ile kontrol için düzlem


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    void Start()
    {

    }

    public void StartGame()
    {
        gameHasStarted = true;
        readyToShoot = true;
    }

    void Update()
    {
        // Şu anki hedef küpün pozisyonuna göre yön hesaplanıyor
        Vector3 dir = target.position - ball.transform.position;


        // Mouse ile tıklama animasyonu durdurur ve topu kontrol etmeye başlarız
        if (Input.GetMouseButtonDown(0) && readyToShoot)
        {
            ball.GetComponent<Animator>().enabled = false;
            isDragging = true;
        }



        // Mouse bırakıldığında atış gerçekleşir
        if (Input.GetMouseButtonUp(0) && isDragging && readyToShoot)
        {
            isDragging = false;

            // Dinamik hedef belirleme: Silindirlerden hangisi daha yakınsa onu hedef alacağız
            Transform closestCylinder = GetClosestCylinder();

            // Eğer yakın bir silindir bulunduysa, ona yönelme işlemi yap
            if (closestCylinder != null)
            {
                dir = closestCylinder.position - ball.transform.position;
            }

            // Topu belirlenen yöne doğru fırlat
            ball.GetComponent<Rigidbody>().AddForce(dir.normalized * ballForce, ForceMode.Impulse);

            //Bunu yaparak topun atildiktan sonr atekrardan bize dogru gelmesini onlemis olduk
            //Eger readyToShoot yazilmasaydi topu attiktan sonra havadayken bir daha hareket ettirebilirdik
            readyToShoot = false;

            UIManager.instance.UpdateBallIcons();

            totalBalls--;

            if (totalBalls <= 0)
            {
                print ("Game Over");
            }

        }




        // Fare imlecinin ekran sınırları içinde olup olmadığını kontrol et
        if (Input.mousePosition.x >= 0 && Input.mousePosition.x <= Screen.width && Input.mousePosition.y >= 0 && Input.mousePosition.y <= Screen.height)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (plane.Raycast(ray, out float dist))
            {
                Vector3 point = ray.GetPoint(dist);
                float zPos = Camera.main.WorldToScreenPoint(ball.transform.position).z;
                Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, zPos));

                // Topun X eksenini sadece fare hareketine göre güncelle
                ball.transform.position = new Vector3(worldMousePos.x, ball.transform.position.y, ball.transform.position.z);
            }
        }
    }



    // Silindirlerden topa en yakın olanını bulur
    Transform GetClosestCylinder()
    {
        Transform closest = null;
        //Mathf.Infinity yapılarak sonsuz bir mesfae belirtmiş oluruz.
        float minDistance = Mathf.Infinity;

        //Her blok karşılaştırılarak en yakın mesafe bulunur, daha sonrasında ise minDistance olarak değişrir.
        //Bu sayede vurulacak kısım belirtilmiş olunur.
        foreach (Transform cylinder in cylinders)
        {
            //x, y ve z koordinatlarıyla mesafe hesaplanir, daha sonrasinda ise minDistance ile karşılaştırılır
            float distance = Vector3.Distance(ball.transform.position, cylinder.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                closest = cylinder;
            }
        }
        return closest;
    }


    public void GroundFallenCheck()
    {
        if (AllGrounded())
        {
            print("Load Next Level");
            //LoadNextLevel();
        }
    }

    bool AllGrounded()
    {
        Transform currentSet = canSetGRP[currentLevel].transform;

        foreach (Transform t in currentSet)
        {
            if(t.GetComponent<Can>().hasFallen == false)
            {
                return false;
            }
        }

        return true;
    }

    /*public void LoadNextLevel()
    {
        if (gameHasStarted)
        {
            StartCoroutine(LoadNextLevelRoutine());
        }
    }*/

    /*IEnumerator LoadNextLevelRoutine()
    {
        Debug.Log("Loading Next Level");
        yield return new WaitForSeconds(1.5f);
        UIManager.instance.ShowBlackFade();
        readyToShoot = false;
        allLevels[currentLevel].SetActive = false;
        currentLevel++;

        if(currentLevel > allLevels.length)
        {
            currentLevel = 0;
        }

        yield return new WaitForSeconds(1.0f);
        allLevels[currentLevel].SetActive = true;
        UIManager.instance.UpdateBallIcons();
        ballScript.RepositionBall();
    }*/


}






