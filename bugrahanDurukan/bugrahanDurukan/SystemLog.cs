using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace bugrahanDurukan
{
    //Create a generic class
    //Implement at least one indexer

    class SystemLog<T> : IEnumerable
    {
        private List<T> logList = new List<T>();
        public T this[int index]
        {
            get => logList[index];
            set => logList.Insert(index, value);
        }

        public void viewLog()
        {
            foreach (object o in logList)
            {
                Console.WriteLine(o);
            }
            Console.WriteLine(logList.Count + " actions were detected.\n");
            Console.WriteLine("------End of System Log------");
        }

        public int Count => logList.Count;

        IEnumerator IEnumerable.GetEnumerator() => logList.GetEnumerator();
    }
}
