using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace penguin
{
public class fishGet : MonoBehaviour
{
    AudioSource audiosource;
    public GameObject audioManager;
    float jumpinterval;
    public GameObject fish;
    bool swim;
    // Start is called before the first frame update
    void Start()
    {
        audiosource=audioManager.GetComponent<AudioSource>();
        swim=false;
    }

    // Update is called once per frame
    void Update()
    {
        jumpinterval+=Time.deltaTime;
        if(jumpinterval>Random.Range(2,4))
        {
            StartCoroutine("jump");
             
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name=="penguin02")
        {
            audiosource.Play();
            fish.GetComponent<Renderer> ().enabled = false;
            this.gameObject.GetComponent<Collider2D>().enabled=false;
   　　 }
    }

    private IEnumerator  jump()
    {
        fish.GetComponent<Transform>().position+=new Vector3(Random.Range(-1,1)*0.2f,Random.Range(-1,1)*0.2f,0);
        //Vector3 _force=new Vector3(Random.Range(-8,8),Random.Range(-8,8),0);
        //fish.GetComponent<Rigidbody2D>().AddForce(_force);
        yield return new WaitForSeconds (0.1f);
        jumpinterval=0;          
        //fish.GetComponent<Rigidbody2D>().AddForce(new Vector3(0,0,0));
    }
}
}