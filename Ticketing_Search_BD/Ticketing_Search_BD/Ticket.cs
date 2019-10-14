using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticketing_Search_BD
{
    class Ticket
    {
        public string TicketID { get; set; }
        public string TicketIssue { get; set; }
        // public List<string> TicketAssigned { get; set; }

        public string TicketAssigned { get; set; }
        public string Status { get; set; }

        public string Priority { get; set; }

        public string Submitter { get; set; }




        public string Watching { get; set; }


        //public Ticket(string TicketID, string TicketIssue, List<string> TicketAssigned, string Status)
        //public Ticket(string TicketID, string TicketIssue, string TicketAssigned, string Status, string Priority, string Submitter, string Watching)
        public Ticket(string TicketID, string TicketIssue, string TicketAssigned, string Status, string Priority, string submitter, string Watching)
        {
            this.TicketID = TicketID;
            this.TicketIssue = TicketIssue;
            this.TicketAssigned = TicketAssigned;
            this.Status = Status;
            this.Priority = Priority;
            this.Submitter = submitter;
            this.Watching = Watching;
            

        }

      
    }
}
