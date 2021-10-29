using Hotel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;

namespace Hotel
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            // установка пути к текущему каталогу
            builder.SetBasePath(Directory.GetCurrentDirectory());
            // получаем конфигурацию из файла appsettings.json
            builder.AddJsonFile("appsettings.json");
            // создаем конфигурацию
            var config = builder.Build();
            // получаем строку подключения
            string connectionString = config.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<HotelContext>();
            var options = optionsBuilder
                .UseSqlServer(connectionString)
                .Options;
            //using (HotelContext db = new HotelContext(options))
            //{
            //    var bookings = db.Bookings.ToList();
            //    foreach (Booking b in bookings)
            //    {
            //        Console.WriteLine($"{b.BookingId}");
            //    }
            //}
            // Добавление
            using (HotelContext db = new HotelContext(options))
            {
                Customer user1 = new Customer { CustomerName = "Оля", Phone = 067854662, PassportID = "Алвіаі" };
               Customer user2 = new Customer { CustomerName = "Катя", Phone = 45552248, PassportID = "КАТЕ" };

                // Добавление
                db.Customers.Add(user1);
                db.Customers.Add(user2);
                db.SaveChanges();
            }
            // получение
            using (HotelContext db = new HotelContext(options))
            {
                // получаем объекты из бд и выводим на консоль
                var customers = db.Customers.ToList();
                Console.WriteLine("Данные после добавления:");
                foreach (Customer c in customers )
                {
                    Console.WriteLine($"{c.CustomerId}.{ c.CustomerName}.{c.Phone}.{c.PassportID}");
                }
            }

            // Редактирование
            using (HotelContext db = new HotelContext(options))
            {
                // получаем первый объект
                Customer customer = db.Customers.FirstOrDefault();
                if (customer != null)
                {
                    customer.CustomerName = "Bob";
                    customer.Phone = 5642123;
                    //обновляем объект
                    //db.Users.Update(user);
                    db.SaveChanges();
                }
                // выводим данные после обновления
                Console.WriteLine("\nДанные после редактирования:");
                var customers = db.Customers.ToList();
                foreach (Customer c in customers)
                {
                    Console.WriteLine($"{c.CustomerId}.{c.CustomerName}.{c.Phone}.{c.PassportID}");
                }
            }

            // Удаление
            using (HotelContext db = new HotelContext(options))
            {
                // получаем первый объект
                Customer customer = db.Customers.FirstOrDefault();
                if (customer != null)
                {
                    //удаляем объект
                    db.Customers.Remove(customer);
                    db.SaveChanges();
                }
                // выводим данные после обновления
                Console.WriteLine("\nДанные после удаления:");
                var customers = db.Customers.ToList();
                foreach (Customer c in customers)
                {
                    Console.WriteLine($"{c.CustomerId}.{c.CustomerName}.{c.Phone}.{c.PassportID}");
                }
            }
            Console.Read();
        }
    }
    
}

