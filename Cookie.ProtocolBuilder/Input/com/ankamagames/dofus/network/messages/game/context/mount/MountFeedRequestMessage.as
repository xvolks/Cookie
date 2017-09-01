package com.ankamagames.dofus.network.messages.game.context.mount
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class MountFeedRequestMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6189;
       
      
      private var _isInitialized:Boolean = false;
      
      public var mountUid:uint = 0;
      
      public var mountLocation:int = 0;
      
      public var mountFoodUid:uint = 0;
      
      public var quantity:uint = 0;
      
      public function MountFeedRequestMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6189;
      }
      
      public function initMountFeedRequestMessage(param1:uint = 0, param2:int = 0, param3:uint = 0, param4:uint = 0) : MountFeedRequestMessage
      {
         this.mountUid = param1;
         this.mountLocation = param2;
         this.mountFoodUid = param3;
         this.quantity = param4;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.mountUid = 0;
         this.mountLocation = 0;
         this.mountFoodUid = 0;
         this.quantity = 0;
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
         this.serializeAs_MountFeedRequestMessage(param1);
      }
      
      public function serializeAs_MountFeedRequestMessage(param1:ICustomDataOutput) : void
      {
         if(this.mountUid < 0)
         {
            throw new Error("Forbidden value (" + this.mountUid + ") on element mountUid.");
         }
         param1.writeVarInt(this.mountUid);
         param1.writeByte(this.mountLocation);
         if(this.mountFoodUid < 0)
         {
            throw new Error("Forbidden value (" + this.mountFoodUid + ") on element mountFoodUid.");
         }
         param1.writeVarInt(this.mountFoodUid);
         if(this.quantity < 0)
         {
            throw new Error("Forbidden value (" + this.quantity + ") on element quantity.");
         }
         param1.writeVarInt(this.quantity);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_MountFeedRequestMessage(param1);
      }
      
      public function deserializeAs_MountFeedRequestMessage(param1:ICustomDataInput) : void
      {
         this._mountUidFunc(param1);
         this._mountLocationFunc(param1);
         this._mountFoodUidFunc(param1);
         this._quantityFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_MountFeedRequestMessage(param1);
      }
      
      public function deserializeAsyncAs_MountFeedRequestMessage(param1:FuncTree) : void
      {
         param1.addChild(this._mountUidFunc);
         param1.addChild(this._mountLocationFunc);
         param1.addChild(this._mountFoodUidFunc);
         param1.addChild(this._quantityFunc);
      }
      
      private function _mountUidFunc(param1:ICustomDataInput) : void
      {
         this.mountUid = param1.readVarUhInt();
         if(this.mountUid < 0)
         {
            throw new Error("Forbidden value (" + this.mountUid + ") on element of MountFeedRequestMessage.mountUid.");
         }
      }
      
      private function _mountLocationFunc(param1:ICustomDataInput) : void
      {
         this.mountLocation = param1.readByte();
      }
      
      private function _mountFoodUidFunc(param1:ICustomDataInput) : void
      {
         this.mountFoodUid = param1.readVarUhInt();
         if(this.mountFoodUid < 0)
         {
            throw new Error("Forbidden value (" + this.mountFoodUid + ") on element of MountFeedRequestMessage.mountFoodUid.");
         }
      }
      
      private function _quantityFunc(param1:ICustomDataInput) : void
      {
         this.quantity = param1.readVarUhInt();
         if(this.quantity < 0)
         {
            throw new Error("Forbidden value (" + this.quantity + ") on element of MountFeedRequestMessage.quantity.");
         }
      }
   }
}
