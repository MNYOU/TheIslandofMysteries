using Domain.Entities.PlayerEntities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Items.CharacterItems
{
    public abstract class BaseCharacterItem : Item
    {
        public abstract ParameterType Parameter { get; }
        public abstract int ChangeValue { get; }
        public ItemType Type => ItemType.CharacterItem;

        public abstract string Name { get; }
        public abstract string Description { get; }
    }
}
