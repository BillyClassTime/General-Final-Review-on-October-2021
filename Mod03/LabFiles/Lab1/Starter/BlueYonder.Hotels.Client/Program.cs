using DAL.Models;
using System.Net.Http;
using System.Threading.Tasks;
using static System.Console;

namespace BlueYonder.Hotels.Client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            WriteLine("Inicio de aplicacion");
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage message = await client.GetAsync("http://localhost:5000/api/HotelBooking/1");
                WriteLine("Getting booking:");
                string resultAsString = await message.Content.ReadAsStringAsync();
                WriteLine(resultAsString);
                Booking booking = await message.Content.ReadAsAsync<Booking>();

                booking.Paid = false; 
                message = await client.PutAsJsonAsync("http://localhost:5000/api/HotelBooking/1", booking);
                resultAsString = await message.Content.ReadAsStringAsync();
                WriteLine("Booking after update:");
                WriteLine(resultAsString);
            }
        }
    }
}
