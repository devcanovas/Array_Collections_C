using bytebank.Modelos.Conta;
using bytebank_ATENDIMENTO.bytebank.Util;

Console.WriteLine("Boas Vindas ao ByteBank, Atendimento.");
TestingArrayCheckingAccont();
void TestingArrayCheckingAccont()
{
    CheckingAccountData data = new CheckingAccountData();
    data.Add(new ContaCorrente(874, "5679787-A"));
    data.Add(new ContaCorrente(543, "5679787-B"));
    data.Add(new ContaCorrente(234, "5679787-C"));
    data.Add(new ContaCorrente(566, "5679787-D"));
}

