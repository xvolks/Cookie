package com.ankamagames.dofus.network.messages.game.character.choice
{
   import com.ankamagames.dofus.network.types.game.character.choice.CharacterBaseInformations;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class CharacterSelectedSuccessMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 153;
       
      
      private var _isInitialized:Boolean = false;
      
      public var infos:CharacterBaseInformations;
      
      public var isCollectingStats:Boolean = false;
      
      private var _infostree:FuncTree;
      
      public function CharacterSelectedSuccessMessage()
      {
         this.infos = new CharacterBaseInformations();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 153;
      }
      
      public function initCharacterSelectedSuccessMessage(param1:CharacterBaseInformations = null, param2:Boolean = false) : CharacterSelectedSuccessMessage
      {
         this.infos = param1;
         this.isCollectingStats = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.infos = new CharacterBaseInformations();
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
         this.serializeAs_CharacterSelectedSuccessMessage(param1);
      }
      
      public function serializeAs_CharacterSelectedSuccessMessage(param1:ICustomDataOutput) : void
      {
         this.infos.serializeAs_CharacterBaseInformations(param1);
         param1.writeBoolean(this.isCollectingStats);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_CharacterSelectedSuccessMessage(param1);
      }
      
      public function deserializeAs_CharacterSelectedSuccessMessage(param1:ICustomDataInput) : void
      {
         this.infos = new CharacterBaseInformations();
         this.infos.deserialize(param1);
         this._isCollectingStatsFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_CharacterSelectedSuccessMessage(param1);
      }
      
      public function deserializeAsyncAs_CharacterSelectedSuccessMessage(param1:FuncTree) : void
      {
         this._infostree = param1.addChild(this._infostreeFunc);
         param1.addChild(this._isCollectingStatsFunc);
      }
      
      private function _infostreeFunc(param1:ICustomDataInput) : void
      {
         this.infos = new CharacterBaseInformations();
         this.infos.deserializeAsync(this._infostree);
      }
      
      private function _isCollectingStatsFunc(param1:ICustomDataInput) : void
      {
         this.isCollectingStats = param1.readBoolean();
      }
   }
}
