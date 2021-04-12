using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lastiq.Models
{
    public class StickModel
    {
        public bool Completed { get; set; }
        
        //Я добавил это для теста поиска, если должно быть не так то сделай правильно, а я переделаю
        public string Text { get; set; }
    }
}
