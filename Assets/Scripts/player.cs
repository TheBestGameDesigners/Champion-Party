using UnityEngine;
using System.Collections;


public class player : MonoBehaviour {
	
	static public player S; //singleton
	private Rigidbody2D body;
	public float speed = 100;
    public Bounds bounds;

    Vector2 direction; 
	
	 void Awake()
	 {
	        S = this; //set the Singleton
	        bounds = Utils.CombineBoundsOfChildren(this.gameObject);
            direction = new Vector2();
    	}


	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
            float xAxis = Input.GetAxis("Horizontal");
            float yAxis = Input.GetAxis("Vertical");


            direction.Set(xAxis, yAxis);
       


            Vector3 pos = transform.position;
            pos.x += xAxis * speed * Time.deltaTime;
            pos.y += yAxis * speed * Time.deltaTime;



            transform.position = pos;


            // Rotate player
            var objectPos = Camera.main.WorldToScreenPoint(transform.position);
            var dir = Input.mousePosition - objectPos;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg));
    }


    void OnTriggerEnter2D(Collider2D other){

        body.AddForce((-1)*direction * (2)*speed, ForceMode2D.Impulse);
        
        
            
    }

  

    void OnTriggerExit2D(Collider2D other)
    {
        body.velocity = Vector2.zero;

    }
}
