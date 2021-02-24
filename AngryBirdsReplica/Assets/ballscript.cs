using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballscript : MonoBehaviour
{
    public Rigidbody2D rb;
    bool Ispressed;
    public float releasetime = 0.15f;
    public float maxdragdstance = 2f;
    public Rigidbody2D hookrb;
    public GameObject next;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Ispressed==true)
        {
            Vector2 mpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Vector3.Distance(mpos,hookrb.position)<=maxdragdstance)
            {
                rb.position = mpos;
            }
            else
            {
                rb.position=((mpos - hookrb.position).normalized * maxdragdstance)+ hookrb.position;
            }
                    
        }
    }
    private void OnMouseDown()
    {
        Ispressed = true;
        rb.isKinematic = true;
    }

    private void OnMouseUp()
    {
        Ispressed = false;
        rb.isKinematic = false;
        StartCoroutine(release());
    }
    IEnumerator release()
    {
        yield return new WaitForSeconds(releasetime);
        GetComponent<SpringJoint2D>().enabled = false;
        this.enabled = false;
        yield return new WaitForSeconds(5f);
        if(next!=null)
        {
            next.SetActive(true);
        }
        else
        {
            if(enemyscript.count>0)
            {
                Debug.Log("GAME LOST");
            }
            else
            {
                //load scene
            }
        }
        
    }
}
