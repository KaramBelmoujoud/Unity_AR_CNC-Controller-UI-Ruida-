using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.Scripting.Python;

//[CustomEditor(typeof(python_manager))]

public class python_manager_editor : MonoBehaviour
{
    python_manager targerManager;
    
    /*private void OnEnable()
    {
        targerManager = (python_manager)target;
    }*/

    public void buttonrun()
    {
            string path = Application.dataPath + "/Python/import socket.py";
            PythonRunner.RunFile(path);
    }

    /*public override void GUI()
    {
        if(GUILayout.Button("Launch Python", GUILayout.Height(35)))
        {
            string path = Application.dataPath + "/Python/import socket.py";
            PythonRunner.RunFile(path);
        }
    }*/

}
