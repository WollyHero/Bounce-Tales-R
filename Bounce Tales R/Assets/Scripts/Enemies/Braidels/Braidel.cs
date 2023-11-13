using UnityEngine;

public class Braidel : MonoBehaviour {
    [SerializeField]
    private Transform[] Positions;

    [SerializeField]
    private float Speed;

    [SerializeField]
    private Transform BraidelB;
    private int index = 0;

    private void Update() {
        if (transform.position != Positions[index].position) {
            BraidelB.position = Vector3.MoveTowards(BraidelB.position, Positions[index].position,
                                                    Speed * Time.deltaTime);
        }
        if ((BraidelB.position - Positions[index].position).magnitude <= .2f) {
            if (index + 1 > Positions.Length - 1) {
                index = 0;
            } else {
                index++;
            }
        }
    }
}
