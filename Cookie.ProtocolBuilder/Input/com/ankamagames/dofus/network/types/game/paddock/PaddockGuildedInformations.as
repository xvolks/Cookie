package com.ankamagames.dofus.network.types.game.paddock
{
   import com.ankamagames.dofus.network.types.game.context.roleplay.GuildInformations;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class PaddockGuildedInformations extends PaddockBuyableInformations implements INetworkType
   {
      
      public static const protocolId:uint = 508;
       
      
      public var deserted:Boolean = false;
      
      public var guildInfo:GuildInformations;
      
      private var _guildInfotree:FuncTree;
      
      public function PaddockGuildedInformations()
      {
         this.guildInfo = new GuildInformations();
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 508;
      }
      
      public function initPaddockGuildedInformations(param1:Number = 0, param2:Boolean = false, param3:Boolean = false, param4:GuildInformations = null) : PaddockGuildedInformations
      {
         super.initPaddockBuyableInformations(param1,param2);
         this.deserted = param3;
         this.guildInfo = param4;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.deserted = false;
         this.guildInfo = new GuildInformations();
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_PaddockGuildedInformations(param1);
      }
      
      public function serializeAs_PaddockGuildedInformations(param1:ICustomDataOutput) : void
      {
         super.serializeAs_PaddockBuyableInformations(param1);
         param1.writeBoolean(this.deserted);
         this.guildInfo.serializeAs_GuildInformations(param1);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_PaddockGuildedInformations(param1);
      }
      
      public function deserializeAs_PaddockGuildedInformations(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._desertedFunc(param1);
         this.guildInfo = new GuildInformations();
         this.guildInfo.deserialize(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_PaddockGuildedInformations(param1);
      }
      
      public function deserializeAsyncAs_PaddockGuildedInformations(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._desertedFunc);
         this._guildInfotree = param1.addChild(this._guildInfotreeFunc);
      }
      
      private function _desertedFunc(param1:ICustomDataInput) : void
      {
         this.deserted = param1.readBoolean();
      }
      
      private function _guildInfotreeFunc(param1:ICustomDataInput) : void
      {
         this.guildInfo = new GuildInformations();
         this.guildInfo.deserializeAsync(this._guildInfotree);
      }
   }
}
