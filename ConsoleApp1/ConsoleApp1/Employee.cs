using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Linq;

namespace AtudaimProject
{
    class Employee
    {

        public string EmployeeName { get; set; } // employee's name.
        public int EmployeeId { get; set; }  // employee's Id.

        public static double EmployeeWorkTime; // employee's total work time.

        public Dictionary<string, int> EmployeeNameAndId = new Dictionary<string, int>(); // creating Employee dict.
        public Dictionary<string, string> EmployeeAndCostumers = new Dictionary<string, string>(); // dict of the Employee's and costumer's name.
        public Dictionary<int, DateTime> EmployeeOpenTime = new Dictionary<int, DateTime>(); // dict of Employee open shift time.
        public Dictionary<int, DateTime> EmployeeEndTime = new Dictionary<int, DateTime>(); // dict of Employee end shift time.
        public Dictionary<int, double> EmployeeIdAndSalary = new Dictionary<int, double>(); // dict of Employee and his salary.


        public void EmployeeProfile() // adding Employew's to the shift.
        {
            try
            {
                Console.WriteLine("Enter employee's name:"); // creating employe name.
                EmployeeName = Console.ReadLine();
                Console.WriteLine("Enter employee's Id:"); // Getting employe Id.
                EmployeeId = Convert.ToInt32(Console.ReadLine());

                EmployeeNameAndId.Add(EmployeeName, EmployeeId); // Adding the Name and Id that we received from the user.
                Console.WriteLine($"");

                foreach (var item in EmployeeNameAndId)
                {
                    if (item.Value == EmployeeNameAndId[EmployeeName]) // showing the spesific Employe adding. 
                    {
                        Console.WriteLine($"--------------------\nEmployee Name: {item.Key}, Employee Id: {item.Value} has been added.\n---------------------------");
                    }

                }
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Please Enter a Numer!");
                
            }

        }
        
        public void EmployeeOpenShift()
        {
            try
            {
                Console.WriteLine("Enter employee's Id:"); // Getting employe Id.
                int checkEmployeeId;
                checkEmployeeId = Convert.ToInt32(Console.ReadLine());
                DateTime realTime = DateTime.Now; // joining shift time
                DateTime moreTime = DateTime.Now;
                realTime.AddSeconds(moreTime.Second);
                    foreach (var emp in EmployeeNameAndId) // Showing the data to the user.
                    {
                        if (checkEmployeeId == EmployeeNameAndId[EmployeeName]) // showing the spesific Employe adding. 
                        {
                        EmployeeOpenTime.Add(EmployeeId, realTime); // Adding the Id and Time that we received from the user.
                        Console.WriteLine($"--------------------\nEmployee Name: {emp.Key}, Employee Id: {emp.Value} has been added in {realTime}.\n---------------------------");
                        }
                        else
                        {
                            Console.WriteLine("Id Doesn't Exsit!\nPlease add the Employee first.\n---------------------------");
                        }

                    }
                    
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Please Enter A number!");

            }
            catch (System.ArgumentException)
            {
                DateTime moreTime = DateTime.Now;
                EmployeeOpenTime[EmployeeId] =  moreTime;
                Console.WriteLine($"{EmployeeOpenTime[EmployeeId]}");

            }
        
            
        }
        public void EmployeeEndShift() // Ending Employee's shift time.
        {
            try
            {
                Console.WriteLine("Enter employee's Id:"); // creating employe Id.
                DateTime EndTime = DateTime.Now; // exiting shift time.
                int checkEmployeeId;
                checkEmployeeId = Convert.ToInt32(Console.ReadLine());
                EmployeeEndTime.Add(EmployeeId, EndTime);
                foreach (var emp1 in EmployeeNameAndId)
                {
                    if (checkEmployeeId == EmployeeNameAndId[EmployeeName])
                    {
                        Console.WriteLine($"--------------------\nEmployee Name: {emp1.Key}, Employee Id: {EmployeeId} has been ended his shift in {EndTime}.\n--------------------\n");
                    }
                    else
                    {
                        Console.WriteLine("---------------------------\nId Doesn't Exsit!\nPlease add the Employee first.\n---------------------------");
                    }

                }

            }
            catch (System.FormatException) // alert when the Employee doesn't enter a number.
            {
                Console.WriteLine("Please enter a number!");
                
            }
            catch (System.ArgumentException) // alert when the employee enter used id
            {
                Console.WriteLine("This Id already exist!");
            }  
        }

        public void EmployeeShiftStatus()
        {
            try
            {
                Console.WriteLine("Enter employee's Id:"); // creating employe Id.
                int checkEmployeeId;
                checkEmployeeId = Convert.ToInt32(Console.ReadLine());

                foreach (var emplo in EmployeeNameAndId)
                {
                    if (EmployeeNameAndId.ContainsValue(checkEmployeeId))
                    {
                        Console.WriteLine($"----------------------------\nEmployee's Name: {emplo.Key}\n- started his shift at:{EmployeeOpenTime[EmployeeId]}.\n- Ended at:{EmployeeEndTime[EmployeeId]}.\n- The Employee total time work {Math.Round(EmployeeEndTime[EmployeeId].Subtract(EmployeeOpenTime[EmployeeId]).TotalHours, 3)} Hours.\n----------------------------");

                    }
                    else
                    {
                        Console.WriteLine("Check your input please!");
                    }
                }
            }
            catch (System.FormatException)
            {
               Console.WriteLine("Please enter a number!");
            }
            catch (System.Collections.Generic.KeyNotFoundException)
            {
                Console.WriteLine("Employee's shift doesnt ended!");
            }
        }

            double WorkingHour = 30;                                                                                                      
        public void EmployeeSalary()
        {
            Console.WriteLine("Enter employee's Id:"); // Entering employee's Id.
            EmployeeId = Convert.ToInt32(Console.ReadLine());
            EmployeeWorkTime = EmployeeEndTime[EmployeeId].Subtract(EmployeeOpenTime[EmployeeId]).TotalHours; // checking how much the Employee earned.

            double totalSalary = 0d; // starting salary for every employee.
            totalSalary += EmployeeWorkTime * WorkingHour; // salary count.
            EmployeeIdAndSalary.Add(EmployeeId, totalSalary);
            Console.WriteLine($"Employee's name:{EmployeeName}.\nEmployee's salary: Earned {Math.Round(EmployeeIdAndSalary[EmployeeId], 2)} New Shekels.");

        }

        public void EmployeeAndCorona()
        {
            try
            {
            Console.WriteLine("Enter employee's Id:"); // Entering employee's Id.
            int checkEmployeeId;
            checkEmployeeId = Convert.ToInt32(Console.ReadLine());
                if (EmployeeNameAndId.ContainsValue(checkEmployeeId))
                {
                    double coronaFine = 40;
                    Math.Round(EmployeeIdAndSalary[EmployeeId] -= coronaFine, 2);

                    Console.WriteLine($"Employee's name: {EmployeeName}.\nEmployee's salary after corona's fine: {EmployeeIdAndSalary[EmployeeId]} New Shekels.\n----------------------------\nYou need to work 1.5 hour's to pay you finr (40 New Shekels)\n----------------------------");
                }
                else
                {
                    Console.WriteLine("---------------------------\nId Doesn't Exsit!\nPlease add the Employee first.\n---------------------------");
                }

            }
            catch (System.FormatException)
            {
                Console.WriteLine("Please enter a number!");
            }

        }
        /*
        public void RemoveProfile() //removimg an Employee.
        {
            try
            {
                EmployeeOpenTime.Add(EmployeeId, realTime.ToString()); // adding employee Id and his

            }
            catch (System.ArgumentException)
            {
                Console.WriteLine("Employee's Id is not Exist!");
            }
        }
        
        */
        
    }
}
