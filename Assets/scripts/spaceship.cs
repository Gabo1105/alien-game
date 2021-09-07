using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaceship : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject bala;
    [SerializeField] GameObject Metralla;
    [SerializeField] float fireRate;
    [SerializeField] float fireRate2;


    float minX;
    float maxX;
    float minY;
    float maxY;
    float nextfire;
    float nextfire2;
    public bool gamePaused = false;



    // Start is called before the first frame update
    void Start()
    {
        Vector2 esquinaSupDer = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        Vector2 esquinaInfIzq = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        maxX = esquinaSupDer.x - 0.6f;
        maxY = esquinaSupDer.y - 0.6f;
        minX = esquinaInfIzq.x + 0.6f;

        Vector2 puntoX = Camera.main.ViewportToWorldPoint(new Vector2(0, 0.7f));
        minY = puntoX.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gamePaused)
        {
            Mover();
            Disparar();
            Dispararmetralla();
        }
    }
    void Mover()
    {
        float dirH = Input.GetAxis("Horizontal");
        float dirV = Input.GetAxis("Vertical");


        Vector2 movimiento = new Vector2(dirH * Time.deltaTime * speed, dirV * Time.deltaTime * speed);
        transform.Translate(movimiento);

        if (transform.position.x > maxX)
            transform.position = new Vector2(maxX, transform.position.y);

        if (transform.position.x < minX)
            transform.position = new Vector2(minX, transform.position.y);

        if (transform.position.y > maxY)
            transform.position = new Vector2(transform.position.x, maxY);

        if (transform.position.y < minY)
        {
            transform.position = new Vector2(transform.position.x, minY);
        }
    }

    void Disparar()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= nextfire)
        {
            Instantiate(bala, transform.position - new Vector3(0, -0.2f, 0), transform.rotation);
            nextfire = Time.time + fireRate;


        }
    }
    void Dispararmetralla()
    {
        if (Input.GetKey(KeyCode.Z) && Time.time > nextfire2)
        {
            Instantiate(Metralla, transform.position - new Vector3(0, -0.2f, 0), transform.rotation);
            nextfire2 = Time.time + fireRate2;


        }
    }
    void BulletTime()
    {

    }
}
