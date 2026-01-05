# Avatar Collider Detector (for VRChat UdonSharp)

> [!NOTE]
> This document was translated using AI.  
> このドキュメントはAIによって翻訳されました。

An UdonSharp system for VRChat worlds designed to detect and prevent abnormal gameplay, such as flying using avatar colliders or clipping through walls.

---

## English (EN)

### 1. Purpose
This script detects and prevents "cheating" behaviors, such as creating colliders under one's feet to fly (air-walking) or using seats attached to an avatar to clip through walls. It ensures world integrity by teleporting the player to a designated location or applying penalties upon detection.

### 2. How to Use
An example is provided at: `5Sori_Udon > AvatarColliderDetector > AvatarColliderDetector.prefab`. Simply drag and drop this prefab into your Scene. Please refer to the variable descriptions below for customization.

### 3. Features & Variables
| Variable | Description |
| :--- | :--- |
| **scanRadius** | The radius around the avatar to scan for colliders. Default values are usually sufficient. |
| **scanInterval** | The time interval (in seconds) between scans. |
| **TeleportPosition** | The destination where the player is forcibly moved when a collider is detected. |
| **ActiveGameObjects** | An array of GameObjects to activate upon detection. In the example, it spawns box colliders to trap the player. |
| **DeactiveWhenNotDetected** | If checked, activated objects are disabled once no colliders are detected. If unchecked, they remain active, preventing escape until the player rejoins the instance. |
| **CustomScript / EventName** | Allows sending a custom event to another UdonSharp script upon detection. |
| **WhiteList** | A list of usernames to be ignored by the system. |

### 4. Precautions
* This system works by counting colliders on the **PlayerLocal (Layer 10)** around the player. If your world uses the **PlayerLocal** layer for other colliders, malfunctions may occur.
* The creator is not responsible for any disadvantages or issues caused by the use of this script.
* **License:** Licensed under the **MIT License**. Modification and redistribution are permitted. Credits in your world are greatly appreciated.

---

## 日本語 (JP)

### 1. 用途
アバターの足元にコライダーを生成して空中浮遊（飛行）したり、アバターに付着した椅子（Seat）を利用して壁を通り抜けるなどの不正行為を検知します。検知時にはプレイヤーを強制的にテレポートさせたり、ペナルティを与えることで、ワールドのゲーム性を保護します。

### 2. 使用方法
`5Sori_Udon > AvatarColliderDetector > AvatarColliderDetector.prefab` にサンプルを用意しています。PrefabをSceneにドラッグ＆ドロップするだけで使用可能です。詳細は以下の変数説明を参考にしてください。

### 3. 機能および変数の説明
| 変数名 | 説明 |
| :--- | :--- |
| **scanRadius** | アバターを中心にコライダーをスキャンする範囲（半径）です。基本設定のままで十分動作します。 |
| **scanInterval** | スキャンを実行する周期（秒）です。 |
| **TeleportPosition** | 不正検知時にプレイヤーを強制的に移動させる場所（Transform）です。 |
| **ActiveGameObjects** | 検知時にアクティブ化するオブジェクトの配列です。例ではボックスコライダーを出現させ、プレイヤーを隔離します。 |
| **DeactiveWhenNotDetected** | チェックを入れると、検知されなくなった際にオブジェクトを非アクティブに戻します。外した場合は、再ログインしない限り隔離状態が維持されます。 |
| **CustomScript / EventName** | 検知時に他のUdonSharpスクリプトへイベントを送信できます。 |
| **WhiteList** | ホワイトリストです。登録されたユーザー名は検知対象から除外されます。 |

### 4. 注意事項
* プレイヤー周辺の **PlayerLocal (10番レイヤー)** のコライダー数をカウントして動作します。ワールド制作時に **PlayerLocal** レイヤーのコライダーを配置している場合、誤作動する可能性が高いです。
* 本スクリプトの使用により発生したいかなる不利益についても、制作者は一切の責任を負いません。
* **ライセンス:** **MITライセンス**を適用しています。改変・再配布は自由です。ワールド内にクレジットを記載していただけると励みになります。

---

## License
Copyright (c) 2026 5Sori  
Licensed under the [MIT License](https://opensource.org/licenses/MIT).
