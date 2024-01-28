using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWallet : MonoBehaviour
{
    public static List<Products> listaspesa;
    public Dictionary<Products,int> listaProdotti=new Dictionary<Products,int>();
    public List<Products> Prodotti=new List<Products>();
    public List<int> Prezzi=new List<int>();
    public int Soldi=100;
    public TMPro.TextMeshProUGUI listavisibilespesa,nextspesa;
    public TMPro.TextMeshProUGUI Portafoglio;
    public static List<PlayerWallet> allplayers;
    public InventoryItems inventory;
    public GameObject Carrello;
    public List<GameObject> positions= new List<GameObject>();
    public int id = 0;
    public GameObject[] granmas;
    public TextMeshProUGUI Messggio;
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

        if (listaspesa == null)
        {
            int x = Random.Range(0,Prodotti.Count);
            listaspesa = new List<Products>();
            while (true)
            {
                if (listaspesa.Count == 6)
                    return;
                if ((Products)x != Products.noSpecial || (Products)x != Products.nutella)
                {
                    listaspesa.Add((Products)x);
                }
                x = Random.Range(0, Prodotti.Count);
            }

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
   

    private void Update()
    {
        Portafoglio.text = Soldi+"$";
        WriteCurrent();
        WriteNextCurrent();
    }
    public bool IsNextProduct(Products p)
    {
        if (listaspesa[id] == p)
        {
            id++;
            return true;
        }

        return false;
    }
    public void WriteCurrent()
    {
        if (id == listaspesa.Count)
            return;
        listavisibilespesa.text = listaspesa[id].ToString();
    }
    public void WriteNextCurrent()
    {
        if (id < listaspesa.Count - 1)
            nextspesa.text = listaspesa[id + 1].ToString();
        else
            nextspesa.text = "";
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
    }
}
