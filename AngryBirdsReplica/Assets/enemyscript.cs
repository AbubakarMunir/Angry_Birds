using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemyscript : MonoBehaviour
{
    public float health = 2f;
    public GameObject killingeffect;
    public static int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        count++;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.relativeVelocity.magnitude>1)
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(killingeffect,transform.position,Quaternion.identity);
        Destroy(this.gameObject);
        count--;
        if (count == 0)
        {
            int s = SceneManager.GetActiveScene().buildIndex;
            if (s < 2)
            {
                s++;
                SceneManager.LoadScene(s);
            }
            else
            {
                Debug.Log("wonnn");
            }
                
        }
            
            
    }
}
