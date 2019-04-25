using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MachineController : MonoBehaviour {

    //浮力
    const float FLOWTING_POWER = 10.0f;

    //移動速度　回転速度
    public float speed = 5f;
    public float rot_speed = 0.1f;

    private bool is_Gravity = false;
    private Vector3 receivedGravity;

    private Rigidbody rb;

    private GameObject gameManager;




    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //初期化
        receivedGravity = Vector3.zero;
        gameManager = GameObject.FindGameObjectWithTag("GameController");
    }

    
    void Update()
    {

        //重力処理
        if (is_Gravity)
        {
            rb.AddForce(receivedGravity);
        }


        //浮く処理
        if (this.transform.position.y < 1)
        {
            rb.AddForce(0,FLOWTING_POWER,0);
        }


        // リセット処理
        if(this.transform.rotation.eulerAngles.z > 170 && this.transform.rotation.eulerAngles.z < 190)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        //転覆対策
        if (this.transform.rotation.eulerAngles.z > 30 && this.transform.rotation.eulerAngles.z < 330)
        {
            rb.AddTorque(transform.InverseTransformDirection(rb.angularVelocity));
        }

        //転覆対策
        if (this.transform.rotation.eulerAngles.z > 10 && this.transform.rotation.eulerAngles.z < 350)
        {
            rb.AddTorque(transform.InverseTransformDirection(rb.angularVelocity));
        }

     

    }
    

    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (gameManager.GetComponent<GameManager>().state() == "start")
        {
            rb.AddForce(this.transform.forward * z * speed);
            rb.AddTorque(0, x * rot_speed, 0);
        }

        if (Input.GetAxis("Jump")>0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    //重力の適用
    public void ChangeGravity(bool gravity)
    {
        is_Gravity = gravity;
    }

    //重力値の反映
    public void ApplyGravity(Vector3 gravityPower)
    {
        receivedGravity = gravityPower;
    }
}


