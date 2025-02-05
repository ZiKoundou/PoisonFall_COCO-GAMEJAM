using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public delegate void DeathEvent();
    public event DeathEvent OnDeath;
    public void Die(){
        OnDeath?.Invoke();
        Destroy(gameObject);
    }
}
