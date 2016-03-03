/* Créé par Scriptiz pour le livre de barde de Plume */
using System;
using Server.Misc;

namespace Server.Items
{
	[FlipableAttribute( 0x1515, 0x1530 )] 
	public class BardeCloak : Cloak 
	{ 
		[Constructable] 
		public BardeCloak() : base( 372 ) 
		{ 
			Name = "Cape du Barde";
            Hue = 44;
            
            Attributes.BonusInt = 15;
            SkillBonuses.SetValues(0, SkillName.Musicianship, 10.0);
            SkillBonuses.SetValues(1, SkillName.Provocation, 10.0);
            SkillBonuses.SetValues(2, SkillName.Peacemaking, 10.0);
		} 

		public override bool Dye( Mobile from, DyeTub sender )
		{
			from.SendLocalizedMessage( 1042083 ); // You can not dye that.
			return false;
		}

        public BardeCloak(Serial serial)
            : base(serial)
        {
        }

		public override void Serialize( GenericWriter writer ) 
		{ 
			base.Serialize( writer ); 
			writer.Write( (int) 0 ); 
		} 

		public override void Deserialize(GenericReader reader) 
		{ 
			base.Deserialize( reader ); 
			int version = reader.ReadInt(); 
		} 
	} 
}
