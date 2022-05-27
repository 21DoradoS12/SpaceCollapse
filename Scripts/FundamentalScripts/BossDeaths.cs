using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDeaths : MonoBehaviour
{
    public float i;
    private BossHealth bossHealth;
    private BossSpawn bossSpawn;
    public SpriteRenderer sp1;
    public Animator anim1;
    public float j;
    public float k;
    void Start()
    {
        bossSpawn = GameObject.FindObjectOfType<BossSpawn>();
        this.sp1.enabled = false;
        this.anim1.enabled = false;
    }
    void Update()
    {
        bossHealth = GameObject.FindObjectOfType<BossHealth>();
        if (this.gameObject.tag == "FirstDeath" && bossSpawn.FirstBoss == true)
        {
            if (bossSpawn.FirstBoss == true && bossSpawn.f1 == 0)
            {
                i += Time.deltaTime;
                if (i >= 1f)
                    Destroy(this.gameObject);
            }
            this.gameObject.transform.position = bossHealth.pos;
            if (bossHealth.BossHP == 0)
            {
                sp1.enabled = true;
                anim1.enabled = true;
            }
        }
        if (this.gameObject.tag == "SecondDeath" && bossSpawn.SecondBoss == true)
        {
            if (bossSpawn.SecondBoss == true && bossSpawn.f2 == 0)
            {
                j += Time.deltaTime;
                if (j >= 1f)
                    Destroy(this.gameObject);
            }
            this.gameObject.transform.position = bossHealth.pos;
            if (bossHealth.BossHP == 0)
            {
                sp1.enabled = true;
                anim1.enabled = true;
            }
        }
        if (this.gameObject.tag == "ThirdDeath" && bossSpawn.ThirdBoss == true)
        {
            if (bossSpawn.ThirdBoss == true && bossSpawn.f3 == 0)
            {
                k += Time.deltaTime;
                if (k >= 1f)
                    Destroy(this.gameObject);
            }
            this.gameObject.transform.position = bossHealth.pos;
            if (bossHealth.BossHP == 0)
            {
                sp1.enabled = true;
                anim1.enabled = true;
            }
        }
    }
}
