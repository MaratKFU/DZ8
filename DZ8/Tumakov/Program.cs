using System;
using System.Collections.Generic;
using Tumakov;

namespace DZ8
{
    class Program
    {
        public static void FirstExercise()
        {
            Dictionary<BankAccNumber, BankAccount> accounts = new Dictionary<BankAccNumber, BankAccount>();
            bool flag1 = true;
            while (flag1)
            {
                bool flag2 = true;
                Console.WriteLine("Введите действие:");
                Console.WriteLine("1 - Завести новый счёт");//+
                Console.WriteLine("2 - Вывести все номера счётов");//+
                Console.WriteLine("3 - Выбрать счёт для дальнейшей работы с ним");//
                Console.WriteLine("4 - Удалить счёт");//
                Console.WriteLine("5 - Выход");//+
                Console.WriteLine();

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("Введите тип счёта");
                        Console.WriteLine("1 - Сберегательный");
                        Console.WriteLine("2 - Текущий");
                        BankAccount newAcc;
                        switch (Console.ReadLine())
                        {
                            case "1":
                                newAcc = new BankAccount(BankAccTypes.savings);
                                break;
                            case "2":
                                newAcc = new BankAccount(BankAccTypes.current);
                                break;
                            default:
                                Console.WriteLine("Неизвестный тип счёта, введите ещё раз");
                                continue;
                        }
                        accounts.Add(newAcc.GetNumber, newAcc);
                        break;
                    case "2":
                        foreach (BankAccNumber accountNumber in accounts.Keys)
                        {
                            accountNumber.Output();
                        }
                        Console.ReadKey(true);
                        break;
                    case "3":
                        Console.WriteLine("Введите номер счёта с которым хотите работать");

                        BankAccNumber currentAccNumber = new BankAccNumber();
                        BankAccNumber tempBankAccNumber = new BankAccNumber();

                        if (!tempBankAccNumber.Input(Console.ReadLine()))
                        {
                            continue;
                        }

                        foreach (BankAccNumber AccNumber in accounts.Keys)
                        {
                            if ((tempBankAccNumber.bank == AccNumber.bank) && (tempBankAccNumber.self == AccNumber.self))
                            {
                                currentAccNumber.bank = tempBankAccNumber.bank;
                                currentAccNumber.self = tempBankAccNumber.self;

                            }
                        }
                        while (flag2)
                        {
                            Console.WriteLine("Введите действие:");
                            Console.WriteLine("1 - Пополнить счёт");//+
                            Console.WriteLine("2 - Вывести со счёта");//+
                            Console.WriteLine("3 - Перевести на другой счёт");
                            Console.WriteLine("4 - Узнать баланс");
                            Console.WriteLine("5 - Выход");
                            Console.WriteLine();
                            switch (Console.ReadLine())
                            {
                                case "1":
                                    Console.WriteLine("Введите сумму, на которую хотите пополнить счёт");
                                    decimal.TryParse(Console.ReadLine(), out var cash);
                                    accounts[currentAccNumber].PutOnAcc(cash);
                                    Console.WriteLine("Счёт успешно пополнен");
                                    Console.ReadKey(true);
                                    break;
                                case "2":
                                    Console.WriteLine("Введите сумму, которую хотите снять");
                                    decimal.TryParse(Console.ReadLine(), out cash);
                                    Console.WriteLine($"Вот ваши {cash} рублей");
                                    accounts[currentAccNumber].TakeFromAcc(cash);
                                    Console.ReadKey(true);
                                    break;
                                case "3":
                                    BankAccNumber newNumber = new BankAccNumber();

                                    Console.WriteLine("Введите номер счёта на который хотите перевести деньги:");

                                    if (!newNumber.Input(Console.ReadLine()))
                                    {
                                        break;
                                    }

                                    Console.WriteLine("Введите сумму, которую хотите перевести");
                                    decimal.TryParse(Console.ReadLine(), out cash);

                                    foreach (BankAccNumber receiverAccNumber in accounts.Keys)
                                    {
                                        if (newNumber.bank == receiverAccNumber.bank && newNumber.self == receiverAccNumber.self)
                                        {
                                            accounts[currentAccNumber].Transfer(accounts[receiverAccNumber], cash);
                                        }
                                    }
                                    Console.WriteLine("Перевод успешно выполнен!");
                                    Console.ReadKey(true);
                                    break;
                                case "4":
                                    Console.WriteLine($"На вашем счёте {accounts[currentAccNumber].Balance} рублей");
                                    Console.ReadKey(true);
                                    break;
                                case "5":
                                    flag2 = false;
                                    break;
                                default:
                                    break;
                            }
                        }
                        break;
                    case "4":
                        Console.WriteLine("Введите номер счёта");
                        BankAccNumber Number = new BankAccNumber();
                        if (!Number.Input(Console.ReadLine()))
                        {
                            break;
                        }

                        foreach (BankAccNumber receiverAccNumber in accounts.Keys)
                        {
                            if (Number.bank == receiverAccNumber.bank && Number.self == receiverAccNumber.self)
                            {
                                accounts.Remove(Number);
                            }
                        }
                        Console.WriteLine("Аккаунт успешно удалён!");
                        Console.ReadKey(true);
                        break;
                    case "5":
                        flag1 = false;
                        break;
                    default:
                        break;
                }
            }
        }
        public static void Main(string[] args) 
        {
            FirstExercise();
            Console.WriteLine();
        }
    }
}
