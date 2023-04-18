using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Prac2_18_04
{
    public class Bank
    {
        string defPath = "BankInfo.xml";
        XDocument _doc;
        public Bank(string name) 
        {
            this.Name = name;
            _doc = new XDocument(new XElement("root", new XElement("bank", new XAttribute("name", Name), new XElement("money", money), new XElement("percent", percent))));
            _doc.Save(defPath);
        }
        public void ChangeMoneyThread()
        {
            var root = _doc.Root;            
            var MoneyElem = root.Elements("bank")?.FirstOrDefault(obj => obj.Attribute("name").Value == Name).Element("money");
            MoneyElem.Value = money.ToString();
            _doc.Save(defPath);
            Console.WriteLine("Money value was changed");
        }
        public void ChangePercentThread()
        {
            var root = _doc.Root;
            var PercentElem = root.Elements("bank")?.FirstOrDefault(obj => obj.Attribute("name").Value == Name).Element("percent");
            PercentElem.Value = percent.ToString();
            _doc.Save(defPath);
            Console.WriteLine("Percent value as changed");

        }
        public string Name { get; set; }
        double money = 0;
        public double Money 
        {
            get {  return money; }
            set
            {
                if(value > 0)
                {
                    money = value;
                    Thread th = new Thread(new ThreadStart(ChangeMoneyThread));
                    th.IsBackground = true;
                    th.Start();
                }
            }
        }
        double percent = 0;
        public double Percent { 
            get { return percent; }
            set
            {
                if (value <= 100 && value >= 0)
                {
                    percent = value;
                    Thread th = new Thread(new ThreadStart(ChangePercentThread));
                    th.IsBackground = true;
                    th.Start();
                }
            }
        }
    }
}
