using System;
using System.Collections.Generic;

namespace HotelReservationSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Hotel Reservation System!");

            Console.Write("Enter the date range : ");
            var input = Console.ReadLine();
            string[] dates = input.Split(',');
            var startDate = Convert.ToDateTime(dates[0]);
            var endDate = Convert.ToDateTime(dates[1]);
            var hotelReservation = new HotelReservation();
            AddSampleHotels(hotelReservation);
            var cheapestHotels = hotelReservation.FindCheapestHotel(startDate, endDate);
            var cost = hotelReservation.CalculateTotalCost(cheapestHotels[0], startDate, endDate);
            var hotelString = HotelString(cheapestHotels);
            Console.WriteLine("{0}, Total Cost : {1}", hotelString, cost);
            
        }

        public static void AddSampleHotels(HotelReservation hotelReservation)
        {
            hotelReservation.AddHotel(new Hotel { name = "Lakewood", weekdayRatesRegular = 110, weekendRatesRegular = 90 });
            hotelReservation.AddHotel(new Hotel { name = "Bridgewood", weekdayRatesRegular = 160, weekendRatesRegular = 60 });
            hotelReservation.AddHotel(new Hotel { name = "Ridgewood", weekdayRatesRegular = 220, weekendRatesRegular = 150 });

        }
        public static string HotelString(List<Hotel> cheapestHotels)
        {
            if (cheapestHotels.Count == 1)
                return cheapestHotels[0].name;
            var hotelString = "";
            for (int i = 0; i < cheapestHotels.Count; i++)
            {
                if (i == cheapestHotels.Count - 1)
                    hotelString += " and ";

                hotelString += cheapestHotels[i].name;
                if (i != cheapestHotels.Count - 1)
                    hotelString += ",";
            }
            return hotelString;
        }
    }
}
