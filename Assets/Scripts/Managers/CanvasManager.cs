using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Unity.VisualScripting;

public class CanvasManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _currentCanvas;
    private AsyncOperationHandle<GameObject> _loadOp;
    private AsyncOperationHandle<GameObject> _instantiateOp;

    private void OnEnable()
    {
        Enemy.OnDefeat += GoToResults;
        Player.OnDefeat += GoToResults;
    }
    private void Start()
    {
        LoadCanvas("TitleCanvas");
    }

    public void GoToResults()
    {
        DisableCurrentCanvases();
        EnableAppropriateCanvases("ResultsCanvas");
    }
    public void SetCurrentCanvas(GameObject currentCanvas)
    {
        _currentCanvas = currentCanvas;
    }

    public void DisableCurrentCanvases()
    {
        //turns off the current canvases and releases them from memory after 1.5 seconds.
        StartCoroutine(WaitToTurnOffCurrentCanvas(_currentCanvas));
    }
    public void EnableAppropriateCanvases(string nextCanvas)
    {
        StartCoroutine(TurnOnNextCanvas(nextCanvas));
    }

    IEnumerator TurnOnNextCanvas(string nextCanvas)
    {
        yield return new WaitForSeconds(1.5f);
        LoadCanvas(nextCanvas);
    }
    //Disable those canvas components and release the memory. 
    IEnumerator WaitToTurnOffCurrentCanvas(GameObject currentCanvases)
    {
        //remove reference to current canvas. 
        _currentCanvas = null;

        yield return new WaitForSeconds(1.5f); // wait for fade out. 

        Addressables.Release(_loadOp); // release the loadOp handle. 
        Addressables.Release(_instantiateOp);//release the instantiateOp handle. 
    }
    //this method handles loading the proper canvas via addressables. 
    public async void LoadCanvas(string objectAddress)
    {
        string titleCanvasAssetKey = objectAddress;
        //load the asset by it's key. 
        _loadOp = Addressables.LoadAssetAsync<GameObject>(titleCanvasAssetKey); // load the prefab
        await _loadOp.Task;

        if (_loadOp.Status == AsyncOperationStatus.Succeeded)
        {
            // Instantiate the loaded asset
            _instantiateOp = Addressables.InstantiateAsync(titleCanvasAssetKey);
            await _instantiateOp.Task; // Wait for instantiation to finish

            if (_instantiateOp.Status == AsyncOperationStatus.Succeeded)
            {
                GameObject instantiatedPrefab = _instantiateOp.Result;
                SetCurrentCanvas(instantiatedPrefab); // sets the current canvas
            }
        }
    }
}
