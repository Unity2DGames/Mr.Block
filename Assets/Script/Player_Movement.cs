using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Movement : MonoBehaviour
{
    public Rigidbody2D rbody;
    public float speed;
    public GameObject gameWonPanel;
    public GameObject gameOverPanel;
    private bool isGameOver=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver == true)
        {
            return;
        }
        if(Input.GetAxis("Horizontal")>0) //it is for forward 
        {
            rbody.velocity = new Vector2(speed, 0f);
        }
        else if (Input.GetAxis("Horizontal") < 0) //its for backword
        {
            rbody.velocity = new Vector2(-speed, 0f);
        }

        if (Input.GetAxis("Vertical") > 0) //it is for forward 
        {
            rbody.velocity = new Vector2(0f, speed);
        }
        else if (Input.GetAxis("Vertical") < 0) //its for backword
        {
            rbody.velocity = new Vector2(0f, -speed);
        }
        else if(Input.GetAxis("Vertical")==0 && Input.GetAxis("Horizontal") == 0)
        {
            //stop
            rbody.velocity = new Vector2(0f, 0f);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Home")
        {
            gameWonPanel.SetActive(true);
            Debug.Log("Level Complete!!");
            isGameOver = true;
        }
       else if (collision.tag == "Enemy")
        {
             gameOverPanel.SetActive(true);
            Debug.Log("Game Over!!");
             isGameOver = true;
        }
    }
    public void Restartgame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Game Restart");
    }
}
