using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CubeStack : MonoBehaviour
{
    private int _stackHeight;
    [SerializeField] private int cubesToSpawn;
    [SerializeField] private GameObject cubePrefab;
    [SerializeField] private GameObject particleEffect;
    private BoxCollider _boxCollider;
    private float _heightFactor;
    private float _boxColliderCenterYFactor;
    private float _boxColliderSizeYFactor;
    private float _currentSpawnHeight;

    public int StackHeight
    {
        get => _stackHeight;
        private set => _stackHeight = value;
    }

    private void Awake()
    {
        _stackHeight = 0;
        _heightFactor = 0.215f;
        _currentSpawnHeight = 0f;
        _boxColliderCenterYFactor = 0.1075f;
        _boxColliderSizeYFactor = 0.215f;
        _boxCollider = transform.GetComponent<BoxCollider>();
    }

    private void Start()
    {
        AddCubes(cubesToSpawn);
    }

    public void AddCubes(int cubesToAdd)
    {
        for (int i = 0; i < cubesToAdd; i++)
        {
            GameObject go = Instantiate(cubePrefab, transform);
            Vector3 position = go.transform.position;

            go.transform.position = new Vector3(position.x, position.y + _currentSpawnHeight, position.z);
            if (particleEffect)
            {
                Instantiate(particleEffect, go.transform);
                // particleEffect.transform.position = new Vector3(1.9f, 1f, -2.5f);
            }

            IncreaseCollider();

            _stackHeight += 1;
            _currentSpawnHeight += _heightFactor;
        }
    }
    
    public void RemoveCubes(int cubesToRemove, bool shouldDestroyCube = false, float destroyDelay = 0f)
    {
        for (int i = 0; i < cubesToRemove; i++)
        {
            Transform cube = transform.GetChild(1);
            if (shouldDestroyCube)
            {
                StartCoroutine(DestroySingleCube(cube, destroyDelay));
            }
            cube.SetParent(null);
            cube.Translate(Vector3.back * 0.1f);
            DecreaseCollider(); 
            
            _stackHeight -= 1;
            _currentSpawnHeight -= _heightFactor;
        }

        RepositionCubes(cubesToRemove);
    }

    private void IncreaseCollider()
    {
        // increase size
        Vector3 size = _boxCollider.size;
        size = new Vector3(size.x, size.y + _boxColliderSizeYFactor, size.z);
        _boxCollider.size = size;
        
        // reposition
        Vector3 center = _boxCollider.center;
        center = new Vector3(center.x, center.y + _boxColliderCenterYFactor, center.z);
        _boxCollider.center = center;
    }
    
    private void DecreaseCollider()
    {
        // increase size
        Vector3 size = _boxCollider.size;
        size = new Vector3(size.x, size.y - _boxColliderSizeYFactor, size.z);
        _boxCollider.size = size;
        
        // reposition
        Vector3 center = _boxCollider.center;
        center = new Vector3(center.x, center.y - _boxColliderCenterYFactor, center.z);
        _boxCollider.center = center;
    }

    private void RepositionCubes(int cubesHeight)
    {
        for (int i = 1; i < transform.childCount; i++)
        {
            Transform cube = transform.GetChild(i);
            Vector3 position = cube.transform.position;
            position = new Vector3(position.x, position.y - (cubesHeight * _heightFactor), position.z);
            cube.position = position;
        }
    }

    private IEnumerator DestroySingleCube(Transform cube, float delayToDestroy)
    {
        // because Destroy(cube, delayToDestroy) is not working for some reason
        yield return new WaitForSeconds(delayToDestroy);
        Destroy(cube.gameObject);
    }
}
