using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{

    // ★追加
    // エフェクトプレハブのデータを入れるための箱を作る。
    public GameObject effectPrefab;

    private GameObject Root;

    State state;
    private void Start()
    {
        Root = this.transform.root.gameObject;
        state = Root.GetComponent<State>();

    }
    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Shell"))
        {
            state.Damage(10);
            if (state.getHP() <= 0)
            {
                Destroy(this.gameObject);
                // ★追加
                // エフェクトを実体化（インスタンス化）する。
                GameObject effect = (GameObject)Instantiate(effectPrefab, transform.position, Quaternion.identity);

                // ★追加
                // エフェクトを２秒後に画面から消す
                Destroy(effect, 2.0f);
            }
            
            Destroy(other.gameObject);

            
        }
    }
}