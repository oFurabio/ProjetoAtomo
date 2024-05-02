using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchccreenButtons : MonoBehaviour {

    [SerializeField] private Button acao;

    [SerializeField] private Button left;
    [SerializeField] private Button up;
    [SerializeField] private Button right;
    [SerializeField] private Button down;


    void Start() {
        left.onClick.AddListener(MoveLeft);
    }

    private void MoveLeft() {
        Debug.Log("esquerda");
        
    }
}
