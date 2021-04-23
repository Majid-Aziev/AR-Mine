using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ClickOnFaceScript : MonoBehaviour {

    public Vector3 delta;
 	
 	private int kopat;
 	private int kopatI;


    private int ground;
    private int groundI;


    public GameObject camenObject;
    public GameObject groundObject;


    public GameObject ToBuildObject;
    public GameObject DigObject;

    public GameObject CamenObject;
    public GameObject GroundObject;

    public void ToBuild() {
    		kopat = 0;
    		PlayerPrefs.SetInt("k", kopat);
            ToBuildObject.GetComponent<Image>().color = new Color(0.135f, 0.5490196f, 1f);
            DigObject.GetComponent<Image>().color = new Color(0.5490196f, 0.5490196f, 0.5490196f);
    }

    public void Dig() {
    	    kopat = 1;
    	    PlayerPrefs.SetInt("k", kopat);
            DigObject.GetComponent<Image>().color = new Color(0.135f, 0.5490196f, 1f);
            ToBuildObject.GetComponent<Image>().color = new Color(0.5490196f, 0.5490196f, 0.5490196f);            
    }    

    public void Camen() {
            ground = 1;
            PlayerPrefs.SetInt("g", ground);
            CamenObject.GetComponent<Image>().color = new Color(0.135f, 0.5490196f, 1f);
            GroundObject.GetComponent<Image>().color = new Color(0.5490196f, 0.5490196f, 0.5490196f);              
    }

    public void Ground() {
            ground = 0;
            PlayerPrefs.SetInt("g", ground);
            GroundObject.GetComponent<Image>().color = new Color(0.135f, 0.5490196f, 1f);
            CamenObject.GetComponent<Image>().color = new Color(0.5490196f, 0.5490196f, 0.5490196f);      
    }    

    // Эта функция вызывается, когда курсор находится над GameObject, на котором этот скрипт расположен
    void OnMouseOver() {
    	kopatI = PlayerPrefs.GetInt("k");

        groundI = PlayerPrefs.GetInt("g");

        // Если нажата левая клавиша мыши
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began && kopatI == 0) {
            // Выводим сообщение в консоль
            Debug.Log("Left click!");
            // Уничтожаем блок, по которому кликнули
            Destroy(this.transform.parent.gameObject);
        }



        // Если клавиша нажата
        if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began && kopatI == 1) {
            // Выводим сообщение в консоль
            Debug.Log("Right click!");

            if (groundI == 0){
            // Вызываем метод из класса WorldGenerator
            WorldGenerator.CloneAndPlace(this.transform.parent.transform.position + delta, // N = C + delta
                                         groundObject); // Родительский GameObject
            }      

            if (groundI == 1){
            // Вызываем метод из класса WorldGenerator
            WorldGenerator.CloneAndPlace(this.transform.parent.transform.position + delta, // N = C + delta
                                         camenObject); // Родительский GameObject
            }                
        }
    }
}