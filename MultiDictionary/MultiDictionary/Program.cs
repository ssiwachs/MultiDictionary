using MultiDictionary.Models;
using MultiDictionary.Services;
using System;
using System.Collections.Generic;

namespace MultiDictionary
{
    class Program
    {
        MultiDictionaryService dictionary = new MultiDictionaryService();
        string key;
        IList<string> value = new List<string>();
        static void Main(string[] args)
        {
            var program = new Program();
            Console.WriteLine("\n Welcome to Dictionary Utility \n");
            var optionSelected = ShowOptions();
            program.PerformOption(optionSelected);
            Console.Read();
        }

        private void PerformOption(int optionSelected)
        {
            string input;
            try
            {
                switch (optionSelected)
                {
                    case 1:
                        Console.WriteLine(" \n Enter Key and then members, separated by whitespace! \n");
                        input = Console.ReadLine();
                        var inputArray = input.Split(" ");
                        key = inputArray[0];
                        value = new List<string>();
                        for (int i = 1; i < inputArray.Length; i++)
                        {
                            if (!value.Contains(inputArray[i]))
                                value.Add(inputArray[i]);
                        }
                        dictionary.Add(key, value);
                        DisplayResult(null);
                        Console.WriteLine(" \n What you want to do next? \n");
                        break;

                    case 2:
                        Console.WriteLine(" \n Enter Key and then members, separated by whitespace! \n");
                        input = Console.ReadLine();
                        dictionary.RemoveMemberFor(input.Split(" ")[0], input.Split(" ")[1]);
                        DisplayResult(null);
                        break;

                    case 3:
                        var keys = dictionary.AllKeys();
                        DisplayResult(keys);
                        break;

                    case 4:
                        Console.WriteLine(" \n Enter Key! \n");
                        input = Console.ReadLine();
                        var members = dictionary.AllMembersForKey(input);
                        DisplayResult(members);
                        break;

                    case 5:
                        Console.WriteLine(" \n Enter Key ! \n");
                        input = Console.ReadLine();
                        dictionary.RemoveAllForKey(input);
                        DisplayResult(null);
                        break;

                    case 6:
                        dictionary.Clear();
                        DisplayResult(null);
                        break;

                    case 7:
                        Console.WriteLine(" \n Enter Key ! \n");
                        input = Console.ReadLine();
                        var isKey = dictionary.IsKey(input);
                        DisplayResult(new List<string> { isKey.ToString() });
                        break;

                    case 8:
                        Console.WriteLine(" \n Enter Key and then member, separated by whitespace! \n");
                        input = Console.ReadLine();
                        var isValidMember = dictionary.IsMemberForKey(input.Split(" ")[0], input.Split(" ")[1]);
                        DisplayResult(new List<string> { isValidMember.ToString() });
                        break;

                    case 9:
                        var allMembers = dictionary.AllMembers();
                        DisplayResult(allMembers);
                        break;

                    case 10:
                        var allItems = dictionary.AllItems();
                        DisplayResult(null, allItems);
                        break;

                    case 0:
                        Environment.Exit(0);
                        break;

                    case 11:
                        var count = dictionary.Count();
                        DisplayResult(new List<string> { count.ToString() });
                        break;

                    case 12:
                        Console.WriteLine(" \n Enter one Key ! \n");
                        input = Console.ReadLine();
                        var countMember = dictionary.MemberCount(input.Split(" ")[0]);
                        DisplayResult(new List<string> { countMember.ToString() });
                        break;

                    case 13:                        
                        Console.WriteLine(" \n Enter one member ! \n");
                        input = Console.ReadLine();
                        var memberOfKey = dictionary.MemberOf(input.Split(" ")[0]);
                        DisplayResult((memberOfKey!=null) ? new List<string> { memberOfKey.ToString() } : null);
                        break;

                    default:
                        break;
                }
                var userSelected = ShowOptions();
                PerformOption(userSelected);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
         
        }

        private void DisplayResult(IList<string> items, IList<MultiDictionaryModel> allItems = null)
        {
            Console.WriteLine("\n------------------ RESULT BELOW------------------ \n");

            if (dictionary.message != null || items == null)
            {
                Console.WriteLine(dictionary.message);
            }
            else
            {
                foreach (var item in items)
                {
                    Console.WriteLine(item.ToString());

                }

            }
            if (allItems != null)
            {
                if (allItems.Count >0)
                {
                    foreach (var item in allItems)
                    {
                        Console.Write(item.key);
                        foreach (var value in item.value)
                        {
                            Console.Write("-->");
                            Console.Write(value);
                        }
                        Console.WriteLine("\n");

                    }
                }
                else
                {
                    Console.WriteLine("Dictionary Empty");
                }
                

            }
        }

        private static int ShowOptions()
        {
            Console.WriteLine("\n--------------------------------------------------");
            Console.WriteLine("Please choose one! Enter numeric value only \n");
            Console.WriteLine("1-ADD");
            Console.WriteLine("2-REMOVE");
            Console.WriteLine("3-KEYS");
            Console.WriteLine("4-MEMBERS");
            Console.WriteLine("5-REMOVE ALL");
            Console.WriteLine("6-CLEAR");
            Console.WriteLine("7-KEY EXISTS");
            Console.WriteLine("8-MEMBER EXISTS");
            Console.WriteLine("9-ALL MEMBERS");
            Console.WriteLine("10-ITEMS\n");
            Console.WriteLine("0-Exit \n");
            Console.WriteLine("ADVANCE OPTIONS BELOW");
            Console.WriteLine("11-Count");
            Console.WriteLine("12-Members Count");
            Console.WriteLine("13-Member Of Key\n");
           
            int input;
            bool isNumeric = int.TryParse(Console.ReadLine(), out input);
            if (!isNumeric || input<0 || input>14)
            {
              Console.WriteLine("\n Invalid Entry, Please try again. \n");
              input = ShowOptions();
            }

            return input;

        }



    }
}
