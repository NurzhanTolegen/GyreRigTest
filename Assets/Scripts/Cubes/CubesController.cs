using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CubesController : MonoBehaviour {
    public Transform spawnPoint;
    public Transform cubePrefab;

    public TMP_InputField timeField;
    public TMP_InputField speedField;
    public TMP_InputField distanceField;

    private float time = 1;
    private float speed = 1;
    private float distance = 10;

    private float timer;
    private List<Transform> cubes = new List<Transform>();

    void Start() {
        timeField.onEndEdit.AddListener(OnTimeEndEdit);
        speedField.onEndEdit.AddListener(OnSpeedEndEdit);
        distanceField.onEndEdit.AddListener(OnDistanceEndEdit);

        timeField.text = time.ToString();
        speedField.text = speed.ToString();
        distanceField.text = distance.ToString();
    }

    public void OnTimeEndEdit(string text) {
        float result = time;
        if (float.TryParse(text, out result) && result > 0)
            time = result;
        else
            timeField.text = time.ToString();

    }
    public void OnSpeedEndEdit(string text) {
        float result = speed;
        if (float.TryParse(text, out result) && result > 0)
            speed = result;
        else
            speedField.text = speed.ToString();
    }
    public void OnDistanceEndEdit(string text) {
        float result = distance;
        if (float.TryParse(text, out result) && result > 0)
            distance = result;
        else
            distanceField.text = distance.ToString();
    }

    void Update() {
        if (timer < time) {
            timer += Time.deltaTime;
        } else {
            timer = 0;
            SpawnCube();
        }

        MoveCubes();
    }

    void SpawnCube() {
        Transform cube = Instantiate(cubePrefab, spawnPoint.position, spawnPoint.rotation);
        cubes.Add(cube);
    }

    void MoveCubes() {
        for (int i = 0; i < cubes.Count; i++) {
            Transform cube = cubes[i];
            Vector3 position = cube.position;

            position.x += Time.deltaTime * speed;
            cube.position = position;

            if (Mathf.Abs(position.x - spawnPoint.position.x) > distance)
                RemoveCube(cube);

        }
    }

    void RemoveCube(Transform tr) {
        cubes.Remove(tr);
        Destroy(tr.gameObject);
    }
}
