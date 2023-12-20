using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Items.ItemForGame
{
    public abstract class BaseItemForGame : Item
    {
        public abstract string Name { get; }

        public abstract string Description { get; }

        public ItemType Type => ItemType.ItemForGame;

    }
}
