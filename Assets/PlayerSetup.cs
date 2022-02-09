using UnityEngine;
using Mirror;
public class PlayerSetup : NetworkBehaviour
{
    [SerializeField] Behaviour[] componentsToDisable;

    private Camera sceneCamera;

    private void Start() {
        // On boucle sur tous les composants renseignés->si ce n est pas notre joueur on desactive le component
        if(!isLocalPlayer){
            for(int i = 0; i < componentsToDisable.Length; i++){
                componentsToDisable[i].enabled = false;
            }
        } else{
            sceneCamera = Camera.main;
            if(sceneCamera != null){
                sceneCamera.gameObject.SetActive(false);
            }
        }
    }

    private void OnDisable() {
        if(sceneCamera != null){
            sceneCamera.gameObject.SetActive(true);
        }
    }
}
