package com.ankamagames.dofus.network.messages.game.social
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class ContactLookRequestByIdMessage extends ContactLookRequestMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5935;
       
      
      private var _isInitialized:Boolean = false;
      
      public var playerId:Number = 0;
      
      public function ContactLookRequestByIdMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return super.isInitialized && this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5935;
      }
      
      public function initContactLookRequestByIdMessage(param1:uint = 0, param2:uint = 0, param3:Number = 0) : ContactLookRequestByIdMessage
      {
         super.initContactLookRequestMessage(param1,param2);
         this.playerId = param3;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.playerId = 0;
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
         this.serializeAs_ContactLookRequestByIdMessage(param1);
      }
      
      public function serializeAs_ContactLookRequestByIdMessage(param1:ICustomDataOutput) : void
      {
         super.serializeAs_ContactLookRequestMessage(param1);
         if(this.playerId < 0 || this.playerId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.playerId + ") on element playerId.");
         }
         param1.writeVarLong(this.playerId);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ContactLookRequestByIdMessage(param1);
      }
      
      public function deserializeAs_ContactLookRequestByIdMessage(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._playerIdFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ContactLookRequestByIdMessage(param1);
      }
      
      public function deserializeAsyncAs_ContactLookRequestByIdMessage(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._playerIdFunc);
      }
      
      private function _playerIdFunc(param1:ICustomDataInput) : void
      {
         this.playerId = param1.readVarUhLong();
         if(this.playerId < 0 || this.playerId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.playerId + ") on element of ContactLookRequestByIdMessage.playerId.");
         }
      }
   }
}
