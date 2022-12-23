using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;



namespace AtudaimProject

{

    class ShopQueue
    {
        public ArrayList CostumerQueue = new ArrayList(); // costumers queue Arraylist.

        public double CostumerBodyTemp { set; get; } // costumer's body temperature.
        public int MaskWearing { set; get; } // is the sotumer wearing a mask.

        public void CostumerList()
        {
            foreach (string costumerName in CostumerQueue)
            {
                Console.WriteLine(costumerName);
            }
        }
        
    }
}


