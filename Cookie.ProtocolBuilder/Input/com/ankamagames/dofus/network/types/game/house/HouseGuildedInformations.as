package com.ankamagames.dofus.network.types.game.house
{
   import com.ankamagames.dofus.network.types.game.context.roleplay.GuildInformations;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class HouseGuildedInformations extends HouseInstanceInformations implements INetworkType
   {
      
      public static const protocolId:uint = 512;
       
      
      public var guildInfo:GuildInformations;
      
      private var _guildInfotree:FuncTree;
      
      public function HouseGuildedInformations()
      {
         this.guildInfo = new GuildInformations();
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 512;
      }
      
      public function initHouseGuildedInformations(param1:uint = 0, param2:Boolean = false, param3:Boolean = false, param4:String = "", param5:Number = 0, param6:Boolean = false, param7:GuildInformations = null) : HouseGuildedInformations
      {
         super.initHouseInstanceInformations(param1,param2,param3,param4,param5,param6);
         this.guildInfo = param7;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.guildInfo = new GuildInformations();
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_HouseGuildedInformations(param1);
      }
      
      public function serializeAs_HouseGuildedInformations(param1:ICustomDataOutput) : void
      {
         super.serializeAs_HouseInstanceInformations(param1);
         this.guildInfo.serializeAs_GuildInformations(param1);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_HouseGuildedInformations(param1);
      }
      
      public function deserializeAs_HouseGuildedInformations(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this.guildInfo = new GuildInformations();
         this.guildInfo.deserialize(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_HouseGuildedInformations(param1);
      }
      
      public function deserializeAsyncAs_HouseGuildedInformations(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         this._guildInfotree = param1.addChild(this._guildInfotreeFunc);
      }
      
      private function _guildInfotreeFunc(param1:ICustomDataInput) : void
      {
         this.guildInfo = new GuildInformations();
         this.guildInfo.deserializeAsync(this._guildInfotree);
      }
   }
}
