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
   public class ObjectMovementMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 3010;
       
      
      private var _isInitialized:Boolean = false;
      
      public var objectUID:uint = 0;
      
      public var position:uint = 63;
      
      public function ObjectMovementMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 3010;
      }
      
      public function initObjectMovementMessage(param1:uint = 0, param2:uint = 63) : ObjectMovementMessage
      {
         this.objectUID = param1;
         this.position = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.objectUID = 0;
         this.position = 63;
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
         this.serializeAs_ObjectMovementMessage(param1);
      }
      
      public function serializeAs_ObjectMovementMessage(param1:ICustomDataOutput) : void
      {
         if(this.objectUID < 0)
         {
            throw new Error("Forbidden value (" + this.objectUID + ") on element objectUID.");
         }
         param1.writeVarInt(this.objectUID);
         param1.writeByte(this.position);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ObjectMovementMessage(param1);
      }
      
      public function deserializeAs_ObjectMovementMessage(param1:ICustomDataInput) : void
      {
         this._objectUIDFunc(param1);
         this._positionFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ObjectMovementMessage(param1);
      }
      
      public function deserializeAsyncAs_ObjectMovementMessage(param1:FuncTree) : void
      {
         param1.addChild(this._objectUIDFunc);
         param1.addChild(this._positionFunc);
      }
      
      private function _objectUIDFunc(param1:ICustomDataInput) : void
      {
         this.objectUID = param1.readVarUhInt();
         if(this.objectUID < 0)
         {
            throw new Error("Forbidden value (" + this.objectUID + ") on element of ObjectMovementMessage.objectUID.");
         }
      }
      
      private function _positionFunc(param1:ICustomDataInput) : void
      {
         this.position = param1.readUnsignedByte();
         if(this.position < 0 || this.position > 255)
         {
            throw new Error("Forbidden value (" + this.position + ") on element of ObjectMovementMessage.position.");
         }
      }
   }
}
