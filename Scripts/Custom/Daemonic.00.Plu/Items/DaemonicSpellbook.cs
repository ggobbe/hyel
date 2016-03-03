using System;
using Server.Network;
using Server.Spells;
using Server.Mobiles;
using Server.Gumps;
namespace Server.Items
{
	public class DaemonicSpellbook : Spellbook
	{
		public override SpellbookType SpellbookType{ get{ return SpellbookType.Daemonic; } }
		public override int BookOffset{ get{ return 130; } }
		public override int BookCount{ get{ return 10; } }

        //public override Item Dupe( int amount )
        //{
        //    Spellbook book = new DaemonicSpellbook();

        //    book.Content = this.Content;

        //    return base.Dupe( book, amount );
        //}

		[Constructable]
		public DaemonicSpellbook() : this( (ulong)0 ) //0x3ff
		{
			Name = "Cresh'ind'hor";
			Hue = 0x89d;
 			LootType = LootType.Newbied;     			
		}

		[Constructable]
		public DaemonicSpellbook( ulong content ) : base( content, 8787 )
		{
 			LootType = LootType.Newbied;     
		}

     public override void OnDoubleClick( Mobile from )
      {
  
  
    	 if ( from is PlayerMobile)// && (((PlayerMobile)from).PAnim )) 
 
 		{
         	if ( from.InRange( GetWorldLocation(), 1 ) )


                from.CloseGump(typeof(DaemonicSpellbookGump));
            from.SendGump(new DaemonicSpellbookGump(from, this));
        }

         else if (from is PlayerMobile && (from.Skills[SkillName.Magery].Value <= 90)) //(((PlayerMobile)from).Necro2 )
		{
         	if ( from.InRange( GetWorldLocation(), 1 ) )


                from.CloseGump(typeof(DaemonicSpellbookGump));
            from.SendGump(new DaemonicSpellbookGump(from, this));
        }	    	 
         	 
         	 
         else from.SendMessage("Vous ne savez pas lire ce livre");
	 
      }


     public DaemonicSpellbook(Serial serial)
         : base(serial)
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
			Layer = Layer.Invalid;
		}
	}
}
