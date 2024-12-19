using System.Text;

namespace Tumakov
{
    struct BankAccNumber
    {
        public string bank;
        public uint self;
        StringBuilder bank0;
        public bool Input(string inputNumber)
        {
            inputNumber = inputNumber.Replace(" ", "");
            bank0 = new StringBuilder();
            if (inputNumber.Length != 20)
            {
                Console.WriteLine("Некорректно набран номер счёта");
                return false;
            }
            for (int i = 0; i < 13; i++)
            {
                bank0.Append(inputNumber[i]);
                if ("2 4 7 8".Contains(Convert.ToString(i)))
                {
                    bank0.Append(" ");
                }
            }

            bank = bank0.ToString();

            bank0.Clear();
            for (int i = 13; i < 20; i++)
            {
                bank0.Append(inputNumber[i]);
            }

            self = Convert.ToUInt32(bank0.ToString());
            return true;
        }
        public void Output()
        {
            Console.WriteLine($"{bank} {self}");
        }
    }

    enum BankAccTypes
    {
        savings = 1,
        current = 2
    }

    internal class BankAccount
    {
        private string bankNumber = "408 17 810 3 1085";
        private static uint selfNumber = 1000000;
        private BankAccNumber fullNumber;
        private decimal balance;
        private BankAccTypes type;

        public BankAccount(BankAccTypes setType)
        {
            selfNumber++;
            fullNumber.self = selfNumber;
            fullNumber.bank = bankNumber;
            balance = 0;
            type = setType;
        }


        public BankAccNumber GetNumber
        {
            get { return fullNumber; }
        }
        public decimal Balance
        {
            get { return balance; }
            set { balance = value; }
        }
        public BankAccTypes Type
        {
            get { return type; }
            set { type = value; }
        }


        public void PutOnAcc(decimal value)
        {
            balance += value;
        }
        public bool TakeFromAcc(decimal value)
        {
            if (value > balance)
            {
                Console.WriteLine("На счёте недостаточно средств!");
                return false;
            }
            else
            {
                balance -= value;
                Console.WriteLine("Перевод успешно осуществлён");
                return true;
            }
        }

        public void Transfer(BankAccount Account, decimal value)
        {
            if (TakeFromAcc(value))
            {
                Account.PutOnAcc(value);
            }
        }
    }
}
