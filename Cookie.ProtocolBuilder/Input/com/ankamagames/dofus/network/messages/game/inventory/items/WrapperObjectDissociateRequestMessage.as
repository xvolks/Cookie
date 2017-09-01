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
   public class WrapperObjectDissociateRequestMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6524;
       
      
      private var _isInitialized:Boolean = false;
      
      public var hostUID:uint = 0;
      
      public var hostPos:uint = 0;
      
      public function WrapperObjectDissociateRequestMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6524;
      }
      
      public function initWrapperObjectDissociateRequestMessage(param1:uint = 0, param2:uint = 0) : WrapperObjectDissociateRequestMessage
      {
         this.hostUID = param1;
         this.hostPos = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.hostUID = 0;
         this.hostPos = 0;
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
         this.serializeAs_WrapperObjectDissociateRequestMessage(param1);
      }
      
      public function serializeAs_WrapperObjectDissociateRequestMessage(param1:ICustomDataOutput) : void
      {
         if(this.hostUID < 0)
         {
            throw new Error("Forbidden value (" + this.hostUID + ") on element hostUID.");
         }
         param1.writeVarInt(this.hostUID);
         if(this.hostPos < 0 || this.hostPos > 255)
         {
            throw new Error("Forbidden value (" + this.hostPos + ") on element hostPos.");
         }
         param1.writeByte(this.hostPos);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_WrapperObjectDissociateRequestMessage(param1);
      }
      
      public function deserializeAs_WrapperObjectDissociateRequestMessage(param1:ICustomDataInput) : void
      {
         this._hostUIDFunc(param1);
         this._hostPosFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_WrapperObjectDissociateRequestMessage(param1);
      }
      
      public function deserializeAsyncAs_WrapperObjectDissociateRequestMessage(param1:FuncTree) : void
      {
         param1.addChild(this._hostUIDFunc);
         param1.addChild(this._hostPosFunc);
      }
      
      private function _hostUIDFunc(param1:ICustomDataInput) : void
      {
         this.hostUID = param1.readVarUhInt();
         if(this.hostUID < 0)
         {
            throw new Error("Forbidden value (" + this.hostUID + ") on element of WrapperObjectDissociateRequestMessage.hostUID.");
         }
      }
      
      private function _hostPosFunc(param1:ICustomDataInput) : void
      {
         this.hostPos = param1.readUnsignedByte();
         if(this.hostPos < 0 || this.hostPos > 255)
         {
            throw new Error("Forbidden value (" + this.hostPos + ") on element of WrapperObjectDissociateRequestMessage.hostPos.");
         }
      }
   }
}
