using UnityEngine;

public class ObjectActiveScene : MonoBehaviour{
    /*public void SetActive(bool active){
        gameObject.SetActive(active);
    }*/
    void Start(){
    }
    void Awake() {
        
    }

    public void desactivar(){
        gameObject.SetActive(false);

    }
}
