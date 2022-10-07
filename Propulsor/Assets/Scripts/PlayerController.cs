using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D body;
    Vector2 direction;

    [SerializeField]
    float impulse = 2f;

    [SerializeField]
    TextMeshProUGUI labelFuel;

    float actualFuel;

    [SerializeField]
    GameObject prefabParticles;

    [SerializeField]
    GameObject finalPartida;



        void Start()
    {
        body = GetComponent<Rigidbody2D>();
            
        actualFuel = 100f;

    }

    void Update()
    {
        direction.x = Input.GetAxis("Horizontal") * Time.deltaTime * impulse;
        direction.y = Input.GetAxis("Vertical") * Time.deltaTime * impulse;

        actualFuel = actualFuel - 0.5f * Time.deltaTime;
        labelFuel.text = actualFuel.ToString("00.00") + " %";

        if (actualFuel <= 0f)
        {
            finalPartida.SetActive(true);
            this.enabled = false;
            
        }

}

    private void FixedUpdate()
    {
        body.AddForce(direction, ForceMode2D.Impulse);

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Fuel" && actualFuel > 0.0f)
        {
            actualFuel += 10f;
            if (actualFuel > 100f)
            {
                actualFuel = 100f;
            }

            collision.GetComponent<AudioSource>().Play();

            collision.enabled = false;

            //Crear particulas
            Instantiate(prefabParticles, collision.transform.position, collision.transform.rotation);

            //Destruir
            Destroy(collision.gameObject, 0.5f);
        }
    }

    public void ClickEnBoton()
    {
        SceneManager.LoadScene("SampleScene");
    }
}


