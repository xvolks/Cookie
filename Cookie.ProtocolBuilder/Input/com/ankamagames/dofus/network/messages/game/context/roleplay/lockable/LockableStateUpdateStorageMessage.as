package com.ankamagames.dofus.network.messages.game.context.roleplay.lockable
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class LockableStateUpdateStorageMessage extends LockableStateUpdateAbstractMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5669;
       
      
      private var _isInitialized:Boolean = false;
      
      public var mapId:int = 0;
      
      public var elementId:uint = 0;
      
      public function LockableStateUpdateStorageMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return super.isInitialized && this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5669;
      }
      
      public function initLockableStateUpdateStorageMessage(param1:Boolean = false, param2:int = 0, param3:uint = 0) : LockableStateUpdateStorageMessage
      {
         super.initLockableStateUpdateAbstractMessage(param1);
         this.mapId = param2;
         this.elementId = param3;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.mapId = 0;
         this.elementId = 0;
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
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_LockableStateUpdateStorageMessage(param1);
      }
      
      public function serializeAs_LockableStateUpdateStorageMessage(param1:ICustomDataOutput) : void
      {
         super.serializeAs_LockableStateUpdateAbstractMessage(param1);
         param1.writeInt(this.mapId);
         if(this.elementId < 0)
         {
            throw new Error("Forbidden value (" + this.elementId + ") on element elementId.");
         }
         param1.writeVarInt(this.elementId);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_LockableStateUpdateStorageMessage(param1);
      }
      
      public function deserializeAs_LockableStateUpdateStorageMessage(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._mapIdFunc(param1);
         this._elementIdFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_LockableStateUpdateStorageMessage(param1);
      }
      
      public function deserializeAsyncAs_LockableStateUpdateStorageMessage(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._mapIdFunc);
         param1.addChild(this._elementIdFunc);
      }
      
      private function _mapIdFunc(param1:ICustomDataInput) : void
      {
         this.mapId = param1.readInt();
      }
      
      private function _elementIdFunc(param1:ICustomDataInput) : void
      {
         this.elementId = param1.readVarUhInt();
         if(this.elementId < 0)
         {
            throw new Error("Forbidden value (" + this.elementId + ") on element of LockableStateUpdateStorageMessage.elementId.");
         }
      }
   }
}
