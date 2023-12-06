using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModifier : MonoBehaviour
{
    [SerializeField] int _width;
    [SerializeField] int _height;

    float _widthMultiPlier = 0.0005f;
    float _heightMultiPlier = 0.01f;
    private float _startOffset = 0.17f;
    private float _heightPlayer = 1.84f;
    [SerializeField] Renderer _renderer;
    [SerializeField] Transform _topSpine;
    [SerializeField] Transform _bottomSpine;
    [SerializeField] Transform _colliderTransform;
    // Update is called once per frame
    private void Start()
    {
        SetHeight(Progress.Instance.Height);
        SetWidth(Progress.Instance.Width);
    }
    void Update()
    {
        float offsetY = _height * _heightMultiPlier * _startOffset;

        _topSpine.position = _bottomSpine.position + new Vector3(0, offsetY, 0);
        _colliderTransform.localScale = new Vector3(1, _heightPlayer * _height * _heightMultiPlier, 1) ;
        if (Input.GetKeyDown(KeyCode.W))
        {
            AddHeight(20);
        }
    }
    public void AddWidth(int value)
    {
        _width += value;
        UpdateWidth();
    }
    public void AddHeight(int value)
    {
        _height += value;
    }
    public void SetWidth(int value)
    {
        _width = value;
        UpdateWidth();
    }
    public void SetHeight(int value)
    {
        _height = value;
    }

    public void HitBarier()
    {
        if (_height > 0)
        {
            _height -= 50;
        }else if (_width > 0)
        {
            _width -= 50;
            UpdateWidth();
        }
        else
        {
            Die();
        }
    }
    void UpdateWidth()
    {
        _renderer.material.SetFloat("_PushValue", _width * _widthMultiPlier);
    }
    void Die()
    {
        Destroy(gameObject);
        FindObjectOfType<GameManager>().ShowFinishWindow();
    }
}
