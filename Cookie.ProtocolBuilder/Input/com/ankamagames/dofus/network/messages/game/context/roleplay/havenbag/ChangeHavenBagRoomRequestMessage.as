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
   public class ChangeHavenBagRoomRequestMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6638;
       
      
      private var _isInitialized:Boolean = false;
      
      public var roomId:uint = 0;
      
      public function ChangeHavenBagRoomRequestMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6638;
      }
      
      public function initChangeHavenBagRoomRequestMessage(param1:uint = 0) : ChangeHavenBagRoomRequestMessage
      {
         this.roomId = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.roomId = 0;
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
         this.serializeAs_ChangeHavenBagRoomRequestMessage(param1);
      }
      
      public function serializeAs_ChangeHavenBagRoomRequestMessage(param1:ICustomDataOutput) : void
      {
         if(this.roomId < 0)
         {
            throw new Error("Forbidden value (" + this.roomId + ") on element roomId.");
         }
         param1.writeByte(this.roomId);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ChangeHavenBagRoomRequestMessage(param1);
      }
      
      public function deserializeAs_ChangeHavenBagRoomRequestMessage(param1:ICustomDataInput) : void
      {
         this._roomIdFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ChangeHavenBagRoomRequestMessage(param1);
      }
      
      public function deserializeAsyncAs_ChangeHavenBagRoomRequestMessage(param1:FuncTree) : void
      {
         param1.addChild(this._roomIdFunc);
      }
      
      private function _roomIdFunc(param1:ICustomDataInput) : void
      {
         this.roomId = param1.readByte();
         if(this.roomId < 0)
         {
            throw new Error("Forbidden value (" + this.roomId + ") on element of ChangeHavenBagRoomRequestMessage.roomId.");
         }
      }
   }
}
