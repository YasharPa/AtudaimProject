using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace AtudaimProject
{
    
    class Program
    {
        static void Main(string[] args)
        {
            Costumer costumer1 = new Costumer(); // calling the costumer class.
            ShopQueue costumerQueue = new ShopQueue(); // calling the shop class.
            ArrayList CostumerQueue = new ArrayList(); // creating ew list.
            Product product1 = new Product(); // calling the protuct class.
            Cashier cashier1 = new Cashier(); // calling the Cashier class.
            Employee employee1 = new Employee(); // calling the employee class.

            Console.WriteLine("-------------------------\nHello to Agam's store! \nhere you can buy everything you need.\n\nHave fun!\n\nExit -> type *\n----------------------------------- ");
            string WantToExit = Console.ReadLine(); // main screen.
            
            do          
            {

                    
                    Console.WriteLine("Type your option:\n1. The line System.\n2. The Cashier System.\n3. The Employee System.\nExit -> *\n-------------------------");
                    string costumerInput = Console.ReadLine();

                do
                {
                    
                        WantToExit = costumerInput; // Exiting the while program.
                        
                    if (costumerInput == "1")
                    {
                        Console.WriteLine("Type your option:\n1. Count your costumers.\n2. Add costumer.\n3. Enter costumer's to the store. \n4. Names of your costumers.\nExit -> *\n-------------------------");
                        string LineInput = Console.ReadLine();


                        switch (LineInput) // the line system.
                        {
                            case "1": // Costumer's count.
                                Console.WriteLine($"You have {CostumerQueue.Count} costumers in the line.");
                                break;

                            case "2": // Adding a costumer.
                                Console.WriteLine("Enter costumer name:"); // Asking the costumers name.
                                costumer1.CostumerName = Console.ReadLine();

                                Console.WriteLine("\nPlease enter costumer's body tempature:"); // Taking the costumer's body temperature.
                                costumer1.CostumerBodyTemp = double.Parse(Console.ReadLine());

                                Console.WriteLine("The costumer is not in quarantine and have a mask?\n1. yes\n2. no\n-------------------------"); // Asking if the costumer have a mask and not in quarantine.
                                costumer1.MaskWearing = int.Parse(Console.ReadLine());
                                if (CoronaAndMaskStatus(costumer1.CostumerBodyTemp, costumer1.MaskWearing) == true) // checking if he can enter out shop.
                                {
                                    CostumerQueue.Add(costumer1.CostumerName); // Adding the costumer to the list.               
                                }
                                string addingCostumer = Console.ReadLine();
                                break;

                            case "3": // Entering Costumer's To the store.
                                try
                                {
                                    Console.WriteLine("How much do you want to Enter? ");
                                    int removeCostumer = Convert.ToInt32(Console.ReadLine());
                                    CostumerQueue.RemoveRange(0, removeCostumer);
                                }
                                catch (ArgumentException)
                                {
                                    Console.WriteLine("You dont have costumers.");
                                }
                                break;


                            case "4": // the costumers that in the line.
                                if (CostumerQueue.Count == 0) // return  massage if he dosent have any cotumers.
                                {
                                    Console.WriteLine("You dont have costumers yet.");
                                    break;
                                }
                                Console.WriteLine($"You have {CostumerQueue.Count} costumers in the store");
                                Console.WriteLine("the costumer's name's are: ");
                                costumerQueue.CostumerList(); // calling the costumer list name method.
                                break;

                            case "*": // getting  into the Main screen.
                                Console.WriteLine("Exit to the main menu.\nGood Luck..\n---------------------------------\n");
                                costumerInput = "*";
                                break;

                            default:
                                Console.WriteLine("---------------------------------\nCheck your input please!\n---------------------------------");
                                break;


                        };

                    }
                    else if (costumerInput == "2")
                    {
                        Console.WriteLine("Enter your option:\n1. Open a cashier box.\n2. Remove a cashier\n3. Check when the cashier opend.\n4. Add a cotumer with products.\n5. Check which cashier is available\n6. Isolate an Employee.\nExit -> *\n-------------------------");
                        string LineInput2 = Console.ReadLine();
                                                
                        switch (LineInput2)
                        {
                            case "1":
                                cashier1.OpenCashier(); // for opening a cashier.
                                break;

                            case "2":
                                cashier1.CloseCashier(); // for closing a cashier.
                                break;

                            case "3":
                                cashier1.CashierTimeStatus(); // checking when the chashier was opend.
                                break;

                            case "4":
                                cashier1.CostumerAndProduct(); // adding a cotumer with his products to a cashier.                               
                                break;

                            case "5":
                                cashier1.AvailableCashier(); // checks which cashier is The most available.                                  
                                break;

                            case "6":
                                cashier1.EmployeeCostumers(); // telling who need to be isolated.                                
                                break;

                            case "*": // getting  into the Main screen.
                                Console.WriteLine("Exit to the main menu.\nGood Luck..\n---------------------------------\n");
                                costumerInput = "*";
                                break;

                            default:
                                Console.WriteLine("---------------------------------\nCheck your input please!\n---------------------------------");
                                break;
                        }


                     

                    }
                    else if (costumerInput == "3")
                    {
                        Console.WriteLine("1. Add an Employee.\n2. Open Employee's shift.\n3. End Employee's shfit.\n4. Check employee's open and end shift time.\n5. Check employee's salary.\n6. Fine your Employee.\nExit -> *\n---------------------------------");
                        string LineInput3 = Console.ReadLine();
                        switch (LineInput3)
                        {
                            case "1":
                                employee1.EmployeeProfile(); // Adding employee to the shift.
                                break;

                            case "2":
                                employee1.EmployeeOpenShift(); // Opening Employee's shift.
                                break;

                            case "3":
                                employee1.EmployeeEndShift(); // Ending employee's shift.
                                break;

                            case "4":
                                employee1.EmployeeShiftStatus(); // Checking how much the employee worked.
                                break;

                            case "5":
                                employee1.EmployeeSalary(); // Employee's salary.
                                break;

                            case "6":
                                employee1.EmployeeAndCorona(); // Corona fine.
                                break;

                            case "*": // getting  into the Main screen.
                                Console.WriteLine("Exit to the main menu.\nGood Luck..\n---------------------------------\n");
                                costumerInput = "*";
                                break;
                            default:
                                Console.WriteLine("---------------------------------\nCheck your input please!\n---------------------------------");
                                break;
                        }

                    }else if(costumerInput == "*")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("---------------------------------\nCheck your input please!\n---------------------------------");
                        break;
                    }


                } while (costumerInput != "*");


            } while (WantToExit != "*") ;            

        }
        static bool CoronaAndMaskStatus(double Bodytemperatur, int ThereIaMask) // craeting a function that checks if the cotumer is fealing good and wearing a mask.
        {
            
            if (Bodytemperatur >= 36 && Bodytemperatur <= 38.8 && ThereIaMask == 1)
            {
                Console.WriteLine("Great!\nHe/She can wait in the line to our shop.");
                return true;
            }   
            else
            {
                Console.WriteLine("Get out please..");
                return false;
            }

        }
                

    }
}

//last version.