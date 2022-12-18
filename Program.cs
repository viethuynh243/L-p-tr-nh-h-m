using InOutputData;
using System.Text;

namespace App_buy_sell_plane_flight_ticket
{
    public class Program
    {
        static void menuCustomer()
        {
            string line1 = "Bạn có thể thực hiện một số tác vụ sau: 1. Mua vé   2.Huỷ vé    3. Thông tin của bạn";
            string line2 = "4. Xem danh sách chuyến bay của hãng    5. Kiểm tra danh sách chuyến bay của bạn";
            string line = OutputData.addString(line1, line2);
            OutputData.ouputDynamicLine(line);
            switch (InputData.inputString("Bạn muốn thực hiện tác vụ: "))
            {
                case "1":
                    int numberTicket = ListFlight.Count;
                    int numberCustomer = ListCustomer.Count;
                    OutputData.ouputDynamic(OutputData.convertListFlightToString(0, numberTicket, ListFlight, ""));
                    OutputData.ouputDynamic(OutputData.convertListCustomerToString(0, numberCustomer, ListCustomer, ""));
                    CCustomer.cancelTicket(ListCustomer[1]);
                    OutputData.ouputDynamic(OutputData.convertListCustomerToString(0, numberCustomer, ListCustomer, ""));

                    break;
                case "2":
                    break;
                case "3":
                    break;
                case "4":
                    break;
                case "5":
                    break;
                default:
                    break;
            }


        }
        public static List<CFlight> ListFlight = new List<CFlight>();
        public static List<CCustomer> ListCustomer = new List<CCustomer>();
        public static void Main()
        {   
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            
        
            try
            {
                InputData.inputListFlight();
                InputData.inputListCustomer();
                ListCustomer = InputData.inputCustomersList;
                menuCustomer();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


        }
    }
}