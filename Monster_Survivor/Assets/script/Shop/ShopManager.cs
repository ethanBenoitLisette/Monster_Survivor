using UnityEngine;
using TMPro;

public class Shop : MonoBehaviour
{
    public TMP_Text levelMeleeText;
    public TMP_Text levelDistanceText;
    public TMP_Text levelMoneyText;
    public TMP_Text levelEffectText;
    public TMP_Text priceMeleeText;
    public TMP_Text priceDistanceText;
    public TMP_Text priceMoneyText;
    public TMP_Text priceEffectText;
    public GameObject scoreManagerObject;


    private struct UpgradeData
    {
        public int price;
        public int damage;
        public int currentLevel;
    }

    private UpgradeData meleeUpgradeData;
    private UpgradeData distanceUpgradeData;
    private UpgradeData moneyUpgradeData;
    private UpgradeData effectUpgradeData;

    private const string meleeUpgradeKey = "MeleeUpgrade";
    private const string distanceUpgradeKey = "DistanceUpgrade";
    private const string moneyUpgradeKey = "MoneyUpgrade";
    private const string effectUpgradeKey = "EffectUpgrade";

    void Start()
    {
        meleeUpgradeData = LoadUpgradeData(meleeUpgradeKey);
        distanceUpgradeData = LoadUpgradeData(distanceUpgradeKey);
        moneyUpgradeData = LoadUpgradeData(moneyUpgradeKey);
        effectUpgradeData = LoadUpgradeData(effectUpgradeKey);

        UpdateLevelUI();
    }
    void Update()
    {
        GiveMoney();
    }

    void UpdateLevelUI()
    {
        UpdateLevelUI(levelMeleeText, meleeUpgradeData.currentLevel, meleeUpgradeData.price);
        UpdateLevelUI(levelDistanceText, distanceUpgradeData.currentLevel, distanceUpgradeData.price);
        UpdateLevelUI(levelMoneyText, moneyUpgradeData.currentLevel, moneyUpgradeData.price);
        UpdateLevelUI(levelEffectText, effectUpgradeData.currentLevel, effectUpgradeData.price);

        priceMeleeText.text = meleeUpgradeData.price.ToString();
        priceDistanceText.text = distanceUpgradeData.price.ToString();
        priceMoneyText.text = moneyUpgradeData.price.ToString();
        priceEffectText.text = effectUpgradeData.price.ToString();

        Debug.Log("Melee damage: " + meleeUpgradeData.damage);
        Debug.Log("Distance damage: " + distanceUpgradeData.damage);
        Debug.Log("Money damage: " + moneyUpgradeData.damage);
        Debug.Log("Effect damage: " + effectUpgradeData.damage);
    }

    void UpdateLevelUI(TMP_Text textComponent, int currentLevel, int price)
    {
        textComponent.text = "Level: " + currentLevel.ToString();
    }

    void Upgrade(ref UpgradeData upgradeData, string key)
    {
        if (scoreManagerObject != null)
        {
            ScoreManager scoreManager = scoreManagerObject.GetComponent<ScoreManager>();
            if (scoreManager != null)
            {
                if (scoreManager.score >= upgradeData.price)
                {
                    scoreManager.DecrementScore(upgradeData.price);
                    upgradeData.price += 10;
                    upgradeData.damage += 10;
                    upgradeData.currentLevel++;
                    UpdateLevelUI();
                    SaveUpgradeData(key, upgradeData); // Appel de SaveUpgradeData avec les données d'amélioration correctes
                }
                else
                {
                    Debug.Log("Not enough score to buy!");
                }
            }
            else
            {
                Debug.Log("ScoreManager component not found on ScoreManagerObject!");
            }
        }
        else
        {
            Debug.Log("ScoreManagerObject not assigned!");
        }
    }

    public void UpgradeMelee() => Upgrade(ref meleeUpgradeData, meleeUpgradeKey);
    public void UpgradeDistance() => Upgrade(ref distanceUpgradeData, distanceUpgradeKey);
    public void UpgradeMoney() => Upgrade(ref moneyUpgradeData, moneyUpgradeKey);
    public void UpgradeEffect() => Upgrade(ref effectUpgradeData, effectUpgradeKey);


    UpgradeData LoadUpgradeData(string key)
    {
        UpgradeData data = new UpgradeData();
        data.price = PlayerPrefs.GetInt(key + "_Price", 10);
        data.damage = PlayerPrefs.GetInt(key + "_Damage", 20);
        data.currentLevel = PlayerPrefs.GetInt(key + "_Level", 1);
        return data;
    }

    void SaveUpgradeData(string key, UpgradeData data)
    {
        PlayerPrefs.SetInt(key + "_Price", data.price);
        PlayerPrefs.SetInt(key + "_Damage", data.damage);
        PlayerPrefs.SetInt(key + "_Level", data.currentLevel);
        PlayerPrefs.Save();
    }

    void SaveUpgradeData()
    {
        SaveUpgradeData(meleeUpgradeKey, meleeUpgradeData);
        SaveUpgradeData(distanceUpgradeKey, distanceUpgradeData);
        SaveUpgradeData(moneyUpgradeKey, moneyUpgradeData);
        SaveUpgradeData(effectUpgradeKey, effectUpgradeData);
    }
    public void ResetProgress()
    {
        meleeUpgradeData = new UpgradeData { price = 10, damage = 20, currentLevel = 1 };
        distanceUpgradeData = new UpgradeData { price = 10, damage = 20, currentLevel = 1 };
        moneyUpgradeData = new UpgradeData { price = 10, damage = 20, currentLevel = 1 };
        effectUpgradeData = new UpgradeData { price = 10, damage = 20, currentLevel = 1 };

        // Sauvegarder les données de réinitialisation dans PlayerPrefs
        SaveUpgradeData(meleeUpgradeKey, meleeUpgradeData);
        SaveUpgradeData(distanceUpgradeKey, distanceUpgradeData);
        SaveUpgradeData(moneyUpgradeKey, moneyUpgradeData);
        SaveUpgradeData(effectUpgradeKey, effectUpgradeData);
        if (scoreManagerObject != null)
        {
            ScoreManager scoreManager = scoreManagerObject.GetComponent<ScoreManager>();
            if (scoreManager != null)
            {
                scoreManager.DecrementScore(scoreManager.score);
            }
        }

        // Mettre à jour l'UI après la réinitialisation
        UpdateLevelUI();
    }

    public void GiveMoney()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            ScoreManager scoreManager = scoreManagerObject.GetComponent<ScoreManager>();
            if (scoreManager != null)
            {
                scoreManager.IncrementScore(1000);
            }
            else
            {
                Debug.LogError("ScoreManager not found on ScoreManagerObject!");
            }
        }
    }
    public int GetDistanceDamage()
    {
        return distanceUpgradeData.damage;
    }

}
