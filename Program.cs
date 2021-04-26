using System;
using System.Collections.Generic;
using System.Linq;

namespace PracticalWorkLinq2
{
    class Program
    {
        static void Main(string[] args)
        { 
            // Корабли
            Ship ship1 = new Ship { Name = "Titanic", NumbOfPassenger = 5000,  ShippingCompany = "White Star Line", YearOfConstruction = "1911", Type = "Sea", Ciper = "cd870570-b931-4f02-a72a-ccc65a9f1ae3" };

            Ship ship7 = new Ship { Name = "Titanic2", NumbOfPassenger = 10000, ShippingCompany = "White Star Line", YearOfConstruction = "1911", Type = "Sea", Ciper = "cd870570-b931-4f02-a72a-ccc65a9f1ae3" };

            Ship ship2 = new Ship { Name = "Arizona", NumbOfPassenger = 2000, ShippingCompany = "SeaTravels", YearOfConstruction = "1950", Type = "Sea" , Ciper = "e197bf9c - 782c - 4701 - abbf - 50f46d988c62" };

            Ship ship3 = new Ship { Name = "Sand" , NumbOfPassenger = 500, ShippingCompany = "RiverTravels" , YearOfConstruction = "2010", Type = "River" , Ciper = "c185b24e-cd3e-4106-823c-15d4b2db9d5e" };

            Ship ship4 = new Ship { Name = "JourneyLand", NumbOfPassenger = 250, ShippingCompany = "RiverTravels" , YearOfConstruction = "2010" , Type = "River" , Ciper = "01b94657-0434-40b8-b1f2-441225261f7a" };

            Ship ship5 = new Ship { Name = "BlueSky" , NumbOfPassenger = 700, ShippingCompany = "Feeling", YearOfConstruction = "2015", Type = "River" , Ciper = "790786d5-32e6-42ee-8b6c-ee39dc85e35a" };

            Ship ship6 = new Ship { Name = "Whale", NumbOfPassenger = 4000, ShippingCompany = "Blue Whale" , YearOfConstruction = "2005", Type = "Sea" , Ciper = "6b86ff4f - 24f4 - 4104 - 9b2e - a84c6c11dd55" };

            // Речки
            River river1 = new River { Name = "Dnipro", Width = 800, Length = 2201000, NumbOfConfluent = 32000 , Ciper = "c185b24e-cd3e-4106-823c-15d4b2db9d5e" };

            River river2 = new River { Name = "Danube", Width = 700, Length = 2860000 , NumbOfConfluent = 327, Ciper = "01b94657-0434-40b8-b1f2-441225261f7a" };

            River river3 = new River { Name = "Rhine", Width = 600, Length = 1233000 , NumbOfConfluent = 100, Ciper = "790786d5-32e6-42ee-8b6c-ee39dc85e35a" };

            // Моря

            Sea sea1 = new Sea { Name = "Black Sea", Square = 442000, Ciper = "cd870570-b931-4f02-a72a-ccc65a9f1ae3" };

            Sea sea2 = new Sea { Name = "The Caribbean Sea" , Square = 371000, Ciper = "e197bf9c - 782c - 4701 - abbf - 50f46d988c62" };

            Sea sea3 = new Sea { Name = "The Coral Sea" , Square = 4791000000, Ciper = "6b86ff4f - 24f4 - 4104 - 9b2e - a84c6c11dd55" };

            //а) выдать данные из последовательности «река» в отсортированном по длине виде;
            Console.WriteLine(new string('*', 180));

            List<River> riverList = new List<River> { river1, river2, river3 };

            var sortedRiverList = riverList.OrderBy( x => x.Length);

            foreach (var river in sortedRiverList)
            {
                Console.WriteLine($"Название реки : {river.Name}, Ширина: {river.Width}, Длинна: {river.Length}, Количество притоков: {river.NumbOfConfluent}, Шифр: {river.Ciper} ");
            }

            //б) сгруппировать данные в последовательности «корабль» по пароходству и по году постройки;
            Console.WriteLine(new string('*', 180));

            List<Ship> shipList = new List<Ship> { ship1, ship2, ship3, ship4, ship5, ship6, ship7 };

            var groupShipList = shipList.GroupBy(x => new {x.ShippingCompany, x.YearOfConstruction });

            foreach (var ship in groupShipList)
            {
                Console.WriteLine($" Компания : {ship.Key.ShippingCompany} Год производства : {ship.Key.YearOfConstruction}");

                foreach (var shipDefenition in ship)
                {
                    Console.WriteLine($" Название судна : {shipDefenition.Name}, Количество пассажиров : {shipDefenition.NumbOfPassenger}, Тип судна : {shipDefenition.Type}, Шифр : {shipDefenition.Ciper}");
                }
            }

            //в) сформировать запрос для подсчета числа кораблей в пароходстве;
            Console.WriteLine(new string('*', 180));

            var numbShipList = shipList.GroupBy(x => x.ShippingCompany).Select(s => new { ShippingCompany = s.Key, Count = s.Count(), Name = s.Select( s => s.Name)}).ToList();

            foreach (var ship in numbShipList)
            {
                Console.WriteLine($" Компания : {ship.ShippingCompany}, количество суден : {ship.Count}");

                foreach ( var name in ship.Name)
                { 
                   Console.WriteLine($" Названия : {name}");
                }
            }

            //г) соединить последовательности «корабль» и «река» по полю «шифр» и выдать данные: наименование корабля, название реки.

            Console.WriteLine(new string('*', 180));

            var joinList = shipList.Join( riverList , sh => sh.Ciper, rv => rv.Ciper, (sh, rv) => new { ShipName = sh.Name, RiverName = rv.Name });

            foreach (var item in joinList)
            {
                Console.WriteLine($" Название судна : {item.ShipName}, название реки : {item.RiverName}");
            }
        }
    }
}
