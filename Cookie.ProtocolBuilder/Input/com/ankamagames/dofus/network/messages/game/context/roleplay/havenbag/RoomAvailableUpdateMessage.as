package com.ankamagames.dofus.network.messages.game.context.roleplay.havenbag
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class RoomAvailableUpdateMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6630;
       
      
      private var _isInitialized:Boolean = false;
      
      public var nbRoom:uint = 0;
      
      public function RoomAvailableUpdateMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6630;
      }
      
      public function initRoomAvailableUpdateMessage(param1:uint = 0) : RoomAvailableUpdateMessage
      {
         this.nbRoom = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.nbRoom = 0;
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
         this.serializeAs_RoomAvailableUpdateMessage(param1);
      }
      
      public function serializeAs_RoomAvailableUpdateMessage(param1:ICustomDataOutput) : void
      {
         if(this.nbRoom < 0 || this.nbRoom > 255)
         {
            throw new Error("Forbidden value (" + this.nbRoom + ") on element nbRoom.");
         }
         param1.writeByte(this.nbRoom);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_RoomAvailableUpdateMessage(param1);
      }
      
      public function deserializeAs_RoomAvailableUpdateMessage(param1:ICustomDataInput) : void
      {
         this._nbRoomFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_RoomAvailableUpdateMessage(param1);
      }
      
      public function deserializeAsyncAs_RoomAvailableUpdateMessage(param1:FuncTree) : void
      {
         param1.addChild(this._nbRoomFunc);
      }
      
      private function _nbRoomFunc(param1:ICustomDataInput) : void
      {
         this.nbRoom = param1.readUnsignedByte();
         if(this.nbRoom < 0 || this.nbRoom > 255)
         {
            throw new Error("Forbidden value (" + this.nbRoom + ") on element of RoomAvailableUpdateMessage.nbRoom.");
         }
      }
   }
}
