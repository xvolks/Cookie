package com.ankamagames.dofus.network.messages.game.character.replay
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class CharacterReplayRequestMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 167;
       
      
      private var _isInitialized:Boolean = false;
      
      public var characterId:Number = 0;
      
      public function CharacterReplayRequestMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 167;
      }
      
      public function initCharacterReplayRequestMessage(param1:Number = 0) : CharacterReplayRequestMessage
      {
         this.characterId = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.characterId = 0;
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
         this.serializeAs_CharacterReplayRequestMessage(param1);
      }
      
      public function serializeAs_CharacterReplayRequestMessage(param1:ICustomDataOutput) : void
      {
         if(this.characterId < 0 || this.characterId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.characterId + ") on element characterId.");
         }
         param1.writeVarLong(this.characterId);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_CharacterReplayRequestMessage(param1);
      }
      
      public function deserializeAs_CharacterReplayRequestMessage(param1:ICustomDataInput) : void
      {
         this._characterIdFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_CharacterReplayRequestMessage(param1);
      }
      
      public function deserializeAsyncAs_CharacterReplayRequestMessage(param1:FuncTree) : void
      {
         param1.addChild(this._characterIdFunc);
      }
      
      private function _characterIdFunc(param1:ICustomDataInput) : void
      {
         this.characterId = param1.readVarUhLong();
         if(this.characterId < 0 || this.characterId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.characterId + ") on element of CharacterReplayRequestMessage.characterId.");
         }
      }
   }
}
