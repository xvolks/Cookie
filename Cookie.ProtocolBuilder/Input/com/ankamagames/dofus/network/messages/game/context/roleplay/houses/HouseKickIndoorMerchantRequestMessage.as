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
   public class HouseKickIndoorMerchantRequestMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5661;
       
      
      private var _isInitialized:Boolean = false;
      
      public var cellId:uint = 0;
      
      public function HouseKickIndoorMerchantRequestMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5661;
      }
      
      public function initHouseKickIndoorMerchantRequestMessage(param1:uint = 0) : HouseKickIndoorMerchantRequestMessage
      {
         this.cellId = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.cellId = 0;
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
         this.serializeAs_HouseKickIndoorMerchantRequestMessage(param1);
      }
      
      public function serializeAs_HouseKickIndoorMerchantRequestMessage(param1:ICustomDataOutput) : void
      {
         if(this.cellId < 0 || this.cellId > 559)
         {
            throw new Error("Forbidden value (" + this.cellId + ") on element cellId.");
         }
         param1.writeVarShort(this.cellId);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_HouseKickIndoorMerchantRequestMessage(param1);
      }
      
      public function deserializeAs_HouseKickIndoorMerchantRequestMessage(param1:ICustomDataInput) : void
      {
         this._cellIdFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_HouseKickIndoorMerchantRequestMessage(param1);
      }
      
      public function deserializeAsyncAs_HouseKickIndoorMerchantRequestMessage(param1:FuncTree) : void
      {
         param1.addChild(this._cellIdFunc);
      }
      
      private function _cellIdFunc(param1:ICustomDataInput) : void
      {
         this.cellId = param1.readVarUhShort();
         if(this.cellId < 0 || this.cellId > 559)
         {
            throw new Error("Forbidden value (" + this.cellId + ") on element of HouseKickIndoorMerchantRequestMessage.cellId.");
         }
      }
   }
}
