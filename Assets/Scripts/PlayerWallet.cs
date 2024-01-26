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
        WriteList();
    }

    public void WriteList()
    {
        listavisibilespesa.text = "";
        foreach (Products p in listaspesa)
        {
            listavisibilespesa.text +=  p.ToString() + "\n";
        }
    }
    public bool CanIBuyIt(Products prodotto)
    {
        return (Soldi - listaProdotti[prodotto] > 0);
    }
    public void BuyStuff(Products prodotto)
    {
        if (CanIBuyIt(prodotto))
        {
            Soldi -= listaProdotti[prodotto];
            listaspesa.Remove(prodotto);
            WriteList();
        }
    }
}
