using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGSuite_dev
{
    class DataController
    {
        public DataController()
        {

        }
        public void loadFile(string filename)
        {
            try
            {
                string[] lines = File.ReadAllLines(System.IO.Path.ChangeExtension(filename, ".csv"));

            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Errore file non trovato");
            }
        }
    }
}
