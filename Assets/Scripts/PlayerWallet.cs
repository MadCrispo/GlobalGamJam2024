using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWallet : MonoBehaviour
{
    public List<Products> listaspesa=new List<Products>();
    public Dictionary<Products,int> listaProdotti=new Dictionary<Products,int>();
    public List<Products> Prodotti=new List<Products>();
    public List<int> Prezzi=new List<int>();
    public int Soldi=100;
    public TMPro.TextMeshProUGUI listavisibilespesa;
    public TMPro.TextMeshProUGUI Portafoglio;
    public static List<PlayerWallet> allplayers;
    public InventoryItems inventory;
    public GameObject Carrello;
    public List<GameObject> positions= new List<GameObject>();
    private void Awake()
    {
        if (allplayers == null)
        {
            allplayers = new List<PlayerWallet>();
        }
        allplayers.Add(this);
        //if (instance == null)
        //    instance = this;

        for (int x = 0; x < Prodotti.Count; x++)
        {
            listaProdotti.Add(Prodotti[x], Prezzi[x]);
        }

    }
    public void AddToCart(Products item)
    {
        foreach (GameObject p in positions)
        {
            if (p.transform.childCount == 0)
            {
               GameObject g = Instantiate(inventory.Prefabs[(int)item],p.transform);
                g.transform.localPosition = Vector3.zero;
                return;
            }
        }
    }
    private void Start()
    {
        Debug.Log("cosa");
        WriteList();
    }

    public void WriteList()
    {
        listavisibilespesa.text = "Lista della spesa\n";
        foreach (Products p in listaspesa)
        {
            if(InventoryItems.allProducts[(int)p]>0)
                listavisibilespesa.text += "<s> "+ p.ToString() + " </s>\n";
            else
                listavisibilespesa.text +=  p.ToString() + "\n";
        }
    }
    public bool CheckMoney()
    {
        return (Soldi  < 0);
    }

    public bool CanIBuyIt(Products prodotto)
    {
        return (Soldi - listaProdotti[prodotto] > 0);
    }
    public void BuyStuff(Products prodotto)
    {
        Soldi -= listaProdotti[prodotto];
        WriteList();
    }
}
