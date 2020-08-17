package com.ankamagames.dofus.network.messages.connection
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class ServerSelectionMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 40;
       
      
      private var _isInitialized:Boolean = false;
      
      public var serverId:uint = 0;
      
      public function ServerSelectionMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 40;
      }
      
      public function initServerSelectionMessage(param1:uint = 0) : ServerSelectionMessage
      {
         this.serverId = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.serverId = 0;
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
         this.serializeAs_ServerSelectionMessage(param1);
      }
      
      public function serializeAs_ServerSelectionMessage(param1:ICustomDataOutput) : void
      {
         if(this.serverId < 0)
         {
            throw new Error("Forbidden value (" + this.serverId + ") on element serverId.");
         }
         param1.writeVarShort(this.serverId);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ServerSelectionMessage(param1);
      }
      
      public function deserializeAs_ServerSelectionMessage(param1:ICustomDataInput) : void
      {
         this._serverIdFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ServerSelectionMessage(param1);
      }
      
      public function deserializeAsyncAs_ServerSelectionMessage(param1:FuncTree) : void
      {
         param1.addChild(this._serverIdFunc);
      }
      
      private function _serverIdFunc(param1:ICustomDataInput) : void
      {
         this.serverId = param1.readVarUhShort();
         if(this.serverId < 0)
         {
            throw new Error("Forbidden value (" + this.serverId + ") on element of ServerSelectionMessage.serverId.");
         }
      }
   }
}
