using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Multitaschenrechner
{
    public class NormalCalcList
    {
        public List<NormalCalc> calcs = new List<NormalCalc>();

        public void Add(NormalCalc calc)
        {
            if (calc.Rechnung != "0")
            {
                Logging.logger.Information("Rechnung wurde hinzugefügt:" , calc.Rechnung, "=", calc.Ergebnis);
                calcs.Add(calc);
            }
        }

        public void UpdateListBox(ListBox listBox, Label lbl)
        {
            listBox.Items.Clear();
            foreach (NormalCalc calc in calcs)
            {
                listBox.Items.Add($"{calc.Rechnung} = {calc.Ergebnis}");
            }
            Logging.logger.Information("ListBox wurde aktualisiert");
        }

        public void Save(string filename)
        {
            using (StreamWriter stream = new StreamWriter(filename))
            {
                foreach (NormalCalc calc in calcs)
                {
                    string serialized = calc.SerializeToCsv();

                    stream.WriteLine(serialized);
                }
            }
        }

        public void Load(string filename)
        {
            try
            {
                using (StreamReader stream = new StreamReader(filename))
                {
                    calcs.Clear();

                    while (stream.EndOfStream == false)
                    {
                        string line = stream.ReadLine();
                        try
                        {
                            NormalCalc calc = NormalCalc.DeSerializeToCsv(line);

                            calcs.Add(calc);
                        }
                        catch (ArgumentException)
                        {
                            // Einträge ignorieren die nicht gelesen werden können
                            Logging.logger.Information("Eintrag konnte nicht gelesen werden: {line}", line);
                        }

                    }
                }
            }
            catch (FileNotFoundException)
            {
                Logging.logger.Error("Datei konnte nicht gelesen werden: {filename}", filename);
                MessageBox.Show($"Datei konnte nicht gelesen werden: {filename}");
            }
        }

        public void SetLastCalc(string str, Label lbl, NormalCalc calc)
        {
            calc.LastEntry = str.Last().ToString();
            lbl.Content = str;
        }
    }
}
