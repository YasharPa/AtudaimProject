using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Linq;

namespace AtudaimProject
{
    
    
    class Cashier
    {
        Costumer costumer2 = new Costumer(); // calling the costumer calss.
        Product product2 = new Product();  //calling the Product calss.
        Employee employee2 = new Employee(); //calling the Employee calss.

        public int cashierBoxId { get; set; }
        public  static DateTime OpeningTime = DateTime.Now; // creating the cashier opening time.
        public string stringTime = OpeningTime.ToString();


        //Public Dict's.
        public Dictionary<int, string> cashierBoxIdAndTime = new Dictionary<int, string>(); // Dict of the cashier and opening time.
        public Dictionary<string, string> CostumerAndProd = new Dictionary<string, string>(); // dict of the costumer with his products.

        public Dictionary<string, string> EmployeeAndCostumer = new Dictionary<string, string>(); // dict of the Employee with his Costumers.
        public Dictionary<int, int> EmployeeAndCashier = new Dictionary<int, int>(); // dict of the Employee and the cashier.
        public Dictionary<int, List<string>> CashierAndCostumer = new Dictionary<int, List<string>>(); // dict of the costumer and the cashier.
        public List<string> AddCostumer = new List<string>();
        


        public void CostumerAndProduct() // function that attaching costumer with his products.
        {
            
            Console.WriteLine("Enter Cashier Id:"); // taking the cashier Id.
            cashierBoxId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter costumer's Name:"); //Entering costumer's name.
            costumer2.CostumerName = Console.ReadLine();

            Console.WriteLine("Enter costumers products:"); // taming costumer products.
            product2.product = Console.ReadLine();
            try
            {
                CostumerAndProd.Add(costumer2.CostumerName, product2.product); // adding the costumer name with his products to dict.
                //CashierAndCostumer.Add(cashierBoxId, new List<string>());
        
                AddCostumer.Add(costumer2.CostumerName + ", "); // Adding the costumer name to the cashier.
                CashierAndCostumer.Add(cashierBoxId, AddCostumer); // Adding the costumer name to the cashier.

                foreach (var name in CostumerAndProd)
                {
                    if (name.Value == CostumerAndProd[costumer2.CostumerName])
                    {
                    Console.WriteLine($"The costumer is: {costumer2.CostumerName}, and his products are {product2.product}.\nAlso the cashier Id was {cashierBoxId}.\n-------------------------");

                    }
                }

            }
            catch (System.ArgumentException)
            {
                string anotherCostumer = costumer2.CostumerName;
                CashierAndCostumer[cashierBoxId].Add(anotherCostumer);
                Console.WriteLine("Try Again!");

            }

        }


        public void OpenCashier() // method that opens a cashier.
            {
               
            try // checking if the cashier was opend.
            {
                // creating employee's name.
                Console.WriteLine("Enter employee's name:");
                employee2.EmployeeName = Console.ReadLine();

                // creating employee's name.
                Console.WriteLine("Enter employee's Id:");
                employee2.EmployeeId = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Cashier Id:"); // taking the cashier Id.
                cashierBoxId = Convert.ToInt32(Console.ReadLine());
            
                employee2.EmployeeNameAndId.Add(employee2.EmployeeName, employee2.EmployeeId); // add the employee name and id to the Employees data.
                cashierBoxIdAndTime.Add(cashierBoxId, stringTime); // adding the cashier to dict.
                EmployeeAndCashier.Add(cashierBoxId, employee2.EmployeeId); // adding the employee and cashier id to a dict.
                    
                // showing the opend cashier.
                Console.WriteLine($"-------------------------\nYour cashier by id {cashierBoxId}, opened at {stringTime },\n By {employee2.EmployeeName}, in Id {employee2.EmployeeId}.\n-------------------------");
                

            }
            catch (System.ArgumentException) 
            {
                Console.WriteLine($"-------------------------\nThe cashier was opend before at {stringTime}.\n-------------------------Adding the new time..-------------------------");
                DateTime moreTime = DateTime.Now;
                string AnotherTime = moreTime.ToString();
                cashierBoxIdAndTime[cashierBoxId] = (stringTime +=  ", " + AnotherTime); // adding the cashier to dict.

                foreach (var item in cashierBoxIdAndTime)
                {
                    //EmployeeAndCashier[cashierBoxId] = (", " + anotherEmployee);
                    Console.WriteLine($"Your cashier by id {item.Key},\nOpend at {item.Value}.\n-------------------------");
                }

                

                //Console.WriteLine($"Your cashier by id {cashierBoxId} opened at {cashierBoxIdAndTime[cashierBoxId]}\n By {employee2.EmployeeName}, in Id {employee2.EmployeeId}.\n-------------------------");
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Please Enter A number!");
            }

        }
        public void CashierTimeStatus() // method that checks  when  the chashier opend.
        {
            Console.WriteLine("Enter Cashier Id:"); // taking the cashier Id.
            cashierBoxId = Convert.ToInt32(Console.ReadLine());
            try // Checking if the cashier is in our dict.
            {
                        string Employeename = employee2.EmployeeName;
                        Console.WriteLine($"Your cashier was opend Last by {Employeename} at {cashierBoxIdAndTime[cashierBoxId]}.\n------------------------- ");

            }
            catch (System.Collections.Generic.KeyNotFoundException) // catching the eror of chashier Id that not in our dict.
            {
                Console.WriteLine("the cashier isn't Avilable!\n-------------------------");
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Please Enter A number!");
            }
        }
        public void CloseCashier() // Method that remove the cashier.
        {
            Console.WriteLine("Enter Cashier Id:"); // taking the cashier Id.
            cashierBoxId = Convert.ToInt32(Console.ReadLine());
            if (cashierBoxIdAndTime.TryGetValue(cashierBoxId, out stringTime))
            {
                cashierBoxIdAndTime.Remove(cashierBoxId);
                Console.WriteLine($"Cashier id {cashierBoxId} is Closed!\n-------------------------");
            }
            else
            {
                Console.WriteLine($"Cashier id {cashierBoxId} isn't Avilable!\n-------------------------");
            }


        }

        public void AvailableCashier()
        {
            try
            {

                foreach (KeyValuePair <int, List <string>> item in CashierAndCostumer)
                {
                        Console.WriteLine($"The cashier by Id {item.Value.Count.ToString().Min()} is available.");                    
                }
                if (CashierAndCostumer.Count == 0)
                {
                    Console.WriteLine("All the cashier's are available!\n--------------------------");
                }
            }
            catch (System.InvalidOperationException)
            {
                Console.WriteLine("All the cashier's are available!\n--------------------------");
            }

        }

        public void EmployeeCostumers() // checks which employee and costumers need to be isolated.
        {
            try
            {
               // var CostuemrNameList = new List<string>(); // cotumer adding List. 
                Console.WriteLine("Enter Cashier Id:"); // taking the cashier Id.
                cashierBoxId = Convert.ToInt32(Console.ReadLine());
                EmployeeAndCostumer.Add(employee2.EmployeeName, AddCostumer.ToString()); // adding to dict the employee's name and the costumer's name .    
                Console.WriteLine($"Employee that need to be isolated: {employee2.EmployeeName}.\nCostumer's that need to be isolated:");
                foreach (var costumer in AddCostumer)
                {
                    Console.WriteLine($"{costumer}");
                }



            }
            catch (Exception)
            {
                Console.WriteLine("unavailable Cashier!");
            }


        }



    }
        

}



