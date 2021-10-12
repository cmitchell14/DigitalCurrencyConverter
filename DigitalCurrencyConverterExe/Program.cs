using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalCurrencyConverterLibrary;

namespace DigitalCurrencyConverterExe
{
    class Program
    {
        static void Main(string[] args)
        {
            Cash cash = new Cash(5000);
            Bitcoin bitcoin = new Bitcoin(8564);
            Litecoin litecoin = new Litecoin(0);
            Etherium etherium = new Etherium(0);

            bool exitMainMenu = false;

            Console.WriteLine("Welcome to the Digital Currency Convertor.\n\nPlease make a selection below:");
            Console.ReadKey();
            do
            {
                Console.Clear();
                Console.WriteLine("\n\nSee Account Balances: 'A'\nTransfer between Currencies: 'T'\nExit Program: 'E'");
                ConsoleKey choice = Console.ReadKey().Key;

                switch (choice)
                {
                    case ConsoleKey.A:
                        Console.Clear();
                        Console.WriteLine($"Cash Amount: {cash}\nBitcoin Value: {bitcoin}\nLitecoin Value: {litecoin}\nEtherium Value: {etherium}");
                        bool accountClose = false;

                        do
                        {
                            Console.Write("\n\n\nWould you like to make a new selection?  Y/N");
                            ConsoleKey menuChoice = Console.ReadKey().Key;
                            switch (menuChoice)
                            {
                                case ConsoleKey.Y:
                                    accountClose = true;
                                    break;
                                case ConsoleKey.N:
                                    Console.Clear();
                                    Console.ReadKey();
                                    exitMainMenu = true;
                                    accountClose = true;
                                    break;
                                default:
                                    Console.WriteLine("Please choose a valid option...");
                                    break;
                            }
                        } while (!accountClose);
                        break;

                    case ConsoleKey.T:
                        bool transferClose = false;
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("Choose a currency to transfer to:\n\nC)ash\nB)itcoin\nL)itecoin\nE)therium");
                            ConsoleKey transferTo = Console.ReadKey().Key;


                            
                            switch (transferTo)
                            {
                                #region Transfer to Cash Account
                                case ConsoleKey.C:
                                    transferClose = true;
                                    bool transferMenu = false;
                                    do
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Please choose an account to transfer from: \nB)itcoin\nL)itecoin\nE)therium");
                                        ConsoleKey transferFrom = Console.ReadKey().Key;
                                        switch (transferFrom)
                                        {
                                            case ConsoleKey.B:
                                                Console.WriteLine($"You have {bitcoin}. How much would you like to transfer?");
                                                decimal transferBit = Convert.ToDecimal(Console.ReadLine());
                                                if (transferBit > bitcoin.Amount)
                                                {
                                                    Console.WriteLine("Not enough available funds to complete transaction.");
                                                }
                                                else
                                                {
                                                    bitcoin.Amount = bitcoin.Amount - transferBit;
                                                    Cash newCash = Currency.GetCashValue(bitcoin);
                                                    cash.Amount = cash.Amount + newCash.Amount;
                                                    Console.WriteLine("Transfer has been completed");

                                                    transferMenu = true;
                                                }

                                                break;
                                            case ConsoleKey.L:

                                                Console.WriteLine($"You have {litecoin}.  How much would you like to transfer?");
                                                decimal transferLit = Convert.ToDecimal(Console.ReadLine());
                                                if (transferLit > litecoin.Amount)
                                                {
                                                    Console.WriteLine("Not enough available funds to complete transaction.");
                                                }
                                                else
                                                {
                                                    litecoin.Amount = litecoin.Amount - transferLit;
                                                    Cash newCash = Currency.GetCashValue(litecoin);
                                                    cash.Amount = cash.Amount + newCash.Amount;
                                                    Console.WriteLine("Transfer has been completed");

                                                    transferMenu = true;
                                                }

                                                break;
                                            case ConsoleKey.E:
                                                Console.WriteLine($"You have {etherium}. How much would you like to transfer?");
                                                decimal transferEth = Convert.ToDecimal(Console.ReadLine());
                                                if (transferEth > etherium.Amount)
                                                {
                                                    Console.WriteLine("Not enough available funds to complete transaction.");
                                                }
                                                else
                                                {
                                                    etherium.Amount = etherium.Amount - transferEth;
                                                    Cash newCash = Currency.GetCashValue(etherium);
                                                    cash.Amount = cash.Amount + newCash.Amount;
                                                    Console.WriteLine("Transfer has been completed");

                                                    transferMenu = true;
                                                }
                                                break;
                                            default:
                                                Console.WriteLine("Please choose a valid option");
                                                break;
                                        }
                                    } while (!transferMenu);
                                    #endregion

                                    break;

                                #region Transfer to Bitcoin Account
                                case ConsoleKey.B:
                                    transferClose = true;
                                    bool transferMenuB = false;
                                    do
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Please choose an account to transfer from: \nC)ash\nL)itecoin\nE)therium");
                                        ConsoleKey transferFrom = Console.ReadKey().Key;
                                        switch (transferFrom)
                                        {
                                            case ConsoleKey.C:
                                                Console.WriteLine($"You have {cash}. How much would you like to transfer?");
                                                decimal transferCash = Convert.ToDecimal(Console.ReadLine());
                                                if (transferCash > cash.Amount)
                                                {
                                                    Console.WriteLine("Not enough available funds to complete transaction.");
                                                }
                                                else
                                                {
                                                    cash.Amount = cash.Amount - transferCash;
                                                    Cash newCash = new Cash(transferCash);
                                                    Bitcoin newBitcoin = Cash.GetBitcoin(newCash);
                                                    bitcoin.Amount = bitcoin.Amount + newBitcoin.Amount;
                                                    Console.WriteLine("Transfer has been completed");

                                                    transferMenuB = true;
                                                }

                                                break;
                                            case ConsoleKey.L:

                                                Console.WriteLine($"You have {litecoin}.  How much would you like to transfer?");
                                                decimal transferLit = Convert.ToDecimal(Console.ReadLine());
                                                if (transferLit > litecoin.Amount)
                                                {
                                                    Console.WriteLine("Not enough available funds to complete transaction.");
                                                }
                                                else
                                                {
                                                    litecoin.Amount = litecoin.Amount - transferLit;
                                                    Litecoin newLitecoin = new Litecoin(transferLit);
                                                    Cash newCash = Currency.GetCashValue(newLitecoin);
                                                    Bitcoin newBitcoin = Cash.GetBitcoin(newCash);
                                                    bitcoin.Amount = bitcoin.Amount + newBitcoin.Amount;
                                                    Console.WriteLine("Transfer has been completed");

                                                    transferMenuB = true;
                                                }

                                                break;
                                            case ConsoleKey.E:
                                                Console.WriteLine($"You have {etherium}. How much would you like to transfer?");
                                                decimal transferEth = Convert.ToDecimal(Console.ReadLine());
                                                if (transferEth > etherium.Amount)
                                                {
                                                    Console.WriteLine("Not enough available funds to complete transaction.");
                                                }
                                                else
                                                {
                                                    etherium.Amount = etherium.Amount - transferEth;
                                                    Etherium newEtherium = new Etherium(transferEth);
                                                    Cash newCash = Currency.GetCashValue(newEtherium);
                                                    Bitcoin newBitcoin = Cash.GetBitcoin(newCash);
                                                    bitcoin.Amount = bitcoin.Amount + newBitcoin.Amount;
                                                    Console.WriteLine("Transfer has been completed");

                                                    transferMenuB = true;
                                                }

                                                break;
                                            default:
                                                Console.WriteLine("Please choose a valid option");
                                                break;
                                        }
                                    } while (!transferMenuB);
                                    #endregion

                                    break;

                                #region Transfer to Litecoin Account
                                case ConsoleKey.L:
                                    transferClose = true;
                                    bool transferMenuL = false;
                                    do
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Please choose an account to transfer from: \nC)ash\nB)itcoin\nE)therium");
                                        ConsoleKey transferFrom = Console.ReadKey().Key;
                                        switch (transferFrom)
                                        {
                                            case ConsoleKey.C:
                                                Console.WriteLine($"You have {cash}. How much would you like to transfer?");
                                                decimal transferCash = Convert.ToDecimal(Console.ReadLine());
                                                if (transferCash > cash.Amount)
                                                {
                                                    Console.WriteLine("Not enough available funds to complete transaction.");
                                                }
                                                else
                                                {
                                                    cash.Amount = cash.Amount - transferCash;
                                                    Cash newCash = new Cash(transferCash);
                                                    Litecoin newLitecoin = Cash.GetLitecoin(newCash);
                                                    litecoin.Amount = litecoin.Amount + newLitecoin.Amount;
                                                    Console.WriteLine("Transfer has been completed");

                                                    transferMenuL = true;
                                                }

                                                break;
                                            case ConsoleKey.B:

                                                Console.WriteLine($"You have {bitcoin}.  How much would you like to transfer?");
                                                decimal transferBit = Convert.ToDecimal(Console.ReadLine());
                                                if (transferBit > bitcoin.Amount)
                                                {
                                                    Console.WriteLine("Not enough available funds to complete transaction.");
                                                }
                                                else
                                                {
                                                    bitcoin.Amount = bitcoin.Amount - transferBit;
                                                    Bitcoin newBitcoin = new Bitcoin(transferBit);
                                                    Cash newCash = Currency.GetCashValue(newBitcoin);
                                                    Litecoin newLitecoin = Cash.GetLitecoin(newCash);
                                                    litecoin.Amount = litecoin.Amount + newLitecoin.Amount;
                                                    Console.WriteLine("Transfer has been completed");

                                                    transferMenuL = true;
                                                }

                                                break;
                                            case ConsoleKey.E:
                                                Console.WriteLine($"You have {etherium}. How much would you like to transfer?");
                                                decimal transferEth = Convert.ToDecimal(Console.ReadLine());
                                                if (transferEth > etherium.Amount)
                                                {
                                                    Console.WriteLine("Not enough available funds to complete transaction.");
                                                }
                                                else
                                                {
                                                    etherium.Amount = etherium.Amount - transferEth;
                                                    Etherium newEtherium = new Etherium(transferEth);
                                                    Cash newCash = Currency.GetCashValue(newEtherium);
                                                    Litecoin newLitecoin = Cash.GetLitecoin(newCash);
                                                    litecoin.Amount = litecoin.Amount + newLitecoin.Amount;
                                                    Console.WriteLine("Transfer has been completed");

                                                    transferMenuL = true;
                                                }

                                                break;
                                            default:
                                                Console.WriteLine("Please choose a valid option");
                                                break;
                                        }
                                    } while (!transferMenuL);
                                    #endregion

                                    break;

                                #region Transfer to Etherium Account
                                case ConsoleKey.E:
                                    transferClose = true;
                                    bool transferMenuE = false;
                                    do
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Please choose an account to transfer from: \nC)ash\nB)itcoin\nL)itecoin");
                                        ConsoleKey transferFrom = Console.ReadKey().Key;
                                        switch (transferFrom)
                                        {
                                            case ConsoleKey.C:
                                                Console.WriteLine($"You have {cash}. How much would you like to transfer?");
                                                decimal transferCash = Convert.ToDecimal(Console.ReadLine());
                                                if (transferCash > cash.Amount)
                                                {
                                                    Console.WriteLine("Not enough available funds to complete transaction.");
                                                }
                                                else
                                                {
                                                    cash.Amount = cash.Amount - transferCash;
                                                    Cash newCash = new Cash(transferCash);
                                                    Etherium newEth = Cash.GetEtherium(newCash);
                                                    etherium.Amount = etherium.Amount + newEth.Amount;
                                                    Console.WriteLine("Transfer has been completed");

                                                    transferMenuE = true;
                                                }

                                                break;
                                            case ConsoleKey.B:

                                                Console.WriteLine($"You have {bitcoin}.  How much would you like to transfer?");
                                                decimal transferBit = Convert.ToDecimal(Console.ReadLine());
                                                if (transferBit > bitcoin.Amount)
                                                {
                                                    Console.WriteLine("Not enough available funds to complete transaction.");
                                                }
                                                else
                                                {
                                                    bitcoin.Amount = bitcoin.Amount - transferBit;
                                                    Bitcoin newBitcoin = new Bitcoin(transferBit);
                                                    Cash newCash = Currency.GetCashValue(newBitcoin);
                                                    Etherium newEth = Cash.GetEtherium(newCash);
                                                    etherium.Amount = etherium.Amount + newEth.Amount;
                                                    Console.WriteLine("Transfer has been completed");

                                                    transferMenuE = true;
                                                }

                                                break;
                                            case ConsoleKey.L:
                                                Console.WriteLine($"You have {litecoin}. How much would you like to transfer?");
                                                decimal transferLite = Convert.ToDecimal(Console.ReadLine());
                                                if (transferLite > litecoin.Amount)
                                                {
                                                    Console.WriteLine("Not enough available funds to complete transaction.");
                                                }
                                                else
                                                {
                                                    litecoin.Amount = litecoin.Amount - transferLite;
                                                    Litecoin newLite = new Litecoin(transferLite);
                                                    Cash newCash = Currency.GetCashValue(newLite);
                                                    Etherium newEth = Cash.GetEtherium(newCash);
                                                    etherium.Amount = etherium.Amount + newEth.Amount;
                                                    Console.WriteLine("Transfer has been completed");

                                                    transferMenuE = true;
                                                }

                                                break;
                                            default:
                                                Console.WriteLine("Please choose a valid option");
                                                break;
                                        }
                                    } while (!transferMenuE);

                                    #endregion

                                    break;

                                default:
                                    Console.WriteLine("Please choose a valid option.");
                                    Console.ReadKey();
                                    break;
                            }

                        } while (!transferClose);

                        break;

                    case ConsoleKey.E:
                        Console.Clear();
                        Console.WriteLine("Thanks for using this program.  Good Bye.");
                        exitMainMenu = true;
                        break;

                    default:
                        Console.WriteLine("Please choose a valid option.");
                        break;
                }

            } while (!exitMainMenu);

        }
    }
}
