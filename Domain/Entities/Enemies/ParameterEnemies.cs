using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Enemies
{
    public class ParameterEnemies
    {
        public ParameterTypeEnemies Type { get; set; }

        public int Value { get; set; }

        public ParameterEnemies(ParameterTypeEnemies type, int value)
        {
            if (value is < 0 or > 100)
                throw new ArgumentException();
            Type = type;
            Value = value;
        }
    }
}
