using UnityEngine;
using System.Collections;

/// <summary>
/// ピンチイン・アウトした時にカメラの画角を変更
/// </summary>
public class PinchInOut : MonoBehaviour {

    //カメラ視覚の範囲
    float viewMin = 20.0f;
    float viewMax = 80.0f;

    //直前の2点間の距離.
    private float backDist = 0.0f;
    //初期値
    float view = 40.0f;

    // Update is called once per frame
    void Update () {
        // マルチタッチかどうか確認
        if (Input.touchCount >= 2)
        {
            // タッチしている２点を取得
            Touch t1 = Input.GetTouch (0);
            Touch t2 = Input.GetTouch (1);

            //2点タッチ開始時の距離を記憶
            if (t2.phase == TouchPhase.Began)
            {
                backDist = Vector2.Distance (t1.position, t2.position);
            }
            else if (t1.phase == TouchPhase.Moved && t2.phase == TouchPhase.Moved)
            {
                // タッチ位置の移動後、長さを再測し、前回の距離からの相対値を取る。
                float newDist = Vector2.Distance (t1.position, t2.position);
                view = view + (backDist - newDist) / 100.0f;

                // 限界値をオーバーした際の処理
                if(view > viewMax)
                {
                    view = viewMax;
                }
                else if(view < viewMin)
                {
                    view = viewMin;
                }
                //画角変更
				GetComponent<Camera>().fieldOfView = view;
            }
        }
    }
}
