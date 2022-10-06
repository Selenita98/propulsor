using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
    TextMeshProUGUI 



    void Start()
    {
        body = GetComponent<Rigidbody2D>();
            
        actualFuel = 1f;

    }

    void Update()
    {
        direction.x = Input.GetAxis("Horizontal") * Time.deltaTime * impulse;
        direction.y = Input.GetAxis("Vertical") * Time.deltaTime * impulse;

        actualFuel = actualFuel - 0.5f * Time.deltaTime;
        labelFuel.text = actualFuel.ToString("00.00") + " %";

        if (actualFuel <= 0f)
        {
            this.enabled = false;
            youDied.SetActive(true);
            textyouDied.text =
        }

}

    private void FixedUpdate()
    {
        body.AddForce(direction, ForceMode2D.Impulse);

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Fuel")
        {
            actualFuel += 10f;
            if (actualFuel > 100f)
            {
                actualFuel = 100f;
            }
            Destroy(collision.gameObject);

            //Crear particulas
            Instantiate(prefabParticles, collision.transform.position, collision.transform.rotation);

            //Destruir
            Destroy(collision.gameObject);
        }
    }
}

