using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instace;
    private Vector3 respawnPosition;

    private void Awake()
    {
        instace = this;
    }

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        respawnPosition = PlayerController.instance.transform.position;
    }

    public void Respawn()
    {
        StartCoroutine(RespawnWaiter());
        //Restablecer vida
        HealthManager.instance.ResetHealth();
    }


    public IEnumerator RespawnWaiter()
    {
        //El personaje desaparece y la camara lo deja de seguir
        PlayerController.instance.gameObject.SetActive(false);
        CameraController.instance.cmBrain.enabled = false;
        UIManager.instance.fadeToBlack = true;

        //Tiempo de espera        
        yield return new WaitForSeconds(2f);
        UIManager.instance.fadeFromBlack = true;

        //Reubicar el personaje, mostrarlo y aplicar la camara
        PlayerController.instance.transform.position = respawnPosition;
        CameraController.instance.cmBrain.enabled = true;
        PlayerController.instance.gameObject.SetActive(true);
    }

    public void SetSpawnPoint(Vector3 newSpawnPoint)
    {
        respawnPosition = newSpawnPoint;
    }
}
