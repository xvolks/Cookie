package com.ankamagames.dofus.network.messages.game.basic
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class CurrentServerStatusUpdateMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6525;
       
      
      private var _isInitialized:Boolean = false;
      
      public var status:uint = 1;
      
      public function CurrentServerStatusUpdateMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6525;
      }
      
      public function initCurrentServerStatusUpdateMessage(param1:uint = 1) : CurrentServerStatusUpdateMessage
      {
         this.status = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.status = 1;
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
         this.serializeAs_CurrentServerStatusUpdateMessage(param1);
      }
      
      public function serializeAs_CurrentServerStatusUpdateMessage(param1:ICustomDataOutput) : void
      {
         param1.writeByte(this.status);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_CurrentServerStatusUpdateMessage(param1);
      }
      
      public function deserializeAs_CurrentServerStatusUpdateMessage(param1:ICustomDataInput) : void
      {
         this._statusFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_CurrentServerStatusUpdateMessage(param1);
      }
      
      public function deserializeAsyncAs_CurrentServerStatusUpdateMessage(param1:FuncTree) : void
      {
         param1.addChild(this._statusFunc);
      }
      
      private function _statusFunc(param1:ICustomDataInput) : void
      {
         this.status = param1.readByte();
         if(this.status < 0)
         {
            throw new Error("Forbidden value (" + this.status + ") on element of CurrentServerStatusUpdateMessage.status.");
         }
      }
   }
}
