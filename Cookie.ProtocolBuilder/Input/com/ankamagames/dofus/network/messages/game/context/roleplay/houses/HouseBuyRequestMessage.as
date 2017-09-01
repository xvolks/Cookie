package com.ankamagames.dofus.network.messages.game.context.roleplay.houses
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class HouseBuyRequestMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5738;
       
      
      private var _isInitialized:Boolean = false;
      
      public var proposedPrice:Number = 0;
      
      public function HouseBuyRequestMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5738;
      }
      
      public function initHouseBuyRequestMessage(param1:Number = 0) : HouseBuyRequestMessage
      {
         this.proposedPrice = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.proposedPrice = 0;
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
         this.serializeAs_HouseBuyRequestMessage(param1);
      }
      
      public function serializeAs_HouseBuyRequestMessage(param1:ICustomDataOutput) : void
      {
         if(this.proposedPrice < 0 || this.proposedPrice > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.proposedPrice + ") on element proposedPrice.");
         }
         param1.writeVarLong(this.proposedPrice);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_HouseBuyRequestMessage(param1);
      }
      
      public function deserializeAs_HouseBuyRequestMessage(param1:ICustomDataInput) : void
      {
         this._proposedPriceFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_HouseBuyRequestMessage(param1);
      }
      
      public function deserializeAsyncAs_HouseBuyRequestMessage(param1:FuncTree) : void
      {
         param1.addChild(this._proposedPriceFunc);
      }
      
      private function _proposedPriceFunc(param1:ICustomDataInput) : void
      {
         this.proposedPrice = param1.readVarUhLong();
         if(this.proposedPrice < 0 || this.proposedPrice > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.proposedPrice + ") on element of HouseBuyRequestMessage.proposedPrice.");
         }
      }
   }
}
