using bytebank.Modelos.Conta;
using System.Net.Http.Headers;

namespace bytebank_ATENDIMENTO.bytebank.Util;

internal class CheckingAccountData
{
    private ContaCorrente[]? _items = null;
    private int _nextPosition = 0;

    public CheckingAccountData()
    {
        _items = new ContaCorrente[5];
    }

    public void GetListOfCheckingAccountsRegistered()
    {
        for(int i = 0; i < _items.Length; i++)
        {
            _items[i].ToString();
        }
    }

    public void Add(ContaCorrente checkingAccount)
    {
        Console.WriteLine($"Adicionando item na posição {_nextPosition}");
        CheckAvailablelity(_nextPosition + 1);
        _items[_nextPosition] = checkingAccount;
        _nextPosition++;
    }

    private void CheckAvailablelity(int sizeNeeded)
    {
        if (_items.Length >= sizeNeeded)
        {
            return;
        }
        Console.WriteLine("Aumentando a capacidade do Array");
        ContaCorrente[] newArray = new ContaCorrente[sizeNeeded];
        for (int i = 0; i < _items.Length; i++)
        {
            newArray[i] = _items[i];
        }
    }

    public void GetAccountHighestBalance()
    {
        ContaCorrente[] checkingAccounts = _items;
        double highestBalance = 0;
        ContaCorrente? accountHighestBalance = null;
        for (int i = 0; i < checkingAccounts.Length; i++)
        {
            if (checkingAccounts[i]?.Saldo > highestBalance)
            {
                highestBalance = checkingAccounts[i].Saldo;
                accountHighestBalance = checkingAccounts[i];
            }
        }
        Console.WriteLine("A conta com o maior saldo é:");
        Console.WriteLine(accountHighestBalance);
        Console.WriteLine($"Com o saldo de {accountHighestBalance?.Saldo}");
    }

    public void Remove(ContaCorrente account)
    {
        int indiceItem = -1;
        for (int i = 0; i <_nextPosition; i++)
        {
            ContaCorrente actualAccount = _items[i];
            if (actualAccount == account)
            {
                indiceItem = i;
                break;
            }
        }

        for(int i = indiceItem; i < _nextPosition; i++)
        {
            _items[i] = _items[i + 1];
        }
        _nextPosition--;
        _items[_nextPosition] = null;
    }
}
