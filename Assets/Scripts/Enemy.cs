using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    private bool stop;
    private float timer;
    private int x, y, from = -1;
    private Rigidbody rb;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        stop = true;
        timer = 5;
        Scheduler.AddEvent(ChangeDirection, 2);
        Scheduler.AddEvent(() => { stop = false; animator.SetBool("Running", true); }, 2);
    }

    public void Init(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    // Update is called once per frame
    void Update()
    {
        rb.angularVelocity = Vector3.zero;
        if (stop) return;


        //if discover
        //search
        //var pc = Player.instance.transform.position;
        //var pos = transform.position;

        //if(pos.x-pc.x )
        RaycastHit hit;
        //　Cubeのレイを飛ばしターゲットと接触しているか判定
        if (Physics.BoxCast(transform.position, Vector3.one, transform.forward, out hit, Quaternion.identity, 4) && hit.transform.tag == "Player")
        {
            if (Player.instance.hidden) return;
            Result.score = -1;
            SceneManager.LoadScene("End");

        }
    }

    private void ChangeDirection()
    {
        var dir = Stage.route[x * 5 + y];
        bool[] can = { true, true, true, true };
        for(var i = 0; i < dir.Count; i++)
        {
            can[dir[i]] = false;
        }
        int rand=0;
        do
        {
            rand = Random.Range(0, 4);
        } while (!can[rand]);
        Vector3 aim = Vector3.zero;
        switch (rand)
        {
            case 0:
                aim = Vector3.left;
                x--;
                break;
            case 1:
                aim = Vector3.right;
                x++;
                break;
            case 2:
                aim = Vector3.back;
                y--;
                break;
            case 3:
                aim = Vector3.forward;
                y++;
                break;
        }
        transform.forward = aim;
        rb.velocity = aim * 2;
        Scheduler.AddEvent(ChangeDirection, 4);
    }
}
