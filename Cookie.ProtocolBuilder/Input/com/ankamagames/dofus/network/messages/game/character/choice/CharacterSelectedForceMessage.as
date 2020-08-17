package com.ankamagames.dofus.network.messages.game.character.choice
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class CharacterSelectedForceMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6068;
       
      
      private var _isInitialized:Boolean = false;
      
      public var id:int = 0;
      
      public function CharacterSelectedForceMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6068;
      }
      
      public function initCharacterSelectedForceMessage(param1:int = 0) : CharacterSelectedForceMessage
      {
         this.id = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.id = 0;
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
         this.serializeAs_CharacterSelectedForceMessage(param1);
      }
      
      public function serializeAs_CharacterSelectedForceMessage(param1:ICustomDataOutput) : void
      {
         if(this.id < 1 || this.id > 2147483647)
         {
            throw new Error("Forbidden value (" + this.id + ") on element id.");
         }
         param1.writeInt(this.id);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_CharacterSelectedForceMessage(param1);
      }
      
      public function deserializeAs_CharacterSelectedForceMessage(param1:ICustomDataInput) : void
      {
         this._idFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_CharacterSelectedForceMessage(param1);
      }
      
      public function deserializeAsyncAs_CharacterSelectedForceMessage(param1:FuncTree) : void
      {
         param1.addChild(this._idFunc);
      }
      
      private function _idFunc(param1:ICustomDataInput) : void
      {
         this.id = param1.readInt();
         if(this.id < 1 || this.id > 2147483647)
         {
            throw new Error("Forbidden value (" + this.id + ") on element of CharacterSelectedForceMessage.id.");
         }
      }
   }
}
