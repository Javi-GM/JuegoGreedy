using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GreedyMovement : MonoBehaviour
{
    CharacterController characterController;

    public GreedyGameManager GGM;
    public Timer timer;
    public PauseMenu pause;

    public float speed = 6.0f;
    public float freq = 10f;
    public GameObject Model;
    public float deltatime = 0;
    public Text textCalorias;
    private int calorias;
    public Text numberOfLifesRestingText;
    public int puntuacionMinima;
    private int numberOfLifes;
    private float currentHealth;
    public Slider HealthSlider;
    private bool isNewGame = true;
    private int caloriasCurar = 0;
    private Vector3 moveDirection = Vector3.zero;

    //public float inmunity = 0;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        textCalorias.text = "Calorías: " + 0.ToString();
        setInitialNumberOfLifes(GGM.getVidas());
        setCurrentHealth();
        NewGame();
        HealthSlider.value = 100f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateCaloriesUI();
        setCurrentHealth();
        UpdateNumberOfLifesUI();
        curarCalorias();

        //if (Model.transform.position.y > 0.6) { Model.transform.position = new Vector3(Model.transform.position.x, 0.6f, Model.transform.position.z); }

        moveDirection = new Vector3();
        moveDirection = Input.GetAxis("Horizontal")==0 ? moveDirection : new Vector3(Mathf.Sign(Input.GetAxis("Horizontal")),0,0);
        moveDirection = Input.GetAxis("Vertical") == 0 ? moveDirection : new Vector3(0,0,Mathf.Sign(Input.GetAxis("Vertical")));
        moveDirection *= speed;

        if (deltatime >= freq && (Input.GetAxis("Horizontal")!=0 || Input.GetAxis("Vertical") != 0))
        {
            //if (moveDirection.z < 0){ Model.transform.localRotation=new Quaternion(0,1,0,0); }
            //if (moveDirection.z > 0) { Model.transform.localRotation = new Quaternion(0, 0, 0, 0); }
            //if (moveDirection.x > 0) { Model.transform.localRotation = new Quaternion(0, 0.7f, 0, 0.7f); }
            //if (moveDirection.x < 0) { Model.transform.localRotation = new Quaternion(0, -0.7f, 0, 0.7f); }
            // Move the controller
            characterController.Move(moveDirection);
            deltatime -=freq;
            //Debug.Log(moveDirection);
        }

        //Debug.Log(Model.transform.localRotation);
        deltatime += Time.deltaTime;
        deltatime = Mathf.Min(freq, deltatime);
        //inmunity = Mathf.Max(0, inmunity - Time.deltaTime);

        if (currentHealth == 0 && IsNewGame()) {
            Fail();
            HealthSlider.value = 100;
            currentHealth = 100;
        }
        if (numberOfLifes <= 0)
        {
            SceneManager.LoadScene("Game Over");
        }
        if(calorias >= puntuacionMinima && GGM.getNivel() != 3)
        {
            GGM.setNivel(GGM.getNivel() + 1);
            GGM.setPuntuacion(GGM.getPuntuacion() + calorias + timer.getTime());
            GGM.setVidas(numberOfLifes);
            GGM.savePlayerData();
            pause.Victoria();
        }
        if (calorias >= puntuacionMinima && SceneManager.GetActiveScene().buildIndex == 3)
        {
            SceneManager.LoadScene("Victory");
        }
    }

    public bool IsNewGame() {
        return isNewGame;
    }

    void NewGame() {
        isNewGame = true;
    }

    void EndGame() {
        isNewGame = false;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SmallCarrot"))
        {
            other.gameObject.SetActive(false);
            calorias += 10;
            caloriasCurar += 10;
        }

        if (other.gameObject.CompareTag("MediumCarrot"))
        {
            other.gameObject.SetActive(false);
            calorias += 20;
            caloriasCurar += 20;
        }

        if (other.gameObject.CompareTag("BigCarrot"))
        {
            other.gameObject.SetActive(false);
            calorias += 30;
            caloriasCurar += 30;
        }

        if (other.gameObject.CompareTag("SmallBanana"))
        {
            other.gameObject.SetActive(false);
            calorias += 5;
            caloriasCurar += 5;
        }

        if (other.gameObject.CompareTag("MediumBanana"))
        {
            other.gameObject.SetActive(false);
            calorias += 10;
            caloriasCurar += 10;
        }

        if (other.gameObject.CompareTag("BigBanana"))
        {
            other.gameObject.SetActive(false);
            calorias += 15;
            caloriasCurar += 15;
        }
        if (other.gameObject.CompareTag("Granada"))
        {
            other.gameObject.SetActive(false);
            Fail();
        }
    }

    void UpdateCaloriesUI()
    {
        textCalorias.text = "Calorías: " + calorias.ToString();
    }

    public void UpdateNumberOfLifesUI() {
        numberOfLifesRestingText.text = "x " + numberOfLifes.ToString();
    }

    /*public void GhostHit()
    {
        if (inmunity <= 0)
        {
            HealthSlider.value = 0;
            inmunity = 2;
        }
    }*/

    /*public void SubstractLife() {
        if (inmunity <= 0)
        {
            numberOfLifes -= 1;
            Debug.Log(numberOfLifes+" "+inmunity);
            HealthSlider.value = 100;
            currentHealth = 100;
            inmunity = 2;
        }
    }*/

    public void AddLife(int n) {
        numberOfLifes += n;
    }

    public void setInitialNumberOfLifes(int lifes) {
        numberOfLifes = lifes;
        UpdateNumberOfLifesUI();
    }

    public void setCurrentHealth() {
        currentHealth = HealthSlider.value;
    }

     public void curarCalorias()
    {
        if (caloriasCurar >= 100)
        {
            HealthSlider.value += 10f;
            caloriasCurar -= 100;
        }
    }

    public void Fail()
    {
        GGM.setVidas(GGM.getVidas() - 1);
        GGM.savePlayerData();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
