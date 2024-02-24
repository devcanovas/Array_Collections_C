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
            if (_items[i] != null)
            {
                ContaCorrente checkingAccount = _items[i];
                Console.WriteLine($" Inidice [{i}] = " +
                    $"Conta : {checkingAccount.Conta}" +
                    $"N° da Agência: {checkingAccount.Numero_agencia}");
            }
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
        int indexItem = -1;
        for (int i = 0; i <_nextPosition; i++)
        {
            ContaCorrente actualAccount = _items[i];
            if (actualAccount == account)
            {
                indexItem = i;
                break;
            }
        }

        for(int i = indexItem; i < _nextPosition; i++)
        {
            _items[i] = _items[i + 1];
        }
        _nextPosition--;
        _items[_nextPosition] = null;
    }

    public ContaCorrente GetAccountByIndex(int index)
    {
        if (index < 0 || index >= _nextPosition)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }
        return _items[index];
    }

    public  int Size
    {
        get
        {
            return _nextPosition;
        }
    }

    public ContaCorrente this[int index]
    {
        get
        {
            return GetAccountByIndex(index); 
        }
    }
}
