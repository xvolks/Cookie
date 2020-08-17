package com.ankamagames.dofus.network.types.game.context.fight
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class GameFightMinimalStatsPreparation extends GameFightMinimalStats implements INetworkType
   {
      
      public static const protocolId:uint = 360;
       
      
      public var initiative:uint = 0;
      
      public function GameFightMinimalStatsPreparation()
      {
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 360;
      }
      
      public function initGameFightMinimalStatsPreparation(param1:uint = 0, param2:uint = 0, param3:uint = 0, param4:uint = 0, param5:uint = 0, param6:int = 0, param7:int = 0, param8:int = 0, param9:int = 0, param10:Number = 0, param11:Boolean = false, param12:int = 0, param13:int = 0, param14:int = 0, param15:int = 0, param16:int = 0, param17:int = 0, param18:int = 0, param19:int = 0, param20:int = 0, param21:int = 0, param22:int = 0, param23:int = 0, param24:int = 0, param25:int = 0, param26:int = 0, param27:int = 0, param28:int = 0, param29:int = 0, param30:int = 0, param31:int = 0, param32:int = 0, param33:int = 0, param34:uint = 0, param35:uint = 0, param36:int = 0, param37:int = 0, param38:int = 0, param39:uint = 0, param40:uint = 0, param41:uint = 0, param42:uint = 0, param43:uint = 0, param44:uint = 0) : GameFightMinimalStatsPreparation
      {
         super.initGameFightMinimalStats(param1,param2,param3,param4,param5,param6,param7,param8,param9,param10,param11,param12,param13,param14,param15,param16,param17,param18,param19,param20,param21,param22,param23,param24,param25,param26,param27,param28,param29,param30,param31,param32,param33,param34,param35,param36,param37,param38,param39,param40,param41,param42,param43);
         this.initiative = param44;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.initiative = 0;
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_GameFightMinimalStatsPreparation(param1);
      }
      
      public function serializeAs_GameFightMinimalStatsPreparation(param1:ICustomDataOutput) : void
      {
         super.serializeAs_GameFightMinimalStats(param1);
         if(this.initiative < 0)
         {
            throw new Error("Forbidden value (" + this.initiative + ") on element initiative.");
         }
         param1.writeVarInt(this.initiative);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GameFightMinimalStatsPreparation(param1);
      }
      
      public function deserializeAs_GameFightMinimalStatsPreparation(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._initiativeFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GameFightMinimalStatsPreparation(param1);
      }
      
      public function deserializeAsyncAs_GameFightMinimalStatsPreparation(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._initiativeFunc);
      }
      
      private function _initiativeFunc(param1:ICustomDataInput) : void
      {
         this.initiative = param1.readVarUhInt();
         if(this.initiative < 0)
         {
            throw new Error("Forbidden value (" + this.initiative + ") on element of GameFightMinimalStatsPreparation.initiative.");
         }
      }
   }
}
