using bytebank.Modelos.Conta;
using bytebank_ATENDIMENTO.bytebank.Util;

Console.WriteLine("Boas Vindas ao ByteBank, Atendimento.");
void TestingArrayCheckingAccont()
{
    CheckingAccountData data = new CheckingAccountData();
    data.Add(new ContaCorrente(874, "5679787-A"));
    data.Add(new ContaCorrente(543, "5679787-B"));
    data.Add(new ContaCorrente(234, "5679787-C"));
    data.Add(new ContaCorrente(566, "5679787-D"));
}

void TestingGettingHighestBalanceAccount()
{
    CheckingAccountData data = new CheckingAccountData();
    ContaCorrente conta1 = new ContaCorrente(123, "3429342-a");
    ContaCorrente conta2 = new ContaCorrente(323, "4323423-b");
    ContaCorrente conta3 = new ContaCorrente(534, "2342399-z");
    conta1.Depositar(10000);
    conta2.Depositar(2200);
    conta3.Depositar(500);

    data.Add(conta1);
    data.Add(conta2);
    data.Add(conta3);
    data.GetAccountHighestBalance();
    data.GetListOfCheckingAccountsRegistered();
}

void TestingGettinAccountByIndex()
{
    CheckingAccountData data = new CheckingAccountData();
    ContaCorrente conta1 = new ContaCorrente(123, "3429342-a");
    ContaCorrente conta2 = new ContaCorrente(323, "4323423-b");
    ContaCorrente conta3 = new ContaCorrente(534, "2342399-z");
    data.Add(conta1);
    data.Add(conta2);
    data.Add(conta3);

    for(int i = 0; i < data.Size; i++)
    {
        ContaCorrente account = data.GetAccountByIndex(i);
        Console.WriteLine($"Index [{i}] = {account.Conta}/{account.Numero_agencia}");
    }
}

TestingGettinAccountByIndex();