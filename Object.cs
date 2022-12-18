using InOutputData;
namespace App_buy_sell_plane_flight_ticket
{
    public class CPerson
    {
        protected string _Name;
        protected uint _Age;
        protected string _Sex;
        public string Name
        {
            get => _Name;
            set => _Name = value;
        }
        public uint Age
        {
            get => _Age;
            set => _Age = value;
        }
        public string Sex
        {
            get => _Sex;
            set => _Sex = value;
        }
        public CPerson()
        {

        }
        public CPerson(string iName, uint iAge, string iSex)
        {
            _Name = iName;
            _Age = iAge;
            _Sex = iSex;
        }
        public static Func<CCustomer> buyTicket = () =>
        {
            CCustomer customer = new CCustomer(InputPerson.inputName(), InputPerson.inputAge(), InputPerson.inputSex());
            CCustomer.buyTicket(customer);
            if (customer.ListTicket.Count != 0)
            {
                Program.ListCustomer.Add(customer);
                //Program.ListFlight.Sort(new SortCustomer());
            }
            return customer;
        };
        public static Func<int, int, int, CFlight> choiceTicket = (iStart, iEnd, iFlightNumber) =>
        {
            if (iStart >= iEnd)
            {
                return null;
            }
            CFlight flight = Program.ListFlight[iStart];
            if (flight.FlightNumber == iFlightNumber)
            {
                return flight;
            }
            return choiceTicket(iStart + 1, iEnd, iFlightNumber);
        };
        /*public static Func<int, CFlight> choiceTicket = iFlightNumber =>
        {
            foreach (CFlight flight in Program.ListFlight)
            {
                if (flight.FlightNumber == iFlightNumber)
                {
                    return flight;
                }
            }
            return null;
        };*/
    }
    public class CCustomer : CPerson
    {
        int _CustomerNumber;
        uint _QuantityTicket;
        List<CFlight> _ListTicket = new List<CFlight>();
        double _Payment;
        public int CustomerNumber
        {
            get => _CustomerNumber;
            set => _CustomerNumber = value;
        }
        public uint QuantityTicket
        {
            get => _QuantityTicket;
            set => _QuantityTicket = value;
        }
        public List<CFlight> ListTicket
        {
            get => _ListTicket;
            set => _ListTicket = value;
        }
        public double Payment
        {
            get => _Payment;
            set => _Payment = value;
        }
        public CCustomer(string iName, uint iAge, string iSex)
        {
            _Name = iName;
            _Age = iAge;
            _Sex = iSex;
        }
        public CCustomer(int iCustomerNumber, string iName, string iSex, uint iAge, List<CFlight> iListTicket)
        {
            _CustomerNumber = iCustomerNumber;
            _Name = iName;
            _Sex = iSex;
            _Age = iAge;
            _ListTicket = iListTicket;
            int quantityListFlight = Program.ListFlight.Count;
            int numberTicket = _ListTicket.Count;
            updateInfo(0, numberTicket, _ListTicket, this);
            /*foreach (CFlight flight in _ListTicket)
            {
                if (choiceTicket(0, quantityListFlight, flight.FlightNumber) == null)
                {
                    Console.WriteLine(123);
                }
                if (choiceTicket(0, quantityListFlight, flight.FlightNumber) != null)
                {
                    _Payment += flight.FlightPrice;
                    _QuantityTicket++;
                    CAirline.Revenue += flight.FlightPrice;
                }
            }*/
        }
        public static Func<int, int, List<CFlight>, CCustomer, bool> updateInfo = (iStart, iEnd, iListTicket, iCustomer) =>
        {
            int quantityListFlight = Program.ListFlight.Count;
            if (iStart >= iEnd)
            {
                return true;
            }
            CFlight flight = iListTicket[iStart];
            if (choiceTicket(0, quantityListFlight, flight.FlightNumber) != null)
            {
                iCustomer._Payment += flight.FlightPrice;
                iCustomer._QuantityTicket++;
                CAirline.Revenue += flight.FlightPrice;
            }
            return updateInfo(iStart + 1, iEnd, iListTicket, iCustomer);
        };

        public static Action<CCustomer> buyTicket = customer =>
        {
            int numberTicket = Program.ListFlight.Count;
            OutputData.ouputDynamic(OutputData.convertListFlightToString(0, numberTicket, Program.ListFlight, ""));
            int flightNumber = InputData.inputInt("Nhập mã chuyến bay muốn mua vé: ");
            CFlight flight = choiceTicket(0, numberTicket, flightNumber);
            if (flight != null)
            {
                customer._Payment += flight.FlightPrice;
                customer._QuantityTicket++;
                CAirline.Revenue += flight.FlightPrice;
                customer.ListTicket.Add(flight);
            }
        };
        public static Action<CCustomer> cancelTicket = customer =>
        {
            int numberTicket = Program.ListFlight.Count;
            OutputData.ouputDynamic(OutputData.convertListFlightToString(0, numberTicket, Program.ListFlight, ""));
            int flightNumber = InputData.inputInt("Nhập mã chuyến bay muốn huỷ vé: ");
            CFlight flight = choiceTicket(0, numberTicket, flightNumber);
            if (flight != null)
            {
                customer._Payment -= flight.FlightPrice * 0.5;
                customer._QuantityTicket--;
                CAirline.Revenue -= flight.FlightPrice * 0.5;
                customer.ListTicket.Remove(flight);
            }
        };

        public override string ToString()
        {
            int numberTicket = _ListTicket.Count;
            if (numberTicket != 0)
            {
                string listTicket = OutputData.convertListFlightToString(0, numberTicket, _ListTicket, "");
                string customer = OutputData.addString("Mã khách hàng: " + _CustomerNumber, OutputData.addString("Tên khách hàng: " + _Name, OutputData.addString("Giới tính: " + _Sex, OutputData.addString("Tuổi: " + _Age, OutputData.addString("Số lượng vé: " + _QuantityTicket, OutputData.addString("Thanh toán: " + $"{_Payment:c0}", listTicket))))));
                return customer;
            }
            return null;
        }
    }
#region Airline
	    public class CAirline
#endregion
    {
        string _AirlineName;
        static double _Revenue;
        public static double Revenue
        {
            get => _Revenue;
            set => _Revenue = value;
        }
    }
    public class CFlight
    {
        int _FlightNumber;
        string _FlightName;
        DateTime _FlightDate;
        double _FlightPrice;

        public int FlightNumber => _FlightNumber;
        public string FlightName => _FlightName;
        public DateTime FlightDate => _FlightDate;
        public double FlightPrice => _FlightPrice;
        public CFlight(int iFlightNumber, string iFlightName, DateTime iFlightDate, double iFlightPrice)
        {
            _FlightNumber = iFlightNumber;
            _FlightName = iFlightName;
            _FlightDate = iFlightDate;
            _FlightPrice = iFlightPrice;
        }
        public override string ToString()
        {
            string flight = $"Mã chuyến bay: {_FlightNumber,-5} Chuyến bay: {_FlightName,-25} Ngày bay: {_FlightDate,-25} Giá vé: {_FlightPrice,-10:c0}";
            return flight;
        }

    }
}
