using bytebank.Modelos.Conta;
using System.Net.Http.Headers;

namespace bytebank_ATENDIMENTO.bytebank.Util;

internal class CheckingAccountData
{
    private ContaCorrente[] _itens = null;
    private int _nextPosition = 0;

    public CheckingAccountData()
    {
        _itens = new ContaCorrente[5];
    }

    public void Add(ContaCorrente checkingAccount)
    {
        Console.WriteLine($"Adicionando item na posição {_nextPosition}");
        CheckAvailablelity(_nextPosition + 1);
        _itens[_nextPosition] = checkingAccount;
        _nextPosition++;
    }

    private void CheckAvailablelity(int sizeNeeded)
    {
        if(_itens.Length >= sizeNeeded)
        {
            return;
        }
        Console.WriteLine("Aumentando a capacidade do Array");
        ContaCorrente[] newArray = new ContaCorrente[sizeNeeded];
        for (int i = 0; i < _itens.Length; i++)
        {
            newArray[i] = _itens[i];
        }
    }
}
