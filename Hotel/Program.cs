using Hotel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;


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

            //// Добавление
            //using (HotelContext db = new HotelContext(options))
            //{
            //    Customer user1 = new Customer { CustomerName = "Влад", Phone = 067854662, PassportID = "РВОВОО" };
            //    Customer user2 = new Customer { CustomerName = "Тарас", Phone = 45552248, PassportID = "7895462" };

            //    // Добавление
            //    db.Customers.Add(user1);
            //    db.Customers.Add(user2);
            //    db.SaveChanges();
            //}
            //// получение
            //using (HotelContext db = new HotelContext(options))
            //{
            //    // получаем объекты из бд и выводим на консоль
            //    var customers = db.Customers.ToList();
            //    Console.WriteLine("Данные после добавления:");
            //    foreach (Customer c in customers)
            //    {
            //        Console.WriteLine($"{c.CustomerId}.{ c.CustomerName}.{c.Phone}.{c.PassportID}");
            //    }
            //}

            //// Редактирование
            //using (HotelContext db = new HotelContext(options))
            //{
            //    // получаем первый объект
            //    Customer customer = db.Customers.FirstOrDefault();
            //    if (customer != null)
            //    {
            //        customer.CustomerName = "Bob";
            //        customer.Phone = 5642123;
            //        //обновляем объект
            //        //db.Users.Update(user);
            //        db.SaveChanges();
            //    }
            //    // выводим данные после обновления
            //    Console.WriteLine("\nДанные после редактирования:");
            //    var customers = db.Customers.ToList();
            //    foreach (Customer c in customers)
            //    {
            //        Console.WriteLine($"{c.CustomerId}.{c.CustomerName}.{c.Phone}.{c.PassportID}");
            //    }
            //}

            //// Удаление
            //using (HotelContext db = new HotelContext(options))
            //{
            //    // получаем первый объект
            //    Customer customer = db.Customers.FirstOrDefault();
            //    if (customer != null)
            //    {
            //        //удаляем объект
            //        db.Customers.Remove(customer);
            //        db.SaveChanges();
            //    }
            //    // выводим данные после обновления
            //    Console.WriteLine("\nДанные после удаления:");
            //    var customers = db.Customers.ToList();
            //    foreach (Customer c in customers)
            //    {
            //        Console.WriteLine($"{c.CustomerId}.{c.CustomerName}.{c.Phone}.{c.PassportID}");
            //    }
            //}


            ////Номер замовлення та хто його зробив
            //Console.WriteLine($"Номер замовлення та хто його зробив:");
            //using (HotelContext db = new HotelContext(options))
            //{
            //    var bookings = (from booking in db.Bookings.Include(p => p.Customer)
            //                    select booking).ToList();

            //    foreach (var booking in bookings)
            //        Console.WriteLine($"Бронювання №:{booking.BookingId}     Замовник: {booking.Customer.CustomerName}");
            //    Console.WriteLine("--------------------------------------------------------------------");
            //}

            //Console.WriteLine($"Першi два замовлення з таблицi букiнг:");
            //using (HotelContext db = new HotelContext(options))
            //{
            //    var book = db.Bookings.Take(2);
            //    foreach (Booking bo in book)
            //        Console.WriteLine($"{ bo.BookingId}  {bo.CodeOrder}  {bo.Checkin}  {bo.Checkout}  ");
            //    Console.WriteLine("--------------------------------------------------------------------");

            //}
            //Console.WriteLine($"Кiлькiсть людей якi робили бронювання:");
            //using (HotelContext db = new HotelContext(options))
            //{
            //    var customer = db.Customers.Count();
            //    Console.WriteLine(customer);
            //    Console.WriteLine("--------------------------------------------------------------------");
            //}

            //Console.WriteLine($"Функция:");
            //using (HotelContext db = new HotelContext(options))
            //{
            //    Microsoft.Data.SqlClient.SqlParameter param = new Microsoft.Data.SqlClient.SqlParameter("@room", 2);
            //    var full = db.Rooms.FromSqlRaw("SELECT * FROM FullCost1 (@room)", param).ToList();
            //    foreach (var f in full)
            //        Console.WriteLine($"{f.Cost}");
            //}


            //Console.WriteLine($"Сортування замовлень по цiнi по зменшенню:");
            //using (HotelContext db = new HotelContext(options))
            //{
            //    var order = db.Orders.OrderByDescending(x => x.Sum);
            //    foreach (Order o in order)
            //        Console.WriteLine($"{ o.OrderId}  {o.Sum}");
            //    Console.WriteLine("--------------------------------------------------------------------");
            //}

            //Console.WriteLine($"Проекцiя вибраних значень:");
            //using (HotelContext db = new HotelContext(options))
            //{
            //    var ut = db.Customers.Select(x => new { Name = x.CustomerName })
            //        .Union(db.Employees.Select(y => new { Name = y.FirstName}));
            //    foreach (var c in ut)
            //        Console.WriteLine(c.Name);
            //    Console.WriteLine("--------------------------------------------------------------------");
            //}

            //Console.WriteLine($"Дата по бронюванню та замовленню:");
            //using (HotelContext db = new HotelContext(options))
            //{
            //    var bo = from b in db.Bookings
            //             join o in db.Orders
            //             on b.BookingId equals o.BookingId
            //             select new { Booking = b.BookingId, Checkin = b.Checkin, Checkout = b.Checkout, Arrival = o.DateArrival, Departure = o.DateDeparture };
            //    foreach (var x in bo)
            //    {
            //        Console.WriteLine("Дата по бронюванню: {0}  {1} {2}  ", x.Booking, x.Checkin, x.Checkout);
            //        Console.WriteLine("Дата по замовленню: {0}  {1} {2}  ", x.Booking,x.Arrival, x.Departure);
            //        Console.WriteLine("-------");
            //    }
            //    Console.WriteLine("--------------------------------------------------------------------");
            //}

            //Console.WriteLine($"Процедура:");
            //using (HotelContext db = new HotelContext(options))
            //{
            //        Microsoft.Data.SqlClient.SqlParameter param = new Microsoft.Data.SqlClient.SqlParameter("@name", "Тарас");
            //        var customers = db.Customers.FromSqlRaw("GetUsersByCompany @name", param).ToList();
            //        foreach (var p in customers)
            //            Console.WriteLine($" Name: {p.CustomerName}\n ID: {p.CustomerId}\n Passport: {p.PassportID}\n Phone: {p.Phone}");

            //}


            // кількість клієнтів які не зробили жодного замовлення
            using (HotelContext db = new HotelContext(options))
            {
                var ext = db.Customers.Select(x => new { ID = x.CustomerName})
                    .Except(db.Bookings.Select(y => new { ID = y.Customer.CustomerName }));
                int i = 0; 
                foreach (var c in ext)
                {
                    i++;
                    Console.WriteLine(c.ID);
                }
                Console.WriteLine($"Количество: {i}");

                Console.WriteLine("--------------------------------------------------------------------");
            }

            Console.Read();
        }
    }
    
}

