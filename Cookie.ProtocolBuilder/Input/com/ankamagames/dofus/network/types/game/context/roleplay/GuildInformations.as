package com.ankamagames.dofus.network.types.game.context.roleplay
{
   import com.ankamagames.dofus.network.types.game.guild.GuildEmblem;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class GuildInformations extends BasicGuildInformations implements INetworkType
   {
      
      public static const protocolId:uint = 127;
       
      
      public var guildEmblem:GuildEmblem;
      
      private var _guildEmblemtree:FuncTree;
      
      public function GuildInformations()
      {
         this.guildEmblem = new GuildEmblem();
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 127;
      }
      
      public function initGuildInformations(param1:uint = 0, param2:String = "", param3:uint = 0, param4:GuildEmblem = null) : GuildInformations
      {
         super.initBasicGuildInformations(param1,param2,param3);
         this.guildEmblem = param4;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.guildEmblem = new GuildEmblem();
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_GuildInformations(param1);
      }
      
      public function serializeAs_GuildInformations(param1:ICustomDataOutput) : void
      {
         super.serializeAs_BasicGuildInformations(param1);
         this.guildEmblem.serializeAs_GuildEmblem(param1);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GuildInformations(param1);
      }
      
      public function deserializeAs_GuildInformations(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this.guildEmblem = new GuildEmblem();
         this.guildEmblem.deserialize(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GuildInformations(param1);
      }
      
      public function deserializeAsyncAs_GuildInformations(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         this._guildEmblemtree = param1.addChild(this._guildEmblemtreeFunc);
      }
      
      private function _guildEmblemtreeFunc(param1:ICustomDataInput) : void
      {
         this.guildEmblem = new GuildEmblem();
         this.guildEmblem.deserializeAsync(this._guildEmblemtree);
      }
   }
}
