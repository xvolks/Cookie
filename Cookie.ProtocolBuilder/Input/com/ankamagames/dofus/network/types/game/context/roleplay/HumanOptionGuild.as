package com.ankamagames.dofus.network.types.game.context.roleplay
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   [Trusted]
   public class HumanOptionGuild extends HumanOption implements INetworkType
   {
      
      public static const protocolId:uint = 409;
       
      
      public var guildInformations:GuildInformations;
      
      private var _guildInformationstree:FuncTree;
      
      public function HumanOptionGuild()
      {
         this.guildInformations = new GuildInformations();
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 409;
      }
      
      public function initHumanOptionGuild(param1:GuildInformations = null) : HumanOptionGuild
      {
         this.guildInformations = param1;
         return this;
      }
      
      override public function reset() : void
      {
         this.guildInformations = new GuildInformations();
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_HumanOptionGuild(param1);
      }
      
      public function serializeAs_HumanOptionGuild(param1:ICustomDataOutput) : void
      {
         super.serializeAs_HumanOption(param1);
         this.guildInformations.serializeAs_GuildInformations(param1);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_HumanOptionGuild(param1);
      }
      
      public function deserializeAs_HumanOptionGuild(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this.guildInformations = new GuildInformations();
         this.guildInformations.deserialize(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_HumanOptionGuild(param1);
      }
      
      public function deserializeAsyncAs_HumanOptionGuild(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         this._guildInformationstree = param1.addChild(this._guildInformationstreeFunc);
      }
      
      private function _guildInformationstreeFunc(param1:ICustomDataInput) : void
      {
         this.guildInformations = new GuildInformations();
         this.guildInformations.deserializeAsync(this._guildInformationstree);
      }
   }
}
