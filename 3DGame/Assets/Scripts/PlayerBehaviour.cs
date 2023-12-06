using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] PlayerMove _playerMove;
    [SerializeField] PreFinishBehaviour _preFinishBehaviour;
    [SerializeField] Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        _playerMove.enabled = false;
        _preFinishBehaviour.enabled = false;
    }

    internal void StartFinishBehaviour()
    {
        _preFinishBehaviour.enabled = false;
        animator.SetTrigger("Dance");

    }

    // Update is called once per frame
    public void Play()
    {
        _playerMove.enabled = true;
    }
    public void StartPreFinishBehaviour()
    {
        _playerMove.enabled = false;
        _preFinishBehaviour.enabled = true;
    }
}
