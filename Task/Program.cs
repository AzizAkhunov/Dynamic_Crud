﻿using Task;

var service = new Service();
//service.CreateTable_Users();
//service.AddUser();
//Console.Write("Nma olib kelish: ");
//string info = Console.ReadLine();
//Console.Write("Shartni yoznig: ");
//string shart = Console.ReadLine();
//service.GetUserBy(info,shart);
//Console.Write("Qaysi Tablega malumot kiritmoqchisiz?: ");
//string table = Console.ReadLine(); 
//Console.Write("Ism: ");
//string name = Console.ReadLine();
//Console.Write("Familiya: ");
//string surname = Console.ReadLine();
//Console.Write("Email: ");
//string email = Console.ReadLine();
//service.InsertToTableDynamic(table,name,surname,email);
Console.Write("Table name: ");
string tablename = Console.ReadLine();
Console.Write("Nmasi orqali uchirmoqchisiz?: ");
string where = Console.ReadLine();
Console.Write("teng bulsa: ");
string id = Console.ReadLine();
service.DeleteByDynamic(tablename,where,id);