using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{ 

    public float curhealth;
    public float maximum;
    public float minimum;
    [SerializeField] private Behaviour[] components;
    private Animator anim;
    // Start is called before the first frame update
    private void Awake()
    {
    
        anim = GetComponent<Animator>();
    }
    void Start()
    {
         curhealth=maximum;
         
         
         
    }

    // Update is called once per frame
    void Update()
    { 
        if(curhealth>minimum)
    
        {  if(Input.GetKeyDown(KeyCode.J))

        
        
        {
            damage(Random.Range(1,5));
            //anim.SetBool("die",false);
        }
        }
        else
        {
            anim.SetBool("die",true);
            foreach(Behaviour component in components)
             component.enabled=false;

        }
       // anim.SetBool("die",false);
    }

    public void damage(float damage_value)
    {
        curhealth-=damage_value;
        
    }
}
