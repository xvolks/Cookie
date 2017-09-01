package com.ankamagames.dofus.network.messages.web.ankabox
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class MailStatusMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6275;
       
      
      private var _isInitialized:Boolean = false;
      
      public var unread:uint = 0;
      
      public var total:uint = 0;
      
      public function MailStatusMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6275;
      }
      
      public function initMailStatusMessage(param1:uint = 0, param2:uint = 0) : MailStatusMessage
      {
         this.unread = param1;
         this.total = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.unread = 0;
         this.total = 0;
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
         this.serializeAs_MailStatusMessage(param1);
      }
      
      public function serializeAs_MailStatusMessage(param1:ICustomDataOutput) : void
      {
         if(this.unread < 0)
         {
            throw new Error("Forbidden value (" + this.unread + ") on element unread.");
         }
         param1.writeVarShort(this.unread);
         if(this.total < 0)
         {
            throw new Error("Forbidden value (" + this.total + ") on element total.");
         }
         param1.writeVarShort(this.total);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_MailStatusMessage(param1);
      }
      
      public function deserializeAs_MailStatusMessage(param1:ICustomDataInput) : void
      {
         this._unreadFunc(param1);
         this._totalFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_MailStatusMessage(param1);
      }
      
      public function deserializeAsyncAs_MailStatusMessage(param1:FuncTree) : void
      {
         param1.addChild(this._unreadFunc);
         param1.addChild(this._totalFunc);
      }
      
      private function _unreadFunc(param1:ICustomDataInput) : void
      {
         this.unread = param1.readVarUhShort();
         if(this.unread < 0)
         {
            throw new Error("Forbidden value (" + this.unread + ") on element of MailStatusMessage.unread.");
         }
      }
      
      private function _totalFunc(param1:ICustomDataInput) : void
      {
         this.total = param1.readVarUhShort();
         if(this.total < 0)
         {
            throw new Error("Forbidden value (" + this.total + ") on element of MailStatusMessage.total.");
         }
      }
   }
}
