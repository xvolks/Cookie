package com.ankamagames.dofus.network.messages.game.ui
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class ClientUIOpenedByObjectMessage extends ClientUIOpenedMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6463;
       
      
      private var _isInitialized:Boolean = false;
      
      public var uid:uint = 0;
      
      public function ClientUIOpenedByObjectMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return super.isInitialized && this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6463;
      }
      
      public function initClientUIOpenedByObjectMessage(param1:uint = 0, param2:uint = 0) : ClientUIOpenedByObjectMessage
      {
         super.initClientUIOpenedMessage(param1);
         this.uid = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.uid = 0;
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
         this.serializeAs_ClientUIOpenedByObjectMessage(param1);
      }
      
      public function serializeAs_ClientUIOpenedByObjectMessage(param1:ICustomDataOutput) : void
      {
         super.serializeAs_ClientUIOpenedMessage(param1);
         if(this.uid < 0)
         {
            throw new Error("Forbidden value (" + this.uid + ") on element uid.");
         }
         param1.writeVarInt(this.uid);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ClientUIOpenedByObjectMessage(param1);
      }
      
      public function deserializeAs_ClientUIOpenedByObjectMessage(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._uidFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ClientUIOpenedByObjectMessage(param1);
      }
      
      public function deserializeAsyncAs_ClientUIOpenedByObjectMessage(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._uidFunc);
      }
      
      private function _uidFunc(param1:ICustomDataInput) : void
      {
         this.uid = param1.readVarUhInt();
         if(this.uid < 0)
         {
            throw new Error("Forbidden value (" + this.uid + ") on element of ClientUIOpenedByObjectMessage.uid.");
         }
      }
   }
}
