using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    [SerializeField] private Transform _gun;
    [SerializeField] private Transform _target;

    void Update()
    {

        _gun.LookAt(_target);
    }
}
