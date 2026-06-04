# Escape (DeathSurvival) — 뱀파이어 서바이벌 게임
> 5분간 몰려오는 몬스터를 처치하며 생존하는 로그라이크 서바이벌 게임. 3종 캐릭터, 각 4개 고유 스킬, **오브젝트 풀링으로 60fps 유지**.

![Unity](https://img.shields.io/badge/Unity-2022%202D-000000?logo=unity&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?logo=c-sharp&logoColor=white)
![Status](https://img.shields.io/badge/Status-Completed-success)

---

## 📌 At a Glance

| 항목 | 내용 |
|------|------|
| **기간** | 2024.03 ~ 2024.06 (약 3개월) |
| **팀 구성** | 7인 개발 (기획 1, 그래픽 5, **개발 1 — 본인 단독**) |
| **본인 역할** | 게임 개발 총괄 (시스템 설계·캐릭터·스킬·AI·맵 생성) |
| **엔진** | Unity 2022 (2D Tilemap) |
| **플랫폼** | Windows PC |
| **장르** | 2D 탑다운 로그라이크 서바이벌 |

---

## ✨ Highlights

- **3종 캐릭터 × 4개 스킬 (총 12개 스킬)** 구현 — 밸런스형 / 유틸리티형 / 고화력형
- **오브젝트 풀링으로 GC 90% 감소** → 안정적 60fps 유지 (DamageText, BloodEffect, Monster 풀)
- **프로시저럴 타일맵 생성** — 2D 배열 충돌 체크로 클러스터링 방지
- **티어별 점진적 난이도 시스템** — 시간 기반 몬스터 해금 + 코루틴 스폰
- **시간 정지 / 자기장 / 고스트 모드** 등 게임 흐름을 바꾸는 특수 스킬

---

## 🎮 Demo

[📺 플레이 영상](https://youtu.be/BIkVpv60Fms)

---

## 🛠 How It Works

### 1. Object Pooling (성능 핵심)

매 프레임 수백 개의 데미지 텍스트·피 이펙트가 발생하는 게임이라, Instantiate/Destroy 호출을 최소화하기 위해 풀링 적용.

```csharp
public class DamageTextPool : MonoBehaviour
{
    public GameObject damageTextPrefab;
    public int poolSize = 10;
    private List<GameObject> damageTextPool = new List<GameObject>();

    void InitializeDamageTextPool()
    {
        GameObject parent = new GameObject("DamageTextPools");
        for (int i = 0; i < poolSize; i++) {
            GameObject damageText = Instantiate(damageTextPrefab, parent.transform);
            damageText.SetActive(false);
            damageTextPool.Add(damageText);
        }
    }

    public void ShowDamageText(Vector3 position, float damage, int check)
    {
        for (int i = 0; i < damageTextPool.Count; i++) {
            if (!damageTextPool[i].activeSelf) {
                damageTextPool[i].transform.position = position;
                TextMeshPro tmp = damageTextPool[i].GetComponent<TextMeshPro>();

                if (check == 5) {  // Critical!
                    tmp.fontStyle = FontStyles.Bold;
                    tmp.fontSize  = fontSize + 0.5f;
                    tmp.color     = Color.yellow;
                }

                damageTextPool[i].SetActive(true);
                StartCoroutine(FadeOutDamageText(damageTextPool[i]));
                break;
            }
        }
    }
}
```

풀링 적용 대상:
- DamageTextPool — 10개 텍스트
- BloodEffect — 4종류 × 50개 (총 200개)
- MonsterManager — 타입별 몬스터 풀 + 아이템 200개

### 2. 몬스터 AI (Rigidbody 추적 + 스킬 상호작용)

```csharp
void Update()
{
    // 시간 정지 스킬 체크
    animator.SetBool("MonsterTimeStop", WeaponDataManager.playerAFourbool);

    // 고스트 모드: 속도 50% 감소 + 콜리전 통과
    if (WeaponDataManager.playerBFourbool) {
        if (!isOnes) { Speed /= 2f; isOnes = true; }
        circleCollider2D.isTrigger = true;
    }

    // 플레이어 추적
    if (!WeaponDataManager.playerAFourbool && isMove) {
        Vector2 dirV  = (targetRigid.position - rigidbody2D.position);
        Vector2 nextV = dirV.normalized * Speed * Time.deltaTime;
        rigidbody2D.MovePosition(rigidbody2D.position + nextV);

        // 자기장 스킬: 몬스터를 자기장 중심으로 흡인
        if (WeaponDataManager.playerBTwobool && isMagnetic) {
            GameObject mag = GameObject.Find("magneticField");
            transform.position = Vector3.MoveTowards(
                transform.position, mag.transform.position, 1f * Time.deltaTime);
        }
    }
}
```

### 3. 캐릭터 스탯 (3종 차별화)

| 캐릭터 | HP | 속도 | 공격 | 방어율 | 컨셉 |
|--------|-----|------|------|--------|------|
| **White** (밸런스) | 200 | 3 | 100 | 80% | 시간 정지 궁극기로 위기 탈출 |
| **Blue** (유틸) | 150 | 5 | 150 | 90% | 고속 이동 + 고스트 모드 |
| **Green** (고화력) | 250 | 4 | 200 | 60% | 높은 공격력, 낮은 방어율 |

### 4. 스킬 시스템 (3 × 4 = 12개)

**White (밸런스형)**
- Skill 1: 연속 슬래시 (25 데미지)
- Skill 2: 원형 범위 공격 (15 데미지, 2초 쿨)
- Skill 3: 다중 투사체 (100 데미지)
- Skill 4: **시간 정지** (4초 / 30초 쿨)

**Blue (유틸리티형)**
- Skill 1: 부메랑 도끼 (3단계: 전진 → 회전 → 귀환)
- Skill 2: **자기장** (몬스터 흡인)
- Skill 3: 지속 데미지 (25 데미지)
- Skill 4: **고스트 모드** (10초 / 30초 쿨)

### 5. 프로시저럴 타일맵 (충돌 회피 알고리즘)

```csharp
void GenerateRandomObject()
{
    int[][] checkPos = new int[width][];
    for (int i = 0; i < width; i++) checkPos[i] = new int[height];

    for (int x = 0; x < width; x++) {
        for (int y = 0; y < height; y++) {
            if (checkPos[x][y] == 1) continue;
            if (Random.Range(0f, 100f) >= spawnPercentage) continue;

            bool valid = true;
            for (int i = x; i < x + spawndistance; i++)
                for (int j = y; j < y + spawndistance; j++)
                    if (i < width && j < height && checkPos[i][j] == 1)
                        valid = false;

            if (valid) {
                int idx = Random.Range(0, objectTile.Length);
                layerIndex[1].SetTile(new Vector3Int(x, y, 0), objectTile[idx]);

                // 점유 표시
                for (int i = x; i < x + spawndistance; i++)
                    for (int j = y; j < y + spawndistance; j++)
                        if (i < width && j < height) checkPos[i][j] = 1;
            }
        }
    }
}
```

### 6. 동적 난이도 시스템

```csharp
private IEnumerator SpawnMonster(float delay, int monsterTier, int nextTier)
{
    while (true) {
        yield return new WaitForSeconds(delay);

        GameObject m = monsterPools[monsterTier - 1].Find(x => !x.activeSelf);
        if (m != null) {
            m.SetActive(true);
            m.transform.position = GetRandomSpawnPosition();
        }

        // 다음 티어도 함께 스폰 (티어 전환 부드럽게)
        if (nextTier <= monsterPrefabs.Length - 1) {
            GameObject mn = monsterPools[nextTier - 1].Find(x => !x.activeSelf);
            if (mn != null) {
                mn.SetActive(true);
                mn.transform.position = GetRandomSpawnPosition();
            }
        }
    }
}
```

---

## 🧠 Applied Patterns

| 패턴 | 사용처 |
|------|--------|
| Singleton | PlayerState, CharacterManager 등 전역 상태 관리 |
| Object Pool | DamageTextPool, BloodEffect, MonsterManager 재사용 |
| State Flag | playerAFourbool, playerBTwobool 등 스킬 활성화 상태 |
| Coroutine | MonsterManager 스폰, FadeOut 등 비동기 처리 |

---

## 📂 Project Structure

```
DeathSurvival/
├── Assets/
│   ├── Scripts/
│   │   ├── Player/
│   │   │   ├── PlayerState.cs         # 캐릭터 스탯
│   │   │   ├── PlayerController.cs    # 이동/입력
│   │   │   └── WeaponDataManager.cs   # 스킬 데이터
│   │   ├── Monster/
│   │   │   ├── MonsterManager.cs      # 스폰/풀링
│   │   │   └── MonsterController.cs   # AI/추적
│   │   ├── Map/
│   │   │   └── TilemapGenerator.cs    # 프로시저럴 맵
│   │   └── Effects/
│   │       ├── DamageTextPool.cs
│   │       └── BloodEffect.cs
│   └── Prefabs/
└── README.md
```

---

## 🧪 Lessons Learned

- 대량 오브젝트 관리에서 Object Pooling의 중요성 체감
- 정적 변수(WeaponDataManager.playerAFourbool 등) 다용에 따른 추적 어려움 → 이후 프로젝트에서 이벤트/Service 패턴으로 전환
- 협업 프로젝트에서 명확한 코드 구조의 필요성 인식
- 반복 테스트를 통한 밸런스 조정 경험 (3종 × 4스킬 = 12 패턴)

---

## 🔗 Links

- 📖 **Portfolio**: https://junhyeong7083.github.io/PortFolio/portfolio/escape
- 📺 **Play Video**: https://youtu.be/BIkVpv60Fms
