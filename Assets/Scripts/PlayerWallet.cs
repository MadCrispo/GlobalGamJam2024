using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallet : MonoBehaviour
{
    public List<Products> listaspesa=new List<Products>();
    public Dictionary<Products,int> listaProdotti=new Dictionary<Products,int>();
    public List<Products> Prodotti=new List<Products>();
    public List<int> Prezzi=new List<int>();
    public static PlayerWallet instance;
    public int Soldi=100;
    public TMPro.TextMeshProUGUI listavisibilespesa;
    private void Awake()
    {
        if (instance == null)
            instance = this;

        for (int x=0;x<Prodotti.Count;x++)
        {
            listaProdotti.Add(Prodotti[x],Prezzi[x]);
        }

        listavisibilespesa = FindAnyObjectByType<TMPro.TextMeshProUGUI>();
    }

    private void Start()
    {
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
