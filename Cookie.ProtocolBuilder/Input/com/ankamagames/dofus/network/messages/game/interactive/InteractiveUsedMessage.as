package com.ankamagames.dofus.network.messages.game.interactive
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class InteractiveUsedMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5745;
       
      
      private var _isInitialized:Boolean = false;
      
      public var entityId:Number = 0;
      
      public var elemId:uint = 0;
      
      public var skillId:uint = 0;
      
      public var duration:uint = 0;
      
      public var canMove:Boolean = false;
      
      public function InteractiveUsedMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5745;
      }
      
      public function initInteractiveUsedMessage(param1:Number = 0, param2:uint = 0, param3:uint = 0, param4:uint = 0, param5:Boolean = false) : InteractiveUsedMessage
      {
         this.entityId = param1;
         this.elemId = param2;
         this.skillId = param3;
         this.duration = param4;
         this.canMove = param5;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.entityId = 0;
         this.elemId = 0;
         this.skillId = 0;
         this.duration = 0;
         this.canMove = false;
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
         this.serializeAs_InteractiveUsedMessage(param1);
      }
      
      public function serializeAs_InteractiveUsedMessage(param1:ICustomDataOutput) : void
      {
         if(this.entityId < 0 || this.entityId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.entityId + ") on element entityId.");
         }
         param1.writeVarLong(this.entityId);
         if(this.elemId < 0)
         {
            throw new Error("Forbidden value (" + this.elemId + ") on element elemId.");
         }
         param1.writeVarInt(this.elemId);
         if(this.skillId < 0)
         {
            throw new Error("Forbidden value (" + this.skillId + ") on element skillId.");
         }
         param1.writeVarShort(this.skillId);
         if(this.duration < 0)
         {
            throw new Error("Forbidden value (" + this.duration + ") on element duration.");
         }
         param1.writeVarShort(this.duration);
         param1.writeBoolean(this.canMove);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_InteractiveUsedMessage(param1);
      }
      
      public function deserializeAs_InteractiveUsedMessage(param1:ICustomDataInput) : void
      {
         this._entityIdFunc(param1);
         this._elemIdFunc(param1);
         this._skillIdFunc(param1);
         this._durationFunc(param1);
         this._canMoveFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_InteractiveUsedMessage(param1);
      }
      
      public function deserializeAsyncAs_InteractiveUsedMessage(param1:FuncTree) : void
      {
         param1.addChild(this._entityIdFunc);
         param1.addChild(this._elemIdFunc);
         param1.addChild(this._skillIdFunc);
         param1.addChild(this._durationFunc);
         param1.addChild(this._canMoveFunc);
      }
      
      private function _entityIdFunc(param1:ICustomDataInput) : void
      {
         this.entityId = param1.readVarUhLong();
         if(this.entityId < 0 || this.entityId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.entityId + ") on element of InteractiveUsedMessage.entityId.");
         }
      }
      
      private function _elemIdFunc(param1:ICustomDataInput) : void
      {
         this.elemId = param1.readVarUhInt();
         if(this.elemId < 0)
         {
            throw new Error("Forbidden value (" + this.elemId + ") on element of InteractiveUsedMessage.elemId.");
         }
      }
      
      private function _skillIdFunc(param1:ICustomDataInput) : void
      {
         this.skillId = param1.readVarUhShort();
         if(this.skillId < 0)
         {
            throw new Error("Forbidden value (" + this.skillId + ") on element of InteractiveUsedMessage.skillId.");
         }
      }
      
      private function _durationFunc(param1:ICustomDataInput) : void
      {
         this.duration = param1.readVarUhShort();
         if(this.duration < 0)
         {
            throw new Error("Forbidden value (" + this.duration + ") on element of InteractiveUsedMessage.duration.");
         }
      }
      
      private function _canMoveFunc(param1:ICustomDataInput) : void
      {
         this.canMove = param1.readBoolean();
      }
   }
}
