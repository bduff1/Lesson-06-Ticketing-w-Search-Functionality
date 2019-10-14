using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using NLog;
using System.IO;

namespace Ticketing_Search_BD
{
    class Program
    {
        string file { get; set; }


        static void Main(string[] args)
        {
            string filepath = "..\\..\\ticketData.txt";


            DisplayMenu(true);
            string userSelection = Console.ReadLine();


            TicketFile ticketList = new TicketFile();

            ticketList.FilePath = filepath;

            ticketList.LoadFile();

            do
            {
                if (userSelection == "1")
                {
                    // display from movies.csv file
                    int recordCount = 0;


                    foreach (var Ticket in ticketList.Tickets)
                    {
                        recordCount++;
                        Console.WriteLine();

                        if (recordCount % 20 == 0)
                        {
                            Console.WriteLine("Display more records? Y/N");
                            string contDispl = Console.ReadLine();
                            if (contDispl.ToUpper() == "N")
                                break;
                        }

                      
                        Console.WriteLine("Ticket ID: {0}, Issue: {1}, Personel Assigned: {2}, Status: {3}, Priority: {4}, Submitter: {5}, Watching: {6}",
                                            Ticket.TicketID, Ticket.TicketIssue, Ticket.TicketAssigned, Ticket.Status, Ticket.Priority, Ticket.Submitter, Ticket.Watching);

                        //Ticket.DisplayAssigned();
                    }
                    Console.WriteLine();
                    Console.WriteLine();

                }
                else if (userSelection == "2")
                {
                    // add a movie, if duplicated, throw exception
                    Console.WriteLine("New Ticket: Enter Issue Summary:");
                    string TicketIssue = Console.ReadLine();


                  

                    bool duplicate = false;
                    // check for duplicate title
                    using (StreamReader sr = new StreamReader(filepath))
                    {
                        while (!sr.EndOfStream && !duplicate)
                        {
                            string line = sr.ReadLine();

                            string[] values = line.Split(',');
                            if (values[1] == TicketIssue)
                            {

                                duplicate = true;
                                throw new Exception("You entered a duplicate issue");
                            }
                        }
                    }


                    Console.WriteLine("Enter Assigned Personel:");
                    string TicketAssigned = Console.ReadLine();

                    Console.WriteLine("Enter Status:");
                    string Status = Console.ReadLine();

                    Console.WriteLine("Enter Your Name:");
                    string Submitter = Console.ReadLine();

                    Console.WriteLine("Enter Personel to Watch Ticket");
                    string Watching = Console.ReadLine();



                    if (!duplicate)
                    {
                        // write to the file
                        using (StreamWriter sw = new StreamWriter(filepath, true))
                        {
                            int counter = 1;
                            int PriorityNum = counter++;




                            Random rnd = new Random();
                            int NewID = rnd.Next(1, 100);


                          
                            sw.WriteLine("{0},{1},{2},{3},{4},{5},{6}", NewID, TicketIssue, TicketAssigned, Status, PriorityNum, Submitter, Watching);
                        }
                    }
                }

                // Implement the search feature 

                else if (userSelection == "3")
                {
                    

                    Console.WriteLine("1) Search by Status");
                    Console.WriteLine("2) Seach by Priority");
                    Console.WriteLine("3) Search by Submitter");
                    

                    string SearchSelection = Console.ReadLine();

                   

                        if (SearchSelection == "1")
                        {

                            Console.WriteLine("Search for Ticket by Status");
                            var searchString = Console.ReadLine();

                            var results = ticketList.Tickets.Where(c => c.Status.Contains(searchString)).ToList();
                            
                            var count = results.Count();

                            Console.WriteLine();

                            Console.WriteLine("Tickets Containing: " + searchString);
                            Console.WriteLine();
                            Console.WriteLine(results.Count + " Results Returned: ");
                            //Console.WriteLine(results.Contains.searchString);
                            foreach (var item in results)
                            {
                                Console.WriteLine();

                                Console.WriteLine("Ticket ID: " + item.TicketID);
                                Console.WriteLine("Ticket Description: " + item.TicketIssue);
                                Console.WriteLine("Assigned to: " + item.TicketAssigned);
                                Console.WriteLine("Status: " + item.Status);
                                Console.WriteLine("Current Priority: " + item.Priority);
                                Console.WriteLine("Submitted By: " + item.Submitter);
                                Console.WriteLine("Currently Watching: " + item.Watching);
                                

                                Console.WriteLine();
                            }

                        }
                    
                        else if (SearchSelection == "2")
                    {

                        Console.WriteLine("Search for Ticket by Priority");
                        var searchString = Console.ReadLine();

                        var results = ticketList.Tickets.Where(c => c.Priority.Contains(searchString)).ToList();

                        var count = results.Count();


                        Console.WriteLine("Tickets Criteria Matching: " + searchString);
                        Console.WriteLine();
                        Console.WriteLine(results.Count + " Results Returned: ");
                        //Console.WriteLine(results.Contains.searchString);
                        foreach (var item in results)
                        {
                            Console.WriteLine();

                             Console.WriteLine("Ticket ID: " + item.TicketID);
                             Console.WriteLine("Ticket Description: " + item.TicketIssue);
                             Console.WriteLine("Assigned to: " + item.TicketAssigned);
                             Console.WriteLine("Status: " + item.Status);
                             Console.WriteLine("Current Priority: " + item.Priority);
                             Console.WriteLine("Submitted By: " + item.Submitter);
                             Console.WriteLine("Currently Watching: " + item.Watching);

                            Console.WriteLine();
                        }

                    }

                    else if (SearchSelection == "3")
                    {

                        Console.WriteLine("Search for Ticket by Submitter");
                        var searchString = Console.ReadLine();

                        var results = ticketList.Tickets.Where(c => c.Submitter.Contains(searchString)).ToList();

                        var count = results.Count();


                        Console.WriteLine("Tickets Containing: " + searchString);
                        Console.WriteLine();
                        Console.WriteLine(results.Count + " Results Returned: ");
                        //Console.WriteLine(results.Contains.searchString);
                        foreach (var item in results)
                        {
                            Console.WriteLine();

                            Console.WriteLine("Ticket ID: " + item.TicketID);
                            Console.WriteLine("Ticket Description: " + item.TicketIssue);
                            Console.WriteLine("Assigned to: " + item.TicketAssigned);
                            Console.WriteLine("Status: " + item.Status);
                            Console.WriteLine("Current Priority: " + item.Priority);
                            Console.WriteLine("Submitted By: " + item.Submitter);
                            Console.WriteLine("Currently Watching: " + item.Watching);

                            Console.WriteLine();
                        }

                    }



               

                }



                else if (userSelection == "4")
                {
                    // end the application
                }



                DisplayMenu(false);
                userSelection = Console.ReadLine();

            } while (userSelection != "4");


            Console.ReadLine();

        }

        public static void DisplayMenu(bool firstTime)
        {

            Console.WriteLine("1) Display Tickets");
            Console.WriteLine("2) Open a Ticket");
            Console.WriteLine("3) Search for Ticket");
            Console.WriteLine("4) Exit application");
            //Console.WriteLine("4 Search for Ticket");
        }

    }
}
