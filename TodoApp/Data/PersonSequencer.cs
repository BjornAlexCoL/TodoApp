using System;
using System.Collections.Generic;
using System.Text;

namespace TodoApp.Data
{
    class PersonSequencer
    {
        private static int personId = 0;

        public static int NextPersonID()
        {
            return ++personId;
        }

        public static void Reset()
        {
            personId = 0;
        }
    }
}
