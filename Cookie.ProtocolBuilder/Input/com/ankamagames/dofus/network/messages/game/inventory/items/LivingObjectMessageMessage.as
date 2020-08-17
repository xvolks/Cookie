package com.ankamagames.dofus.network.messages.game.inventory.items
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class LivingObjectMessageMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6065;
       
      
      private var _isInitialized:Boolean = false;
      
      public var msgId:uint = 0;
      
      public var timeStamp:uint = 0;
      
      public var owner:String = "";
      
      public var objectGenericId:uint = 0;
      
      public function LivingObjectMessageMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6065;
      }
      
      public function initLivingObjectMessageMessage(param1:uint = 0, param2:uint = 0, param3:String = "", param4:uint = 0) : LivingObjectMessageMessage
      {
         this.msgId = param1;
         this.timeStamp = param2;
         this.owner = param3;
         this.objectGenericId = param4;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.msgId = 0;
         this.timeStamp = 0;
         this.owner = "";
         this.objectGenericId = 0;
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
         this.serializeAs_LivingObjectMessageMessage(param1);
      }
      
      public function serializeAs_LivingObjectMessageMessage(param1:ICustomDataOutput) : void
      {
         if(this.msgId < 0)
         {
            throw new Error("Forbidden value (" + this.msgId + ") on element msgId.");
         }
         param1.writeVarShort(this.msgId);
         if(this.timeStamp < 0)
         {
            throw new Error("Forbidden value (" + this.timeStamp + ") on element timeStamp.");
         }
         param1.writeInt(this.timeStamp);
         param1.writeUTF(this.owner);
         if(this.objectGenericId < 0)
         {
            throw new Error("Forbidden value (" + this.objectGenericId + ") on element objectGenericId.");
         }
         param1.writeVarShort(this.objectGenericId);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_LivingObjectMessageMessage(param1);
      }
      
      public function deserializeAs_LivingObjectMessageMessage(param1:ICustomDataInput) : void
      {
         this._msgIdFunc(param1);
         this._timeStampFunc(param1);
         this._ownerFunc(param1);
         this._objectGenericIdFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_LivingObjectMessageMessage(param1);
      }
      
      public function deserializeAsyncAs_LivingObjectMessageMessage(param1:FuncTree) : void
      {
         param1.addChild(this._msgIdFunc);
         param1.addChild(this._timeStampFunc);
         param1.addChild(this._ownerFunc);
         param1.addChild(this._objectGenericIdFunc);
      }
      
      private function _msgIdFunc(param1:ICustomDataInput) : void
      {
         this.msgId = param1.readVarUhShort();
         if(this.msgId < 0)
         {
            throw new Error("Forbidden value (" + this.msgId + ") on element of LivingObjectMessageMessage.msgId.");
         }
      }
      
      private function _timeStampFunc(param1:ICustomDataInput) : void
      {
         this.timeStamp = param1.readInt();
         if(this.timeStamp < 0)
         {
            throw new Error("Forbidden value (" + this.timeStamp + ") on element of LivingObjectMessageMessage.timeStamp.");
         }
      }
      
      private function _ownerFunc(param1:ICustomDataInput) : void
      {
         this.owner = param1.readUTF();
      }
      
      private function _objectGenericIdFunc(param1:ICustomDataInput) : void
      {
         this.objectGenericId = param1.readVarUhShort();
         if(this.objectGenericId < 0)
         {
            throw new Error("Forbidden value (" + this.objectGenericId + ") on element of LivingObjectMessageMessage.objectGenericId.");
         }
      }
   }
}
