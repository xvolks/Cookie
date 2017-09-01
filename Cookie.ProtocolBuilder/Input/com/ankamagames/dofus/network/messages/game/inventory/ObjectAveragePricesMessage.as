package com.ankamagames.dofus.network.messages.game.inventory
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class ObjectAveragePricesMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6335;
       
      
      private var _isInitialized:Boolean = false;
      
      public var ids:Vector.<uint>;
      
      public var avgPrices:Vector.<Number>;
      
      private var _idstree:FuncTree;
      
      private var _avgPricestree:FuncTree;
      
      public function ObjectAveragePricesMessage()
      {
         this.ids = new Vector.<uint>();
         this.avgPrices = new Vector.<Number>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6335;
      }
      
      public function initObjectAveragePricesMessage(param1:Vector.<uint> = null, param2:Vector.<Number> = null) : ObjectAveragePricesMessage
      {
         this.ids = param1;
         this.avgPrices = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.ids = new Vector.<uint>();
         this.avgPrices = new Vector.<Number>();
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
         this.serializeAs_ObjectAveragePricesMessage(param1);
      }
      
      public function serializeAs_ObjectAveragePricesMessage(param1:ICustomDataOutput) : void
      {
         param1.writeShort(this.ids.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.ids.length)
         {
            if(this.ids[_loc2_] < 0)
            {
               throw new Error("Forbidden value (" + this.ids[_loc2_] + ") on element 1 (starting at 1) of ids.");
            }
            param1.writeVarShort(this.ids[_loc2_]);
            _loc2_++;
         }
         param1.writeShort(this.avgPrices.length);
         var _loc3_:uint = 0;
         while(_loc3_ < this.avgPrices.length)
         {
            if(this.avgPrices[_loc3_] < 0 || this.avgPrices[_loc3_] > 9007199254740990)
            {
               throw new Error("Forbidden value (" + this.avgPrices[_loc3_] + ") on element 2 (starting at 1) of avgPrices.");
            }
            param1.writeVarLong(this.avgPrices[_loc3_]);
            _loc3_++;
         }
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ObjectAveragePricesMessage(param1);
      }
      
      public function deserializeAs_ObjectAveragePricesMessage(param1:ICustomDataInput) : void
      {
         var _loc6_:uint = 0;
         var _loc7_:Number = NaN;
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc6_ = param1.readVarUhShort();
            if(_loc6_ < 0)
            {
               throw new Error("Forbidden value (" + _loc6_ + ") on elements of ids.");
            }
            this.ids.push(_loc6_);
            _loc3_++;
         }
         var _loc4_:uint = param1.readUnsignedShort();
         var _loc5_:uint = 0;
         while(_loc5_ < _loc4_)
         {
            _loc7_ = param1.readVarUhLong();
            if(_loc7_ < 0 || _loc7_ > 9007199254740990)
            {
               throw new Error("Forbidden value (" + _loc7_ + ") on elements of avgPrices.");
            }
            this.avgPrices.push(_loc7_);
            _loc5_++;
         }
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ObjectAveragePricesMessage(param1);
      }
      
      public function deserializeAsyncAs_ObjectAveragePricesMessage(param1:FuncTree) : void
      {
         this._idstree = param1.addChild(this._idstreeFunc);
         this._avgPricestree = param1.addChild(this._avgPricestreeFunc);
      }
      
      private function _idstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._idstree.addChild(this._idsFunc);
            _loc3_++;
         }
      }
      
      private function _idsFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readVarUhShort();
         if(_loc2_ < 0)
         {
            throw new Error("Forbidden value (" + _loc2_ + ") on elements of ids.");
         }
         this.ids.push(_loc2_);
      }
      
      private function _avgPricestreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._avgPricestree.addChild(this._avgPricesFunc);
            _loc3_++;
         }
      }
      
      private function _avgPricesFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:Number = param1.readVarUhLong();
         if(_loc2_ < 0 || _loc2_ > 9007199254740990)
         {
            throw new Error("Forbidden value (" + _loc2_ + ") on elements of avgPrices.");
         }
         this.avgPrices.push(_loc2_);
      }
   }
}
