using System;
using System.IO;
using System.Xml.Linq;

namespace Ex4
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowSystemMessage("Введи ФИО контакта:");
            string name = Console.ReadLine();

            XAttribute attribute = new XAttribute("name", name);
            XElement xmlPerson = new XElement("Person", attribute);

            ShowSystemMessage("Введи название улицы:");
            string street = Console.ReadLine();

            XElement xmlStreet = new XElement("Street", street);

            ShowSystemMessage("Номер дома:");
            string houseNumber = Console.ReadLine();

            XElement xmlHouseNumber = new XElement("HouseNumber", houseNumber);

            ShowSystemMessage("Номер квартиры:");
            string flatNumber = Console.ReadLine();

            XElement xmlFlatNumber = new XElement("FlatNumber", flatNumber);

            XElement xmlAddress = new XElement("Address",
                xmlStreet,
                xmlHouseNumber,
                xmlFlatNumber
                );
            xmlPerson.Add(xmlAddress);

            ShowSystemMessage("Мобильный телефон:");
            string mobilePhone = Console.ReadLine();

            XElement xmlMobilePhone = new XElement("MobilePhone", mobilePhone);

            ShowSystemMessage("Домашний телефон:");
            string flatPhone = Console.ReadLine();

            XElement xmlFlatPhone = new XElement("FlatPhone", flatPhone);

            XElement xmlPhones = new XElement("Phones",
                xmlMobilePhone,
                xmlFlatPhone
                );

            xmlPerson.Add(xmlPhones);

            string pathToMyDocument = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string allPath = Path.Combine(pathToMyDocument, "Person.xml");

            try
            {
                xmlPerson.Save(allPath);
                ShowSystemMessage("Файл успешно сохранен в " + allPath);
            } catch (Exception e)
            {
                ShowSystemMessage("Не удалось сохранить файл");
            }
        }

        private static void ShowSystemMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
