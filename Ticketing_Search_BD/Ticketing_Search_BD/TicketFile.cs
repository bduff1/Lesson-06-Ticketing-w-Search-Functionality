using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticketing_Search_BD
{
    class TicketFile
    {
        public string FilePath { get; set; }
        public char Delimiter { get; set; }

        public List<Ticket> Tickets { get; }

        //private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public TicketFile()
        {
            Delimiter = ',';
            Tickets = new List<Ticket>();
        }

        public void LoadFile()
        {
            //logger.Info("Loading movie file {0}", FilePath);

            using (StreamReader sr = new StreamReader(FilePath))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();

                    string[] values = line.Split(',');

                    Ticket record = new Ticket(values[0], values[1], values[2], values[3], values[4], values[5], values[6]);
                    Tickets.Add(record);


                }
            }

        }

    }
}
