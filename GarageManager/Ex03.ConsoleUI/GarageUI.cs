using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class GarageUI
    {
        public static Garage m_OurGarage = new Garage();

        public static void StartManage()
        {
            Array typesOfVehicles = Enum.GetValues(typeof(eVehicleType));
            m_OurGarage.AddOperations();
            MainMenu();
        }

        private static void MainMenu()
        {
            printGarageWelcome();
            displayGarageOperations();
            int operationChoiceNumber = getUserChoice(m_OurGarage.GarageOperations.Count);
            while (operationChoiceNumber > 0 && operationChoiceNumber <= m_OurGarage.GarageOperations.Count)
            {
                Console.Clear();
                printGarageWelcome();
                    if (operationChoiceNumber == 1)
                    {
                        insertVehicleProcess();
                    }
                    else if (operationChoiceNumber == 2)
                    {
                        checkGarageVehicles();
                        printListByLicenseNumber();
                    }
                    else if (operationChoiceNumber == 3)
                    {
                        checkGarageVehicles();
                        printVehicleDetails();
                    }
                    else if (operationChoiceNumber == 4)
                    {
                        checkGarageVehicles();
                        addOperations();
                    }
                    else if (operationChoiceNumber == 5)
                    {
                        checkGarageVehicles();
                        changeStatusProcess();
                    }
                    else
                    {
                    Console.ForegroundColor = ConsoleColor.Red;
                    System.Console.WriteLine("\n\nIllegal value, please type again");
                    Console.ForegroundColor = ConsoleColor.White;
                    operationChoiceNumber = getUserChoice(m_OurGarage.GarageOperations.Count);
                    }
            }
        }

        private static void printGarageWelcome()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            System.Console.WriteLine("\n============================= Hello! Welcome to Tal and Hadar's Garage =============================\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void displayMainMenu()
        {
            System.Console.WriteLine("\n\n\nIf you want to go back to the main menu, please press 0");
            string choice = System.Console.ReadLine();
            while (choice != "0")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine("\n\nIllegal value, please type again");
                Console.ForegroundColor = ConsoleColor.White;
                choice = System.Console.ReadLine();
            }
        
            if (choice == "0")
            {
                Console.Clear();
                MainMenu();
            }
        }

        private static void insertVehicleProcess()
        {
            displayVehicles();
            int vehicleChoiceNumber = getUserChoice(Enum.GetValues(typeof(eVehicleType)).Length);
            eVehicleType customerVehicleType = (eVehicleType)Enum.GetValues(typeof(eVehicleType)).GetValue(vehicleChoiceNumber - 1);
            Customer newCustomer = new Customer(customerVehicleType);
            registerNewCustomer(newCustomer, customerVehicleType);
            displayVehicleMethods(newCustomer, customerVehicleType);
        }

        private static void printListByLicenseNumber()
        {
            Console.Clear();
            printGarageWelcome();
            System.Console.WriteLine("\nList of vehicles in the garage:\n");
            foreach (KeyValuePair<Customer, eStatus> item in m_OurGarage.GarageCustomers)
            {
                Console.WriteLine("License Number: {0}, Status: {1}", item.Key.Vehicle.LicenseNumber, item.Value);
            }

            System.Console.WriteLine("\n\n\nIf you want to sort the list, press s, otherwise press any key to go back to the main menu");
            if (System.Console.ReadLine() == "s")
            {
                printSortedListByLicenseNumber();
            }
            else
            {
                Console.Clear();
                MainMenu();
            }
        }

        private static void printSortedListByLicenseNumber()
        {
            Dictionary<Customer, eStatus> sortedList = new Dictionary<Customer, eStatus>();
            sortedList = m_OurGarage.GarageCustomers;
            Console.Clear();
            printGarageWelcome();
            System.Console.WriteLine("\nList of vehicles in the garage according to their status:\n");
            foreach (KeyValuePair<Customer, eStatus> item in sortedList.OrderBy(key => key.Value))
            {
                System.Console.WriteLine("License Number: {0}, Status: {1}", item.Key.Vehicle.LicenseNumber, item.Value);
            }

            displayMainMenu();
        }

        private static void printVehicleDetails()
        {
            Console.Clear();
            printGarageWelcome();
            System.Console.WriteLine("\nPlease type a license number");
            string licenseNum = System.Console.ReadLine();
            try
            {
                Vehicle currVehicle = m_OurGarage.GetVehicleByLicenseNumber(licenseNum);
                Customer currCustomer = m_OurGarage.GetCustomerByLicenseNumber(licenseNum);
                Console.Clear();
                printGarageWelcome();
                System.Console.WriteLine(currVehicle.ToString());
                System.Console.WriteLine(currVehicle.WheelsSet.ToList()[0].ToString());
                System.Console.WriteLine(currCustomer.ToString());
                System.Console.WriteLine("\nStatus In The Garage: " + m_OurGarage.GetStatus(licenseNum));
            }
            catch (VehicleNotFoundException e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine(e.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }

            displayMainMenu();
        }

        private static void changeStatusProcess()
        {
            System.Console.WriteLine("\nPlease type your vehicle's license number");
            string licenseNumber = System.Console.ReadLine();
            if (!m_OurGarage.IsInGarage(licenseNumber))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine("\nThis vehicle is not in the garage right now");
                Console.ForegroundColor = ConsoleColor.White;
                displayMainMenu();
            }

            int index = 1;
            System.Console.WriteLine("\nPlease type the new vehicle's status\n");
            foreach (eStatus status in Enum.GetValues(typeof(eStatus)))
            {
                System.Console.WriteLine(index + ". " + status + "\n");
                index++;
            }

            int statusChoice = getUserChoice(Enum.GetValues(typeof(eStatus)).Length);
            m_OurGarage.ChangeStatus(licenseNumber, (eStatus)Enum.GetValues(typeof(eStatus)).GetValue(statusChoice - 1));
            displayMainMenu();
        }

        private static int getUserChoice(int i_NumOfChoices)
        {
            bool flag = false;
            int choice = 0;

            while (!flag)
            {
                try
                {
                    choice = int.Parse(System.Console.ReadLine());
                }
                catch (FormatException)
                {
                    flag = false;
                }

                if (choice > 0 && choice <= i_NumOfChoices)
                {
                    flag = true;
                }

                if (!flag)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    System.Console.WriteLine("\n\nIllegal Choise, please try again\n");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            return choice;
        }

        private static void checkGarageVehicles()
        {
            if (m_OurGarage.GarageCustomers.Count < 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nThere are no vehicles in the garage right now");
                Console.ForegroundColor = ConsoleColor.White;
                displayMainMenu();
            }
        }

        private static void addOperations()
        {
            System.Console.WriteLine("\nPlease type your vehicle's license number");
            string licenseNumber = System.Console.ReadLine();
            if ((m_OurGarage.GarageCustomers.Count < 1) || !m_OurGarage.IsInGarage(licenseNumber))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine("This vehicle is not in the garage");
                Console.ForegroundColor = ConsoleColor.White;
                displayMainMenu();
            }
            else
            {
                displayVehicleMethods(m_OurGarage.GetCustomerByLicenseNumber(licenseNumber), m_OurGarage.GetVehicleTypeByLicenseNumber(licenseNumber));
            }                
        }

        private static void displayGarageOperations()
        {
            int index = 1;

            System.Console.WriteLine("\nWhat would you like to do?\n");
            foreach (string operation in m_OurGarage.GarageOperations)
            {
                System.Console.WriteLine(index + ". " + operation + "\n");
                index++;
            }
        }

        private static void displayVehicles()
        {
            int index = 1;
            System.Console.WriteLine("\nPlease choose the type of your vehicle\n");
            foreach (eVehicleType type in Enum.GetValues(typeof(eVehicleType)))
            {
                System.Console.WriteLine(index + ". " + getStringForVehicleType(type) + "\n");
                index++;
            }
        }

        private static string getStringForVehicleType(eVehicleType i_VehicleType)
        {
            string type = string.Empty;
            if (i_VehicleType == eVehicleType.ElectricCar)
            {
                type = "Electric Car";
            }
            else if (i_VehicleType == eVehicleType.ElectricMotorcycle)
            {
                type = "Electric Motorcycle";
            }
            else
            {
                type = string.Empty + i_VehicleType;
            }

            return type;
        }

        private static string printList(IEnumerable i_List)
        {
            string list = string.Empty;

            foreach (object item in i_List)
            {
                list += "\n" + item;
            }

            return list;
        }

        private static void registerNewCustomer(Customer i_NewCustomer, eVehicleType i_VehicleType)
        {
            Console.Clear();
            printGarageWelcome();
            System.Console.WriteLine("\nPlease enter your name");
            string ownerName = System.Console.ReadLine();
            i_NewCustomer.Name = ownerName;
            System.Console.WriteLine("\nPlease enter your phone number");
            string ownerPhoneNumber = System.Console.ReadLine();
            i_NewCustomer.PhoneNumber = ownerPhoneNumber;
            System.Console.WriteLine("\nPlease enter your " + getStringForVehicleType(i_VehicleType).ToLower() + "'s license number");
            string ownerLicenseNumber = System.Console.ReadLine();

            if (!m_OurGarage.IsInGarage(ownerLicenseNumber))
            {
                m_OurGarage.AddCustomer(i_NewCustomer);
                newVehicle(m_OurGarage, i_NewCustomer, i_VehicleType, ownerLicenseNumber);
            }
            else
            {
                existingCarHandling(ownerLicenseNumber);
            }
        }

        private static void newVehicle(Garage i_OurGarage, Customer i_NewCustomer, eVehicleType i_VehicleType, string i_LicenseNumber)
        {
            Dictionary<string, string> propertiesForNewVehicle = new Dictionary<string, string>();
            Dictionary<string, List<string>> propertiesOfNewVehicle = i_OurGarage.GetPropertiesForNewVehicle(i_VehicleType);
            foreach (string property in propertiesOfNewVehicle.Keys)
            {
                if (property.Contains("Number"))
                {
                    System.Console.WriteLine("\nPlease specify what is your " + getStringForVehicleType(i_VehicleType).ToLower() + "'s " + property.ToLower());
                }
                else if (property.Contains("Is"))
                {
                    System.Console.WriteLine("\nPlease specify if your " + getStringForVehicleType(i_VehicleType).ToLower() + "'s " + property.ToLower());
                }
                else
                {
                    System.Console.WriteLine("\nPlease specify your " + getStringForVehicleType(i_VehicleType).ToLower() + "'s " + property.ToLower());
                }

                List<string> values = propertiesOfNewVehicle[property];
                propertiesForNewVehicle.Add(property, checkProperty(values, property));             
            }

            i_OurGarage.InsertNewVehicle(i_VehicleType, propertiesForNewVehicle, i_NewCustomer, i_LicenseNumber);
        }

        private static string checkProperty(List<string> i_Values, string i_Property)
        {
            string res = Console.ReadLine();
            bool flag = false;
            int numOfValues = i_Values.Count;

            while (!flag)
            {
                if (numOfValues > 1) 
                {
                    Tuple<bool, string> checkedValues = checkNumerousValues(i_Values, i_Property, res);
                    flag = checkedValues.Item1;
                    res = checkedValues.Item2;
                }
                else if (numOfValues == 1)
                {
                    Tuple<bool, string> checkedValues = checkSingleValue(i_Values, i_Property, res);
                    flag = checkedValues.Item1;
                    res = checkedValues.Item2;
                }
                else
                {
                    flag = true;
                }
                
                if (!flag)
                {
                    res = System.Console.ReadLine();
                }
            }

            return res;
        }

        private static Tuple<bool, string> checkNumerousValues(List<string> i_Values, string i_Property, string i_Input)
        {
            bool flag = false;
            string updateRes = string.Empty;
            string errorMessage = !(i_Values.Contains(i_Input) || i_Values.Contains(i_Input.ToLower())) ? "\nPlease type a value from: \n" 
                + printList(i_Values) + "\n" : string.Empty;
            if (errorMessage == string.Empty)
            {
                flag = true;
                updateRes += i_Input;
            }
            else if (i_Values.Contains("float"))
            {
                float resultValue = checkFloatProperty(i_Property, i_Input);
                updateRes += resultValue;

                if (i_Property.Contains("air pressure"))
                {
                    errorMessage = resultValue > float.Parse(i_Values[0]) || resultValue < 0 ? "\nPlease type a value between 0 to " + i_Values[0] + "\n" : string.Empty;

                    if (errorMessage == string.Empty)
                    {
                        flag = true;
                    }
                }
            }

            Tuple<bool, string> checkedValues = new Tuple<bool, string>(flag, updateRes);
            Console.ForegroundColor = ConsoleColor.Yellow;
            System.Console.Write(errorMessage);
            Console.ForegroundColor = ConsoleColor.White;
            return checkedValues;
        }

        private static Tuple<bool, string> checkSingleValue(List<string> i_Values, string i_Property, string i_Input)
        {
            bool flag = false;
            string errorMessage = string.Empty;
            string updateRes = string.Empty;

            if (i_Values.Contains("float"))
            {
                float resultValue = checkFloatProperty(i_Property, i_Input);
                updateRes = string.Empty + resultValue;

                if (i_Property.Contains("precent of"))
                {
                    errorMessage = resultValue < 0 || resultValue > 1 ? "\nPlease type a value between 0 to 1\n" : string.Empty;
                    if (errorMessage == string.Empty)
                    {
                        flag = true;
                    }
                }
                else
                {
                    errorMessage = resultValue <= 0 ? "\nPlease type a positive number\n" : string.Empty;
                    if (errorMessage == string.Empty)
                    {
                        flag = true;
                    }
                }
            }
            else if (i_Values.Contains("int"))
            {
                int resultValue = checkIntProperty(i_Property, i_Input);
                updateRes = string.Empty + resultValue;
                errorMessage = resultValue <= 0 ? "\nPlease type a positive number\n" : string.Empty;
                if (errorMessage == string.Empty)
                {
                    flag = true;
                }
            }

            Tuple<bool, string> checkedValues = new Tuple<bool, string>(flag, updateRes);
            Console.ForegroundColor = ConsoleColor.Yellow;
            System.Console.Write(errorMessage);
            Console.ForegroundColor = ConsoleColor.White;
            return checkedValues;
        }

        private static float checkFloatProperty(string i_Property, string i_Input)
        {
            float result = 0;

            while (!float.TryParse(i_Input, out result))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                System.Console.WriteLine("\nPlease type a positive number\n");
                Console.ForegroundColor = ConsoleColor.White;
                i_Input = Console.ReadLine();
            }

            return result;
        }

        private static int checkIntProperty(string i_Property, string i_Input)
        {
            int result = 0;

            while (!int.TryParse(i_Input, out result))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                System.Console.WriteLine("\nPlease type a positive number");
                Console.ForegroundColor = ConsoleColor.White;
                i_Input = Console.ReadLine();
            }

            return result;
        }

        private static void existingCarHandling(string i_LicenseNumber)
        {
            Console.Clear();
            printGarageWelcome();
            Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine("\nThis vehicle is already in the garage, please choose your prefernce:\n");
            Console.ForegroundColor = ConsoleColor.White;
            System.Console.WriteLine("\n1. Do another operation \n2. Go back to the main menu");
            string choice = System.Console.ReadLine();

            while (choice != "1" && choice != "2")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine("\n\nIllegal value, please type again");
                Console.ForegroundColor = ConsoleColor.White;
                choice = System.Console.ReadLine();
            }

            if (choice == "1")
            {
                try
                {
                    eVehicleType vehicleType = m_OurGarage.GetVehicleTypeByLicenseNumber(i_LicenseNumber);
                    Customer customer = m_OurGarage.GetCustomerByLicenseNumber(i_LicenseNumber);
                    displayVehicleMethods(customer, vehicleType);
                }
                catch (VehicleNotFoundException e)
                {
                    System.Console.WriteLine(e);
                }
            }
            else
            {
                Console.Clear();
                MainMenu();
            }
        }

        private static void displayVehicleMethods(Customer i_NewCustomer, eVehicleType i_VehicleType)
        {
            Console.Clear();
            printGarageWelcome();
            Array OperationsForGasVehicle = Enum.GetValues(typeof(eGasMethods));
            Array OperationsForElectricVehicle = Enum.GetValues(typeof(eElectricMethods));
            int index = 1;
            System.Console.WriteLine("\nPlease choose the operation you would like to do\n");
            switch (i_VehicleType)
            {
                case eVehicleType.Car:
                case eVehicleType.Motorcycle:
                case eVehicleType.Truck:
                    foreach (eGasMethods method in OperationsForGasVehicle)
                    {
                        System.Console.WriteLine(index + ". " + getStringForGasMethod(method) + "\n");
                        index++;
                    }

                    int gasChoiceNum = getUserChoice(OperationsForGasVehicle.Length);
                    doGasOp(i_NewCustomer, gasChoiceNum);
                    break;
                case eVehicleType.ElectricCar:
                case eVehicleType.ElectricMotorcycle:
                    foreach (eElectricMethods operation in Enum.GetValues(typeof(eElectricMethods)))
                    {
                        System.Console.WriteLine(index + ". " + getStringForElectricOp(operation) + "\n");
                        index++;
                    }

                    int EChoiceNum = getUserChoice(OperationsForGasVehicle.Length);
                    doElectricOp(i_NewCustomer, EChoiceNum);
                    break;
            }
        }

        private static string getStringForGasMethod(eGasMethods i_eGasOperation)
        {
            string operation = string.Empty;
            if (i_eGasOperation == eGasMethods.addFuel)
            {
                operation = "Add fuel";
            }
            else if (i_eGasOperation == eGasMethods.inflate)
            {
                operation = "Inflate air pressure";
            }

            return operation;
        }

        private static string getStringForElectricOp(eElectricMethods i_eElectricVehiclesOp)
        {
            string operation = string.Empty;
            if (i_eElectricVehiclesOp == eElectricMethods.chargeBattery)
            {
                operation = "Charge battery";
            }
            else if (i_eElectricVehiclesOp == eElectricMethods.inflate)
            {
                operation = "Inflate air pressure";
            }

            return operation;
        }

        private static void doGasOp(Customer newCustomer, int i_ChoicNum)
        {
            if ((eGasMethods)Enum.GetValues(typeof(eGasMethods)).GetValue(i_ChoicNum - 1) == eGasMethods.addFuel)
            {
                addFuel(newCustomer.Vehicle, newCustomer);
            }
            else if ((eGasMethods)Enum.GetValues(typeof(eGasMethods)).GetValue(i_ChoicNum - 1) == eGasMethods.inflate)
            {
                inflate(newCustomer.Vehicle, newCustomer);
            }
        }

        private static void doElectricOp(Customer newCustomer, int i_ChoicNum)
        {
            if ((eElectricMethods)Enum.GetValues(typeof(eElectricMethods)).GetValue(i_ChoicNum - 1) == eElectricMethods.chargeBattery)
            {
                chargeBattery(newCustomer.Vehicle, newCustomer);
            }
            else if ((eGasMethods)Enum.GetValues(typeof(eGasMethods)).GetValue(i_ChoicNum - 1) == eGasMethods.inflate)
            {
                inflate(newCustomer.Vehicle, newCustomer);
            }
        }

        private static void addFuel(Vehicle i_Vehicle, Customer i_Customer)
        {
            Console.Clear();
            printGarageWelcome();
            System.Console.WriteLine("\nPlease type the type of gas");
            string gasType = System.Console.ReadLine();
            System.Console.WriteLine("\nPlease type the amount of gas you would like to add (in litters)");
            string inputAmount = System.Console.ReadLine();
            
            bool flag = false;
            float amount = 0;

            while (!flag)
            {
                try 
                {
                    amount = float.Parse(inputAmount);                   
                    try
                    {
                        m_OurGarage.AddFuel(i_Vehicle, gasType, amount);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Clear();
                        System.Console.WriteLine("\nSuccessfully added\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        flag = true;
                    }
                    catch (ArgumentException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        System.Console.WriteLine("\nType doesn't correspond to the vehicle's type, please type the value corresponding to "
                        + getStringForVehicleType(i_Vehicle.VehicleType).ToLower() + " from: \n" + printList(Enum.GetValues(typeof(eGasType))) + "\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        gasType = System.Console.ReadLine();
                    }
                    catch (ValueOutOfRangeException e)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        System.Console.WriteLine(e.Message);
                        Console.ForegroundColor = ConsoleColor.White;
                        inputAmount = System.Console.ReadLine();
                    }
                    catch (InvalidOperationException)
                    {
                        maximalValuesHandeling(i_Vehicle, i_Customer);
                    }
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Illegal value, please type a number");
                    Console.ForegroundColor = ConsoleColor.White;
                    inputAmount = Console.ReadLine();
                }
            }

            finishProcess(i_Vehicle, i_Customer);
        }

        private static void chargeBattery(Vehicle i_Vehicle, Customer i_Customer)
        {
            Console.Clear();
            printGarageWelcome();
            System.Console.WriteLine("\nPlease type the amount of hours you would like to add to the battery");
            string inputAmount = System.Console.ReadLine();
            bool flag = false;
            float amount = 0;

            while (!flag)
            {
                try
                {
                    amount = float.Parse(inputAmount);
                    try
                    {
                        m_OurGarage.ChargeBattery(i_Vehicle, amount);
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        System.Console.WriteLine("\nSuccessfully added\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        flag = true;
                    }
                    catch (ValueOutOfRangeException e)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        System.Console.WriteLine(e.Message);
                        Console.ForegroundColor = ConsoleColor.White;
                        inputAmount = System.Console.ReadLine();
                    }
                    catch (InvalidOperationException)
                    {
                        maximalValuesHandeling(i_Vehicle, i_Customer);
                    }
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Illegal value, please type a number");
                    Console.ForegroundColor = ConsoleColor.White;
                    inputAmount = Console.ReadLine();
                }
            }

                finishProcess(i_Vehicle, i_Customer);
        }

        private static void inflate(Vehicle i_Vehicle, Customer i_Customer)
        {
            Console.Clear();
            printGarageWelcome();
            System.Console.WriteLine("\nPlease type the amount of air you would like to add");
            string inputAmount = System.Console.ReadLine();
            bool flag = false;
            float amount = 0;

            while (!flag)
            {
                try
                {
                    amount = float.Parse(inputAmount);
                    try
                    {
                        m_OurGarage.Inflate(i_Vehicle, amount);
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        System.Console.WriteLine("\nSuccessfully added\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        flag = true;
                    }
                    catch (ValueOutOfRangeException e)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        System.Console.WriteLine(e.Message);
                        Console.ForegroundColor = ConsoleColor.White;
                        inputAmount = System.Console.ReadLine();
                    }
                    catch (InvalidOperationException)
                    {
                        maximalValuesHandeling(i_Vehicle, i_Customer);
                    }
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Illegal value, please type a number");
                    Console.ForegroundColor = ConsoleColor.White;
                    inputAmount = Console.ReadLine();
                }
            }

                finishProcess(i_Vehicle, i_Customer);
        }

        private static void finishProcess(Vehicle i_Vehicle, Customer i_Customer)
        {
            System.Console.WriteLine("If you would like to go back to the main menu press 1 or do another operation on this " + 
                getStringForVehicleType(i_Vehicle.VehicleType).ToLower() + " please press 2");
            string choice = System.Console.ReadLine();
            bool legalChoice = false;

            while (!legalChoice)
            {
                if (choice == "1")
                {
                    Console.Clear();
                    MainMenu();
                }
                else if (choice == "2")
                {
                    displayVehicleMethods(i_Customer, i_Vehicle.VehicleType);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    System.Console.WriteLine("\n\nIllegal value, please type again");
                    Console.ForegroundColor = ConsoleColor.White;
                    choice = System.Console.ReadLine();
                }
            }
        }

        private static void maximalValuesHandeling(Vehicle i_Vehicle, Customer i_Customer)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine("\nThe amount is already the maximal.\n");
            Console.ForegroundColor = ConsoleColor.White;
            System.Console.WriteLine("If you would like to go back to the main menu please press 1\n" +
                          "or if you would like to do another operation on this " + getStringForVehicleType(i_Vehicle.VehicleType).ToLower() + " please press 2\n");
            string choice = System.Console.ReadLine();
            bool legalChoice = false;
            while (!legalChoice)
            { 
                if (choice == "1")
                {
                    legalChoice = true;
                    Console.Clear();
                    MainMenu();
                }
                else if (choice == "2")
                {
                    legalChoice = true;
                    displayVehicleMethods(i_Customer, i_Vehicle.VehicleType);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    System.Console.WriteLine("\n\nIllegal value, please type again");
                    Console.ForegroundColor = ConsoleColor.White;
                    choice = System.Console.ReadLine();
                }
            }
        }
    }
}
