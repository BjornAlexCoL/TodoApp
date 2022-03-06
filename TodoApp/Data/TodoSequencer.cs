using System;
using System.Collections.Generic;
using System.Text;

namespace TodoApp.Data
{
    public class TodoSequencer
    {
        private static int todoId = 0;
        public static int NextTodoId()            
        {
            return ++todoId;
        }

        public static void Reset()
        {
            todoId = 0;
        }

    } // End TodoSequencer


}
