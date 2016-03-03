using System; 
using System.Collections; 
using Server.Misc; 
using Server.Items; 
using Server.Mobiles; 

namespace Server.Mobiles 
{ 
	public class Gancien2 : BaseCreature 
	{ 
		[Constructable] 
		public Gancien2() : base( AIType.AI_Archer, FightMode.Aggressor, 10, 1, 0.2, 0.4 ) 
		{ 
			InitStats( 125, 125, 125 ); 
			SetHits( 500 );
			Title = "Le guerrier Ancien Sacre"; 

			SpeechHue = Utility.RandomDyedHue(); 

			Hue = Utility.RandomSkinHue(); 

			if ( Female = Utility.RandomBool() ) 
			{ 
				Body = 0x191; 
				Name = NameList.RandomName( "female" ); 
			} 
			else 
			{ 
				Body = 0x190; 
				Name = NameList.RandomName( "male" ); 
			} 

			new Horse().Rider = this; 

			PlateChest chest = new PlateChest(); 
			chest.Hue = 0x901; 
			AddItem( chest ); 
			PlateArms arms = new PlateArms(); 
			arms.Hue = 0x901; 
			AddItem( arms ); 
			PlateGloves gloves = new PlateGloves(); 
			gloves.Hue = 0x901; 
			AddItem( gloves ); 
			PlateGorget gorget = new PlateGorget(); 
			gorget.Hue = 0x901; 
			AddItem( gorget ); 
			PlateLegs legs = new PlateLegs(); 
			legs.Hue = 0x901; 
			AddItem( legs ); 
			PlateHelm helm = new PlateHelm(); 
			helm.Hue = 0x901; 
			AddItem( helm ); 
			Robe robe = new Robe(); 
			robe.Hue = 0x901; 
			AddItem( robe ); 

			Maul maul = new Maul(); 

			maul.Movable = false; 
			maul.Crafter = this; 
			maul.Quality = WeaponQuality.Regular; 

			AddItem( maul ); 


			ControlSlots = 1;

			Skills[SkillName.Anatomy].Base = 125.0; 
			Skills[SkillName.Tactics].Base = 125.0; 
			Skills[SkillName.Macing].Base = 125.0; 
			Skills[SkillName.MagicResist].Base = 125.0; 
			Skills[SkillName.DetectHidden].Base = 125.0; 

		} 

		public Gancien2( Serial serial ) : base( serial ) 
		{ 
		} 

		public override void Serialize( GenericWriter writer ) 
		{ 
			base.Serialize( writer ); 

			writer.Write( (int) 0 ); // version 
		} 

		public override void Deserialize( GenericReader reader ) 
		{ 
			base.Deserialize( reader ); 

			int version = reader.ReadInt(); 
		} 
	} 
}