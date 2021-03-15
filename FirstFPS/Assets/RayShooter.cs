using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour {
    private Camera _camera;

    void Start(){
        _camera = GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void OnGUI(){
        int size = 12;
        float posX = _camera.pixelWidth / 2 - size / 4;
        float posY = _camera.pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(posX, posY, size, size), "*");
    }

    void Update(){

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);    //Wektor środka ekranu
            Ray ray = _camera.ScreenPointToRay(point);  //Generowanie promienia
            RaycastHit hit; //Informacje o przecięciu z powierzchnią 3D

            //Raycast zbiera dane na temat punktu przeciecia
            if (Physics.Raycast(ray, out hit)){
				
				//Pobieranie informacji o trafionym obiekcie
				GameObject hitObject = hit.transform.gameObject;
				ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
				
				//Jeśli zawiera skrypt o trafieniu, reaguj
				if(target != null){
					target.ReactToHit();
				}
				else{
					//Podprocedura kul po strzale
					StartCoroutine(SphereIndicator(hit.point));
				}
            }
        }

    }

    //Podprocedura generowania kulki po strzale
    private IEnumerator SphereIndicator(Vector3 pos) {
        
        //Tworzenie i umieszczanie kuli na podanych x,y,z
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;

        //yield - wskazanie miejsca pauzy podprocedury
        yield return new WaitForSeconds(1); // 1sek życia kulki
        Destroy(sphere);
    }
}
