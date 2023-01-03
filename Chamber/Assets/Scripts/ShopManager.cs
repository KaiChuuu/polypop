using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public WeaponSettings[] gunList;

    public GameObject itemTemplate;

    private Button disabledButton;
    
    // Start is called before the first frame update
    void Start()
    {
        CreateShopList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateShopList()
    {
        //Default weapon selection is pistol
        string storedSelectedWeapon = PlayerPrefs.GetString("SelectedGun", "Pistol");

        for (int i =0; i < gunList.Length; i++)
        {
            GameObject shopItem = Instantiate(itemTemplate);
            
            shopItem.transform.Find("GunName").GetComponent<TextMeshProUGUI>().text = gunList[i].weaponName;

            int j = i;
            Button selectedButton = shopItem.transform.Find("SelectItem").GetComponent<Button>();

            if (storedSelectedWeapon.Equals(gunList[i].weaponName))
            {
                disabledButton = selectedButton;
                selectedButton.interactable = false;
            }

            shopItem.transform.Find("SelectItem").GetComponent<Button>().onClick.AddListener(() => SelectItemEvent(j, selectedButton));

            GameObject itemModel = Instantiate(gunList[i].weaponShopModel);
            itemModel.transform.SetParent(shopItem.transform.Find("ItemModels"));

            shopItem.transform.SetParent(transform.Find("Shop/ShopPanel/Contents"));

            shopItem.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            shopItem.transform.localPosition = new Vector3(0,0,0);
        }
    }

    void SelectItemEvent(int index, Button selectedButton)
    {
        //Reset selected weapon button
        disabledButton.interactable = true;

        disabledButton = selectedButton;
        selectedButton.interactable = false;

        //Debug.Log("button clicked " + index);
        string selectedGun = gunList[index].weaponName;
        PlayerPrefs.SetString("SelectedGun", selectedGun);
    }

    public void MenuButton()
    {
        SceneManager.LoadScene(0);
    }
}
