using App_buy_sell_plane_flight_ticket;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace InOutputData
{
    // BB sort
    public class SortCustomer
    {   
 
        public static void Sort( List<CCustomer> list) => list =list.OrderBy(x => x.CustomerNumber).ToList();

    }

    public class InputData
    {   
        public static List<CCustomer> inputCustomersList = new ();
        public static List<CFlight> inputFlightsList = new ();

        public static string fileLocationInputListFlight = @"D:\learn\202201\Lập trình hướng đối tượng\Lập trình hàm\Lập trình hàm\Danh sách chuyến bay.txt";
        public static string fileLocationInputListCustomer = @"D:\learn\202201\Lập trình hướng đối tượng\Lập trình hàm\Lập trình hàm\Danh sách khách hàng.txt";
        public static Func<string, string> standardizedString = iString =>
        {
            string s = iString.Trim();
            while (s.IndexOf("  ") != -1)
            {
                s = s.Replace("  ", " ");
            }
            return s;
        };

        public static void inputListFlight()
        {
            StreamReader ReadText = new StreamReader(fileLocationInputListFlight);
            string flightNumber_, flightName_, flightDate_, flightPrice_;
            int flightNumber;
            DateTime flightDate;
            double flightPrice;
            while ((flightNumber_ = ReadText.ReadLine()) != null && flightNumber_ != "")
            {
                flightNumber_ = standardizedString(flightNumber_);
                int.TryParse(flightNumber_, out flightNumber);

                flightName_ = ReadText.ReadLine();
                flightName_ = standardizedString(flightName_);

                flightDate_ = ReadText.ReadLine();
                flightDate_ = standardizedString(flightDate_);
                DateTime.TryParse(flightDate_, out flightDate);

                flightPrice_ = ReadText.ReadLine();
                flightPrice_ = standardizedString(flightPrice_);
                double.TryParse(flightPrice_, out flightPrice);
                ReadText.ReadLine();

                inputFlightsList.Add(new CFlight(flightNumber, flightName_, flightDate, flightPrice));
            }
            ReadText.Close();
        }
        public static void inputListCustomer()
        {
            StreamReader ReadText = new StreamReader(fileLocationInputListCustomer);
            string customerNumber_, customerName_, sex_, age_, flightName_;
            int customerNumber;
            uint age;

            while ((customerNumber_ = ReadText.ReadLine()) != null && customerNumber_ != "")
            {
                List<CFlight> listTicket = new List<CFlight>();
                customerNumber_ = standardizedString(customerNumber_);
                int.TryParse(customerNumber_, out customerNumber);

                customerName_ = ReadText.ReadLine();
                customerName_ = standardizedString(customerName_);

                sex_ = ReadText.ReadLine();
                sex_ = standardizedString(sex_);

                age_ = ReadText.ReadLine();
                age_ = standardizedString(age_);
                uint.TryParse(age_, out age);

                while ((flightName_ = ReadText.ReadLine()) != "" && flightName_ != null)
                {
                    flightName_ = standardizedString(flightName_);
                    foreach (CFlight flight in inputFlightsList)
                    {
                        if (flight.FlightName == flightName_)
                        {
                            listTicket.Add(flight);
                            break;
                        }
                    }
                }
                if (listTicket.Count != 0)
                {
                    inputCustomersList.Add(new CCustomer(customerNumber, customerName_, sex_, age, listTicket));
                }
            }
            ReadText.Close();
            SortCustomer.Sort(inputCustomersList);

        }
        public static Func<string, double> inputDouble = s =>
        {
            double temp;
            OutputData.ouputDynamic($"{s}");
            while (!double.TryParse(Console.ReadLine(), out temp))
            {
                OutputData.outputSpacing();
                OutputData.ouputDynamicLine("Nhập sai định dạng, vui lòng nhập lại");
                OutputData.ouputDynamic($"{s}");
            }
            OutputData.outputSpacing();
            return temp;
        };
        public static Func<string, double> inputUDouble = s =>
        {
            double temp;
            OutputData.ouputDynamic($"{s}");
            while (!double.TryParse(Console.ReadLine(), out temp) && temp >= 0)
            {
                OutputData.outputSpacing();
                OutputData.ouputDynamicLine("Nhập sai định dạng, vui lòng nhập lại");
                OutputData.ouputDynamic($"{s}");
            }
            OutputData.outputSpacing();
            return temp;
        };
        public static Func<string, int> inputInt = s =>
        {
            int temp;
            OutputData.ouputDynamic($"{s}");
            while (!int.TryParse(Console.ReadLine(), out temp))
            {
                OutputData.outputSpacing();
                OutputData.ouputDynamicLine("Nhập sai định dạng, vui lòng nhập lại");
                OutputData.ouputDynamic($"{s}");
            }
            OutputData.outputSpacing();
            return temp;
        };
        public static Func<string, uint> inputUInt = s =>
        {
            uint temp;
            OutputData.ouputDynamic($"{s}");
            while (!uint.TryParse(Console.ReadLine(), out temp))
            {
                OutputData.outputSpacing();
                OutputData.ouputDynamicLine("Nhập sai định dạng, vui lòng nhập lại");
                OutputData.ouputDynamic($"{s}");
            }
            OutputData.outputSpacing();
            return temp;
        };
        public static Func<string, long> inputLong = s =>
        {
            long temp;
            OutputData.ouputDynamic($"{s}");
            while (!long.TryParse(Console.ReadLine(), out temp))
            {
                OutputData.outputSpacing();
                OutputData.ouputDynamicLine("Nhập sai định dạng, vui lòng nhập lại");
                OutputData.ouputDynamic($"{s}");
            }
            OutputData.outputSpacing();
            return temp;
        };
        public static Func<string, ulong> inputULong = s =>
        {
            ulong temp;
            OutputData.ouputDynamic($"{s}");
            while (!ulong.TryParse(Console.ReadLine(), out temp))
            {
                OutputData.outputSpacing();
                OutputData.ouputDynamicLine("Nhập sai định dạng, vui lòng nhập lại");
                OutputData.ouputDynamic($"{s}");
            }
            OutputData.outputSpacing();
            return temp;
        };
        public static Func<string, string> inputString = s =>
        {
            OutputData.ouputDynamic($"{s}");
            string temp = Console.ReadLine();
            OutputData.outputSpacing();
            return temp;
        };
        public static Func<string, DateTime> inputDate = s =>
        {
            DateTime temp;
            OutputData.ouputDynamic($"{s}");
            while (!DateTime.TryParse(Console.ReadLine(), out temp))
            {
                OutputData.outputSpacing();
                OutputData.ouputDynamicLine("Nhập sai định dạng, vui lòng nhập lại");
                OutputData.ouputDynamic($"{s}");
            }
            OutputData.outputSpacing();
            return temp;
        };
    }
    public class InputPerson
    {
        public static Func<string> inputName = () =>
        {
            string name = InputData.inputString("Nhập tên: ");
            while (name.Any(char.IsDigit) || name.Any(char.IsPunctuation) || name.Any(char.IsSymbol))
            {
                OutputData.ouputDynamicLine("Tên không được chứa ký tự đặc biệt, vui lòng nhập lại");
                name = InputData.inputString("Nhập tên: ");
            }
            return name;
        };
        public static Func<string> inputSex = () =>
        {
            string sex = InputData.inputString("Nhập giới tính: ");
            string checkSex = sex.ToLower();
            while (checkSex != "nam" && checkSex != "nữ")
            {
                OutputData.ouputDynamicLine("Giới tính phải chỉ có thể là 'Nam' hoặc 'Nữ', vui lòng nhập lại");
                sex = InputData.inputString("Nhập giới tính: ");
                checkSex = sex.ToLower();
            }
            return sex;
        };
        public static Func<uint> inputAge = () => InputData.inputUInt("Nhập tuổi: ");
        public static Func<ulong> inputPhone = () => InputData.inputULong("Nhập số điện thoại: ");
        public static Func<string> inputEmail = () => InputData.inputString("Nhập email: ");
    }

    public class OutputData
    {
        public static Action Author = () =>
        {
            outputSpacing();
            ouputDynamicLine("              Nguyễn Văn Quốc - 20206210              ");
        };
        public static Action<dynamic> ouputDynamicLine = s =>
        {
            Console.WriteLine(s);
            Console.WriteLine("------------------------------------------------------");
        };
        public static Action<dynamic> ouputDynamic = s =>
        {
            Console.Write(s);
        };
        public static Action outputSpacing = () => Console.WriteLine("------------------------------------------------------");
        public static Action ChoiceFalse = () =>
        {
            ouputDynamicLine("Lựa chọn không hợp lý");
        };
        public static Func<int, int, List<CFlight>, string, string> convertListFlightToString = (iStart, iEnd, iListFlight, iString) =>
        {
            if (iStart>=iEnd)
            {
                return iString;
            }
            string flight = iListFlight[iStart].ToString() + "\n------------------------------------------------------\n";
            return convertListFlightToString(iStart + 1, iEnd, iListFlight, iString + flight);
        };
        /*public static Func<List<CFlight>,string> convertListFlightToString = iListFlight =>
        {
            string listFlight = "";
            foreach (CFlight flight in iListFlight)
            {
                listFlight += flight.ToString() + "\n------------------------------------------------------\n";
            }
            return listFlight;
        };*/
        public static Func<int, int, List<CCustomer>, string, string> convertListCustomerToString = (iStart, iEnd, iListCustomer, iString) =>
        {
            if (iStart >= iEnd)
            {
                return iString;
            }
            string customer = iListCustomer[iStart].ToString() + "\n------------------------------------------------------\n";
            return convertListCustomerToString(iStart + 1, iEnd, iListCustomer, iString + customer);
        };
        /*public static Func<List<CCustomer>, string> convertListCustomerToString = iListCustomer =>
        {
            string listCustomer = "";
            foreach (CCustomer customer in iListCustomer)
            {
                listCustomer += customer.ToString() + "\n------------------------------------------------------\n";
            }
            return listCustomer;
        };*/
        public static Func<dynamic, dynamic, string> addString = (iDynamic1, iDynamic2) =>
        {
            string unionString = iDynamic1.ToString() + "\n------------------------------------------------------\n" + iDynamic2.ToString();
            return unionString;
        };
    }
}