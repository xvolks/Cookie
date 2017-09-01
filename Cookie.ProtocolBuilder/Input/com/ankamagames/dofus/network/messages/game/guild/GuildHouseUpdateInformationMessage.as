package com.ankamagames.dofus.network.messages.game.guild
{
   import com.ankamagames.dofus.network.types.game.house.HouseInformationsForGuild;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class GuildHouseUpdateInformationMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6181;
       
      
      private var _isInitialized:Boolean = false;
      
      public var housesInformations:HouseInformationsForGuild;
      
      private var _housesInformationstree:FuncTree;
      
      public function GuildHouseUpdateInformationMessage()
      {
         this.housesInformations = new HouseInformationsForGuild();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6181;
      }
      
      public function initGuildHouseUpdateInformationMessage(param1:HouseInformationsForGuild = null) : GuildHouseUpdateInformationMessage
      {
         this.housesInformations = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.housesInformations = new HouseInformationsForGuild();
         this._isInitialized = false;
      }
      
      override public function pack(param1:ICustomDataOutput) : void
      {
         var _loc2_:ByteArray = new ByteArray();
         this.serialize(new CustomDataWrapper(_loc2_));
         writePacket(param1,this.getMessageId(),_loc2_);
      }
      
      override public function unpack(param1:ICustomDataInput, param2:uint) : void
      {
         this.deserialize(param1);
      }
      
      override public function unpackAsync(param1:ICustomDataInput, param2:uint) : FuncTree
      {
         var _loc3_:FuncTree = new FuncTree();
         _loc3_.setRoot(param1);
         this.deserializeAsync(_loc3_);
         return _loc3_;
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_GuildHouseUpdateInformationMessage(param1);
      }
      
      public function serializeAs_GuildHouseUpdateInformationMessage(param1:ICustomDataOutput) : void
      {
         this.housesInformations.serializeAs_HouseInformationsForGuild(param1);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GuildHouseUpdateInformationMessage(param1);
      }
      
      public function deserializeAs_GuildHouseUpdateInformationMessage(param1:ICustomDataInput) : void
      {
         this.housesInformations = new HouseInformationsForGuild();
         this.housesInformations.deserialize(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GuildHouseUpdateInformationMessage(param1);
      }
      
      public function deserializeAsyncAs_GuildHouseUpdateInformationMessage(param1:FuncTree) : void
      {
         this._housesInformationstree = param1.addChild(this._housesInformationstreeFunc);
      }
      
      private function _housesInformationstreeFunc(param1:ICustomDataInput) : void
      {
         this.housesInformations = new HouseInformationsForGuild();
         this.housesInformations.deserializeAsync(this._housesInformationstree);
      }
   }
}
