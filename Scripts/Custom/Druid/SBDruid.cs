using System;
using System.Collections.Generic;
using Server.Items; 

namespace Server.Mobiles 
{ 
   public class SBDruid : SBInfo 
   {
        private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
        private IShopSellInfo m_SellInfo = new InternalSellInfo(); 

      public SBDruid() 
      { 
      } 

      public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
        public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

        public class InternalBuyInfo : List<GenericBuyInfo>
        { 
         public InternalBuyInfo() 
         { 
            /*Add( new GenericBuyInfo( "Appel de la Foret", typeof( BlendWithForestScroll ), 72, 144, 0x136C, 0 ) ); 
            //Add( new GenericBuyInfo( "Enchevetrements", typeof( GraspingRootsScroll ), 72, 144, 0x136C, 0 ) ); 
            Add( new GenericBuyInfo( "Force de la terre", typeof( HollowReedScroll ), 72, 144, 0x136C, 0 ) ); 
            //Add( new GenericBuyInfo( "Bouclier de terre", typeof( SheildOfEarthScroll ), 72, 144, 0x136C, 0 ) ); 
            //Add( new GenericBuyInfo( "Appel de la meute", typeof( PackOfBeastScroll ), 72, 144, 0x136C, 0 ) ); 
            Add( new GenericBuyInfo( "Appel de la vie", typeof( SpringOfLifeScroll ), 72, 144, 0x136C, 0 ) ); 
            Add( new GenericBuyInfo( "Appel des insectes", typeof( SwarmOfInsectsScroll ), 72, 144, 0x136C, 0 ) ); 
            //Add( new GenericBuyInfo( "Eruption Volcanique", typeof( VolcanicEruptionScroll ), 72, 144, 0x136C, 0 ) ); 
            Add( new GenericBuyInfo( "Luciole", typeof( FireflyScroll ), 72, 144, 0x136C, 0 ) ); 
            //Add( new GenericBuyInfo( "leure de pierre", typeof( LureStoneScroll ), 72, 144, 0x136C, 0 ) ); 
            //Add( new GenericBuyInfo( "cercle de pierre", typeof( MushroomCircleScroll ), 72, 144, 0x136C, 0 ) ); 
            Add( new GenericBuyInfo( "Portail des Champignons", typeof( MushroomGatewayScroll ), 72, 144, 0x136C, 0 ) ); 
            //Add( new GenericBuyInfo( "passage de la nature", typeof( NaturesPassageScroll ), 72, 144, 0x136C, 0 ) ); 
            Add( new GenericBuyInfo( "Efluve de vie", typeof( RestorativeSoilScroll ), 72, 144, 0x136C, 0 ) ); 
            //Add( new GenericBuyInfo( "Appel un esprit sylvains", typeof( TreefellowScroll ), 72, 144, 0x136C, 0 ) ); 
*/
            Add( new GenericBuyInfo( "Destroying Angel reagent",typeof( DestroyingAngel ), 5, 500, 0x0F7F, 0 ) ); 
            Add( new GenericBuyInfo( "Petrified Wood reagent", typeof( PetrafiedWood ), 4, 500, 0x0F90, 0 ) ); 
            Add( new GenericBuyInfo( "Spring Water reagent", typeof( SpringWater ), 5, 500, 0xE24, 0 ) ); 
            //Add( new GenericBuyInfo( "Pierre sacre", typeof( SacredStone ), 12, 500, 0xE24, 0 ) ); 

            //Add( new GenericBuyInfo( "Tome of Nature spellbook", typeof( DruidicSpellbook ), 144, 10, 0xEFA, 0 ) ); 
         } 
      } 

      public class InternalSellInfo : GenericSellInfo 
      { 
         public InternalSellInfo() 
         { 
            Add( typeof( DestroyingAngel ), 3 ); 
            Add( typeof( PetrafiedWood ), 3 ); 
            Add( typeof( SpringWater ), 3 ); 
         } 
      } 
   } 
}
