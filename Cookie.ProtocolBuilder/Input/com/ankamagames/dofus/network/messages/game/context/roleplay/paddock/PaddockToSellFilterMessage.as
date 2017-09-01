package com.ankamagames.dofus.network.messages.game.context.roleplay.paddock
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class PaddockToSellFilterMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6161;
       
      
      private var _isInitialized:Boolean = false;
      
      public var areaId:int = 0;
      
      public var atLeastNbMount:int = 0;
      
      public var atLeastNbMachine:int = 0;
      
      public var maxPrice:Number = 0;
      
      public function PaddockToSellFilterMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6161;
      }
      
      public function initPaddockToSellFilterMessage(param1:int = 0, param2:int = 0, param3:int = 0, param4:Number = 0) : PaddockToSellFilterMessage
      {
         this.areaId = param1;
         this.atLeastNbMount = param2;
         this.atLeastNbMachine = param3;
         this.maxPrice = param4;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.areaId = 0;
         this.atLeastNbMount = 0;
         this.atLeastNbMachine = 0;
         this.maxPrice = 0;
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
         this.serializeAs_PaddockToSellFilterMessage(param1);
      }
      
      public function serializeAs_PaddockToSellFilterMessage(param1:ICustomDataOutput) : void
      {
         param1.writeInt(this.areaId);
         param1.writeByte(this.atLeastNbMount);
         param1.writeByte(this.atLeastNbMachine);
         if(this.maxPrice < 0 || this.maxPrice > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.maxPrice + ") on element maxPrice.");
         }
         param1.writeVarLong(this.maxPrice);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_PaddockToSellFilterMessage(param1);
      }
      
      public function deserializeAs_PaddockToSellFilterMessage(param1:ICustomDataInput) : void
      {
         this._areaIdFunc(param1);
         this._atLeastNbMountFunc(param1);
         this._atLeastNbMachineFunc(param1);
         this._maxPriceFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_PaddockToSellFilterMessage(param1);
      }
      
      public function deserializeAsyncAs_PaddockToSellFilterMessage(param1:FuncTree) : void
      {
         param1.addChild(this._areaIdFunc);
         param1.addChild(this._atLeastNbMountFunc);
         param1.addChild(this._atLeastNbMachineFunc);
         param1.addChild(this._maxPriceFunc);
      }
      
      private function _areaIdFunc(param1:ICustomDataInput) : void
      {
         this.areaId = param1.readInt();
      }
      
      private function _atLeastNbMountFunc(param1:ICustomDataInput) : void
      {
         this.atLeastNbMount = param1.readByte();
      }
      
      private function _atLeastNbMachineFunc(param1:ICustomDataInput) : void
      {
         this.atLeastNbMachine = param1.readByte();
      }
      
      private function _maxPriceFunc(param1:ICustomDataInput) : void
      {
         this.maxPrice = param1.readVarUhLong();
         if(this.maxPrice < 0 || this.maxPrice > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.maxPrice + ") on element of PaddockToSellFilterMessage.maxPrice.");
         }
      }
   }
}
