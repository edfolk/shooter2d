using System.Runtime.CompilerServices;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [HideInInspector]
    [SerializeField] public EnemyConfig config;
    private Move move;

    private void Start() {
        move = GetComponent<Move>();
        if (move != null)
        {
            move.speed = config.moveSpeed;
        }
    }
}
