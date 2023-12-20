using Domain.Entities.PlayerEntities;

namespace Domain.Entities.Items.CharacterItems
{
    public class CharacterItem : BaseCharacterItem
    {
        public override ParameterType Parameter { get; }

        public override int ChangeValue { get; }

        public override string Name { get; }

        public override string Description { get; }
        public CharacterItem(ParameterType parameter, int changeValue, string name, string description) 
        {
            Parameter = parameter; 
            ChangeValue = changeValue;
            Name = name; 
            Description = description;
        }
    }
}
